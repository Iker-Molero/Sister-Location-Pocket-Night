using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Manager : MonoBehaviour
{
    int frames = 20;
    int selection;
    SpriteRenderer startRenderer;
    SpriteRenderer howRenderer;
    SpriteRenderer exitRenderer;
    public List<Sprite> startSprites = new List<Sprite>();
    public List<Sprite> howSprites = new List<Sprite>();
    public List<Sprite> exitSprites = new List<Sprite>();
    public AudioSource select;
    public AudioSource pick;
    public Saving_System saving;
    public List<GameObject> starsInMenu = new List<GameObject>(); 
    void Start()
    {
        Application.targetFrameRate = frames;
        selection = 1;
        startRenderer = GameObject.FindGameObjectWithTag("Main_Start").GetComponent<SpriteRenderer>();
        howRenderer = GameObject.FindGameObjectWithTag("Main_How").GetComponent<SpriteRenderer>();
        exitRenderer = GameObject.FindGameObjectWithTag("Main_Exit").GetComponent<SpriteRenderer>();
        saving.Read();
        for (int i = 0; i < saving.stars.Length; i++)
        {
            if (saving.stars[i] == 1)
            {
                starsInMenu[i].SetActive(true);
            }
        }
    }
    void Update()
    {
        selection = Mathf.Clamp(selection, 1, 3);
        if (Input.GetKeyDown(KeyCode.DownArrow))
        { selection++; select.Play(); }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { selection--; select.Play(); }
        switch (selection)
        {
            case 1:
                startRenderer.sprite = startSprites[1];
                howRenderer.sprite = howSprites[0];
                exitRenderer.sprite = exitSprites[0];
                break;
            case 2:
                startRenderer.sprite = startSprites[0];
                howRenderer.sprite = howSprites[1];
                exitRenderer.sprite = exitSprites[0];
                break;
            case 3:
                startRenderer.sprite = startSprites[0];
                howRenderer.sprite = howSprites[0];
                exitRenderer.sprite = exitSprites[1];
                break;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            pick.Play();
            switch (selection)
            {
                case 1:
                    SceneManager.LoadScene("Night_Selector");
                    break;
                case 2:
                    SceneManager.LoadScene("Tutorial");
                    break;
                case 3:
                    Application.Quit();
                    break;
            }
        }
    }
}
