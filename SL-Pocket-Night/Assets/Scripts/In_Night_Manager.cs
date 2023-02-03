using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class In_Night_Manager : MonoBehaviour
{
    int frames = 20;
    int actualHour;
    public int oxigen;
    float oxigenTimer;
    public int battery;
    float batteryTimer;
    int usage;
    [Header("Listas de sprites")]
    public List<Sprite> numbersHUD = new List<Sprite>();
    SpriteRenderer usageRenderer;
    public List<Sprite> usageSprites = new List<Sprite>();
    SpriteRenderer hourRenderer;
    public List<Sprite> hourSprites = new List<Sprite>();
    float timer;
    int secondsPerHour;
    public bool rightClosed;
    public bool leftClosed;
    public bool ventClosed;
    Animator rightAnim;
    Animator leftAnim;
    Animator ventAnim;
    public bool camsUp;
    Animator camsAnim;
    bool havePower;
    Animator fanAnim;
    void Start()
    {
        Application.targetFrameRate = frames;
        usageRenderer = GameObject.FindGameObjectWithTag("Usage_HUD").GetComponent<SpriteRenderer>();
        hourRenderer = GameObject.FindGameObjectWithTag("Hour_HUD").GetComponent<SpriteRenderer>();
        oxigen = 100;
        oxigenTimer = 0;
        battery = 100;
        batteryTimer = 0;
        usage = 0;
        actualHour = 0;
        secondsPerHour = 60;
        rightClosed = false;
        leftClosed = false;
        ventClosed = false;
        camsUp = false;
        rightAnim = GameObject.FindGameObjectWithTag("Right_Door").GetComponent<Animator>();
        leftAnim = GameObject.FindGameObjectWithTag("Left_Door").GetComponent<Animator>();
        ventAnim = GameObject.FindGameObjectWithTag("Vent_Door").GetComponent<Animator>();
        camsAnim = GameObject.FindGameObjectWithTag("Cams").GetComponent<Animator>();
        rightAnim.SetBool("Closed", rightClosed);
        leftAnim.SetBool("Closed", leftClosed);
        ventAnim.SetBool("Closed", ventClosed);
        camsAnim.SetBool("Open", camsUp);
        havePower = true;
        fanAnim = GameObject.FindGameObjectWithTag("Fan").GetComponent<Animator>();
    }
    void Update()
    {
        oxigen = Mathf.Clamp(oxigen, 0, 100);
        battery = Mathf.Clamp(battery, 0, 100);
        usage = Mathf.Clamp(usage, 0, 4);
        actualHour = Mathf.Clamp(actualHour, 0, 6);
        int oxigenHundreds = oxigen / 100;
        int oxigenTens = (oxigen - (oxigenHundreds * 100)) / 10;
        int oxigenUnits = oxigen - (oxigenHundreds * 100) - (oxigenTens * 10);
        SpriteRenderer oxigenHundredsIndicator = GameObject.FindGameObjectWithTag("Oxigen_Hundreds").GetComponent<SpriteRenderer>();
        SpriteRenderer oxigenTensIndicator = GameObject.FindGameObjectWithTag("Oxigen_Tens").GetComponent<SpriteRenderer>();
        SpriteRenderer oxigenUnitsIndicator = GameObject.FindGameObjectWithTag("Oxigen_Units").GetComponent<SpriteRenderer>();
        oxigenHundredsIndicator.sprite = numbersHUD[oxigenHundreds];
        oxigenTensIndicator.sprite = numbersHUD[oxigenTens];
        oxigenUnitsIndicator.sprite = numbersHUD[oxigenUnits];
        SpriteRenderer blackoutRenderer = GameObject.FindGameObjectWithTag("Blackout").GetComponent<SpriteRenderer>();
        float blackoutAlpha = ((100f - oxigen) / 1.1f) / 100f;
        blackoutRenderer.color = new Color(255, 255, 255, blackoutAlpha);
        int batteryHundreds = battery / 100;
        int batteryTens = (battery - (batteryHundreds * 100)) / 10;
        int batteryUnits = battery - (batteryHundreds * 100) - (batteryTens * 10);
        SpriteRenderer batteryHundredsIndicator = GameObject.FindGameObjectWithTag("Battery_Hundreds").GetComponent<SpriteRenderer>();
        SpriteRenderer batteryTensIndicator = GameObject.FindGameObjectWithTag("Battery_Tens").GetComponent<SpriteRenderer>();
        SpriteRenderer batteryUnitsIndicator = GameObject.FindGameObjectWithTag("Battery_Units").GetComponent<SpriteRenderer>();
        batteryHundredsIndicator.sprite = numbersHUD[batteryHundreds];
        batteryTensIndicator.sprite = numbersHUD[batteryTens];
        batteryUnitsIndicator.sprite = numbersHUD[batteryUnits];
        int rightUsage = rightClosed ? 1 : 0;
        int leftUsage = leftClosed ? 1 : 0;
        int ventUsage = ventClosed ? 1 : 0;
        int camsUsage = camsUp ? 1 : 0;
        usage = rightUsage + leftUsage + ventUsage + camsUsage;
        usageRenderer.sprite = usageSprites[usage];
        hourRenderer.sprite = hourSprites[actualHour];
        timer += Time.deltaTime;
        if (timer >= secondsPerHour)
        {
            timer = 0;
            actualHour++;
        }
        if (actualHour == 6)
        { SceneManager.LoadScene("Post_Night"); }
        if (havePower)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rightClosed = !rightClosed;
                rightAnim.SetBool("Closed", rightClosed);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                leftClosed = !leftClosed;
                leftAnim.SetBool("Closed", leftClosed);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ventClosed = !ventClosed;
                ventAnim.SetBool("Closed", ventClosed);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                camsUp = !camsUp;
                camsAnim.SetBool("Open", camsUp);
            }
        }
        batteryTimer += Time.deltaTime;
        if (batteryTimer >= 9)
        {
            batteryTimer = 0;
            battery -= (usage + 1);
        }
        if (battery == 0)
        { NoPower(); }
        oxigenTimer += Time.deltaTime;
        if (oxigenTimer >= 1)
        {
            oxigenTimer = 0;
            oxigen++;
        }
    }

    void NoPower()
    {
        havePower = false;
        rightClosed = false;
        rightAnim.SetBool("Closed", rightClosed);
        leftClosed = false;
        leftAnim.SetBool("Closed", leftClosed);
        ventClosed = false;
        ventAnim.SetBool("Closed", ventClosed);
        camsUp = false;
        camsAnim.SetBool("Open", camsUp);
        oxigen = 0;
        fanAnim.enabled = false;
    }
}
