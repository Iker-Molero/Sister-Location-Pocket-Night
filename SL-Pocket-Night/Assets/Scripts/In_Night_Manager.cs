using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class In_Night_Manager : MonoBehaviour
{
    //Variable para el numero de frames por segundo.
    int frames = 20; //Para crear el efecto retro.
    //Variables generales del HUD.
    int actualHour;
    public int oxigen;
    float oxigenTimer;
    public int battery;
    float batteryTimer;
    int usage;
    //Variables para los sprites de cada apartado del HUD.
    [Header("Listas de sprites")]
    //Oxigeno y bateria.
    public List<Sprite> numbersHUD = new List<Sprite>();
    //Indicador de uso.
    SpriteRenderer usageRenderer;
    public List<Sprite> usageSprites = new List<Sprite>();
    //Reloj de la noche.
    SpriteRenderer hourRenderer;
    public List<Sprite> hourSprites = new List<Sprite>();
    //Variables para el temporizador de la noche.
    float timer;
    int secondsPerHour; //Duracion de la noche en segundos.
    //Variables para las puertas.
    public bool rightClosed;
    public bool leftClosed;
    public bool ventClosed;
    //Variables para los animadores de las puertas.
    Animator rightAnim;
    Animator leftAnim;
    Animator ventAnim;
    //Variable para la tablet (a.k.a "camaras")
    public bool camsUp;
    //Variable para el animador de la tablet.
    Animator camsAnim;
    //Variable para bloquear los controles si la bateria llega a 0.
    bool havePower;
    //Variable del animador del ventilador.
    Animator fanAnim;
    void Start()
    {
        //Limitamos los fps de la escena.
        Application.targetFrameRate = frames;
        //Asignamos los renderers de uso y hora.
        usageRenderer = GameObject.FindGameObjectWithTag("Usage_HUD").GetComponent<SpriteRenderer>();
        hourRenderer = GameObject.FindGameObjectWithTag("Hour_HUD").GetComponent<SpriteRenderer>();
        //Reiniciamos las variables del HUD al inicio de la hora.
        oxigen = 100;
        oxigenTimer = 0;
        battery = 100;
        batteryTimer = 0;
        usage = 0;
        actualHour = 0;
        //Asignamos la duracion de la hora.
        secondsPerHour = 60; //Igual que en el juego original.
        //Reiniciamos las variables de las puertas y la tablet.
        rightClosed = false;
        leftClosed = false;
        ventClosed = false;
        camsUp = false;
        //Asignamos las variables de los animadores de las puertas y las camaras.
        rightAnim = GameObject.FindGameObjectWithTag("Right_Door").GetComponent<Animator>();
        leftAnim = GameObject.FindGameObjectWithTag("Left_Door").GetComponent<Animator>();
        ventAnim = GameObject.FindGameObjectWithTag("Vent_Door").GetComponent<Animator>();
        camsAnim = GameObject.FindGameObjectWithTag("Cams").GetComponent<Animator>();
        //Asignamos el valor de las puertas y la tablet a sus animadores correspondientes.
        rightAnim.SetBool("Closed", rightClosed);
        leftAnim.SetBool("Closed", leftClosed);
        ventAnim.SetBool("Closed", ventClosed);
        camsAnim.SetBool("Open", camsUp);
        //Reiniciamos la variable que comprueba si tenemos bateria.
        havePower = true;
        //Asignamos la variable del animador del ventilador.
        fanAnim = GameObject.FindGameObjectWithTag("Fan").GetComponent<Animator>();
    }
    void Update()
    {
        //Limitamos cada variable
        oxigen = Mathf.Clamp(oxigen, 0, 100);
        battery = Mathf.Clamp(battery, 0, 100);
        usage = Mathf.Clamp(usage, 0, 4);
        actualHour = Mathf.Clamp(actualHour, 0, 6);
        //Actualizamos la variable del oxigeno.
        // --Primero dividimos la variable entre sus tres digitos--
        int oxigenHundreds = oxigen / 100;
        int oxigenTens = (oxigen - (oxigenHundreds * 100)) / 10;
        int oxigenUnits = oxigen - (oxigenHundreds * 100) - (oxigenTens * 10);
        // --Despues referenciamos sus renderers--
        SpriteRenderer oxigenHundredsIndicator = GameObject.FindGameObjectWithTag("Oxigen_Hundreds").GetComponent<SpriteRenderer>();
        SpriteRenderer oxigenTensIndicator = GameObject.FindGameObjectWithTag("Oxigen_Tens").GetComponent<SpriteRenderer>();
        SpriteRenderer oxigenUnitsIndicator = GameObject.FindGameObjectWithTag("Oxigen_Units").GetComponent<SpriteRenderer>();
        // --Por ultimo cambiamos los numeros del HUD en base a cada digito antes dividido--
        oxigenHundredsIndicator.sprite = numbersHUD[oxigenHundreds];
        oxigenTensIndicator.sprite = numbersHUD[oxigenTens];
        oxigenUnitsIndicator.sprite = numbersHUD[oxigenUnits];
        // --Tambien aumentamos la opacidad del objeto blackout a medida que disminuye el oxigeno.
        SpriteRenderer blackoutRenderer = GameObject.FindGameObjectWithTag("Blackout").GetComponent<SpriteRenderer>();
        float blackoutAlpha = ((100f - oxigen) / 1.1f) / 100f;
        blackoutRenderer.color = new Color(255, 255, 255, blackoutAlpha);
        //Actualizamos la variable de la bateria. (Es igual que el oxigeno)
        // --Primero dividimos la variable entre sus tres digitos--
        int batteryHundreds = battery / 100;
        int batteryTens = (battery - (batteryHundreds * 100)) / 10;
        int batteryUnits = battery - (batteryHundreds * 100) - (batteryTens * 10);
        // --Despues referenciamos sus renderers--
        SpriteRenderer batteryHundredsIndicator = GameObject.FindGameObjectWithTag("Battery_Hundreds").GetComponent<SpriteRenderer>();
        SpriteRenderer batteryTensIndicator = GameObject.FindGameObjectWithTag("Battery_Tens").GetComponent<SpriteRenderer>();
        SpriteRenderer batteryUnitsIndicator = GameObject.FindGameObjectWithTag("Battery_Units").GetComponent<SpriteRenderer>();
        // --Por ultimos cambiamos los numeros de HUD en base a cada digito antes dividido--
        batteryHundredsIndicator.sprite = numbersHUD[batteryHundreds];
        batteryTensIndicator.sprite = numbersHUD[batteryTens];
        batteryUnitsIndicator.sprite = numbersHUD[batteryUnits];
        //Actualizamos la variable de uso.
        // --Primero creamos unas variables para convertir las variables booleanas en numeros--
        int rightUsage = rightClosed ? 1 : 0;
        int leftUsage = leftClosed ? 1 : 0;
        int ventUsage = ventClosed ? 1 : 0;
        int camsUsage = camsUp ? 1 : 0;
        // --Luego las sumamos todas (+ 1 extra)--
        usage = rightUsage + leftUsage + ventUsage + camsUsage;
        // --Por ultimo actualizamos el medidor en el HUD.
        usageRenderer.sprite = usageSprites[usage];
        //Actualizamos la variables de la hora.
        hourRenderer.sprite = hourSprites[actualHour];
        //Temporizador para sumar las horas mientras pasan.
        timer += Time.deltaTime;
        if (timer >= secondsPerHour)
        {
            timer = 0;
            actualHour++;
        }
        //Cuando la hora llegue a las 6 completamos la noche.
        if (actualHour == 6)
        { SceneManager.LoadScene("Post_Night"); }
        //Si se pulsan las teclas necesarias, hacer la accion correspondiente (Solo si la bateria es superior a 0).
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
        //Disminuimos la carga de la bateria en base al uso.
        // --Para ello usamos un temporizador que se reinicia cada X segundos--
        // --Cuando el temporizador se reinicie le restamos a la bateria la cantidad que se este consumiendo--
        batteryTimer += Time.deltaTime;
        if (batteryTimer >= 5)
        {
            batteryTimer = 0;
            battery -= (usage + 1); //Hay que sumarle uno al uso ya que el primer valor de uso siempre es 0.
        }
        //Si la bateria llega a 0, desactivamos los controles y bajamos el oxigeno a 0.
        if (battery == 0)
        { NoPower(); }
        //Tambien aumentamos la carga de oxigeno, al contrario que la bateria.
        oxigenTimer += Time.deltaTime;
        if (oxigenTimer >= 1)
        {
            oxigenTimer = 0;
            oxigen++;
        }
    }

    void NoPower()
    {
        //Bloqueamos los controles del usuario.
        havePower = false;
        //Abrimos todas las puertas.
        rightClosed = false;
        rightAnim.SetBool("Closed", rightClosed);
        leftClosed = false;
        leftAnim.SetBool("Closed", leftClosed);
        ventClosed = false;
        ventAnim.SetBool("Closed", ventClosed);
        //Cerramos las camaras.
        camsUp = false;
        camsAnim.SetBool("Open", camsUp);
        //Bajamos el oxigeno a 0.
        oxigen = 0;
        //Detenemos el ventilador.
        fanAnim.enabled = false;
    }
}
