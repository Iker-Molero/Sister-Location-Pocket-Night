using System.Collections.Generic;
using UnityEngine;
public class HUD_Manager : MonoBehaviour
{
    //Variable del manager
    Door_Cam_Control usageDetector;
    //Variables generales del HUD
    int oxigen;
    int battery;
    int usage;
    public int hour;
    //Variables individuales de cada parte del HUD
    //Variables para el indicador de oxigeno y bateria
    public List<Sprite> numbersHUD = new List<Sprite>();
    //Variables para el indicador de uso
    SpriteRenderer usageIndicator;
    public List<Sprite> usageSprites = new List<Sprite>();
    //Variables para el indicador de la hora
    SpriteRenderer hourIndicator;
    public List<Sprite> hourSprites = new List<Sprite>();
    void Start()
    {
        //Asignamos la variable del manager
        usageDetector = GetComponent<Door_Cam_Control>();
        //Asignamos las variables de los objetos del HUD
        usageIndicator = GameObject.FindGameObjectWithTag("Usage_HUD").GetComponent<SpriteRenderer>();
        hourIndicator = GameObject.FindGameObjectWithTag("Hour_HUD").GetComponent<SpriteRenderer>();
        //Reiniciamos las variables del HUD
        oxigen = 100;
        battery = 100;
        usage = 0;
        hour = 0;
    }
    void Update()
    {
        //Limitamos la variable de oxigeno
        oxigen = Mathf.Clamp(oxigen ,0 ,100);
        //Limitamos la variable de bateria
        battery = Mathf.Clamp(battery, 0, 100);
        //Limitamos la variable de uso
        usage = Mathf.Clamp(usage, 0, 4);
        //Limitamos la variable de la hora
        hour = Mathf.Clamp(hour, 0, 6);
        //Actualizar la variable del oxigeno
        int oxigenHundreds = oxigen / 100;
        int oxigenTens = (oxigen - (oxigenHundreds * 100)) / 10;
        int oxigenUnits = oxigen - (oxigenHundreds * 100) - (oxigenTens * 10);
        SpriteRenderer oxigenUnitsIndicator = GameObject.FindGameObjectWithTag("Oxigen_Units").GetComponent<SpriteRenderer>();
        SpriteRenderer oxigenTensIndicator = GameObject.FindGameObjectWithTag("Oxigen_Tens").GetComponent<SpriteRenderer>();
        SpriteRenderer oxigenHundredsIndicator = GameObject.FindGameObjectWithTag("Oxigen_Hundreds").GetComponent<SpriteRenderer>();
        oxigenUnitsIndicator.sprite = numbersHUD[oxigenUnits];
        oxigenTensIndicator.sprite = numbersHUD[oxigenTens];
        oxigenHundredsIndicator.sprite = numbersHUD[oxigenHundreds];
        //Aumentar la opacidad del objeto blackout a medida que baja el oxigeno 
        SpriteRenderer blackoutRenderer = GameObject.FindGameObjectWithTag("Blackout").GetComponent<SpriteRenderer>();
        float blackoutAlpha = ((100f - oxigen) / 1.1f) / 100f;
        blackoutRenderer.color = new Color(255, 255, 255, blackoutAlpha);
        //Actualizar la variable de la bateria
        int batteryHundreds = battery / 100;
        int batteryTens = (battery - (batteryHundreds * 100)) / 10;
        int batteryUnits = battery - (batteryHundreds * 100) - (batteryTens * 10);
        SpriteRenderer batteryUnitsIndicator = GameObject.FindGameObjectWithTag("Battery_Units").GetComponent<SpriteRenderer>();
        SpriteRenderer batteryTensIndicator = GameObject.FindGameObjectWithTag("Battery_Tens").GetComponent<SpriteRenderer>();
        SpriteRenderer batteryHundredsIndicator = GameObject.FindGameObjectWithTag("Battery_Hundreds").GetComponent<SpriteRenderer>();
        batteryUnitsIndicator.sprite = numbersHUD[batteryUnits];
        batteryTensIndicator.sprite = numbersHUD[batteryTens];
        batteryHundredsIndicator.sprite = numbersHUD[batteryHundreds];
        //Actualizar la variable del uso
        usage = usageDetector.totalUsage;
        usageIndicator.sprite = usageSprites[usage];
        //Actualizar la variable de la hora
        hourIndicator.sprite = hourSprites[hour];
    }
}
