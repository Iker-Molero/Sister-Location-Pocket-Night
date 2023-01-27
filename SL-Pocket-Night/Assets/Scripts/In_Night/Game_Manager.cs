using UnityEngine;
public class Game_Manager : MonoBehaviour
{
    //Variable para el numero de frames por segundo
    int frames = 20; //Para crear el efecto retro
    //Variables para el temporizador de la noche
    HUD_Manager hourManager;
    float timer;
    int secondsPerHour; //Duracion de la hora en segundos
    void Start()
    {
        //Limitamos los fps del juego
        Application.targetFrameRate = frames;
        //Asignamos la variable del script encargado del HUD
        hourManager = GetComponent<HUD_Manager>();
        //Asignamos la duracion de la hora
        secondsPerHour = 60; //Igual que en el juego original
    }
    private void Update()
    {
        //Temporizador para sumar las horas al HUD mientras pasan
        timer += Time.deltaTime;
        if (timer >= secondsPerHour)
        {
            timer = 0;
            hourManager.hour++;
        }
        if (hourManager.hour == 6)
        { Debug.Log("End Night"); }
    }
}
