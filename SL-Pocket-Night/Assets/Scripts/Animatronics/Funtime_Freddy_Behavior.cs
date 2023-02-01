using System.Collections;
using UnityEngine;
public class Funtime_Freddy_Behavior : MonoBehaviour
{
    //Variable para extraer la variable de dificultad elegida.
    Difficulties preset;
    //Variable para manejar la dificultad del enemigo.
    int diff;
    //Variable para el componente aleatorio del juego.
    int rand;
    //Sonidos de Bon-Bon y Funtime Freddy.
    public AudioSource bonbonAudio;
    public AudioSource funtimefreddyAudio;
    //Para detectar las puertas.
    public In_Night_Manager main;
    //Para activar el jumpscare.
    public Jumpscare activator;
    void Start()
    {
        //Extraemos la variable de dificultad y se la asignamos al script.
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.funtimeFreddy;
        //Si la dificultad no es 0 iniciamos el loop.
        if (diff != 0)
        { StartCoroutine(DownTime()); }
        //Marcamos el volumen del audio a 0.
        bonbonAudio.volume = 0;
        bonbonAudio.panStereo = 0;
        funtimefreddyAudio.volume = 0;
        funtimefreddyAudio.panStereo = 0;
    }
    //Tiempo hasta que se activa el enemigo.
    IEnumerator DownTime()
    {
        bonbonAudio.volume = 0;
        bonbonAudio.panStereo = 0;
        funtimefreddyAudio.volume = 0;
        funtimefreddyAudio.panStereo = 0;
        yield return new WaitForSeconds(10);
        Initiate();
    }
    //Funtime Freddy elige atacar o distraerte. Si elige atacar.
    void Initiate()
    {
        switch (diff)
        {
            case 10:
                rand = Random.Range(0, 100);
                if (rand <= 10)
                {
                    funtimefreddyAudio.volume = 1;
                    funtimefreddyAudio.panStereo = 0;
                    funtimefreddyAudio.Play();
                    StartCoroutine(DownTime());
                }
                else
                {
                    rand = Random.Range(0, 100);
                    if (rand <= 50)
                    {
                        bonbonAudio.volume = 1;
                        bonbonAudio.panStereo = -.75f;
                        bonbonAudio.Play();
                        StartCoroutine(DoorCheck(0));

                    }
                    else
                    {
                        bonbonAudio.volume = 1;
                        bonbonAudio.panStereo = .75f;
                        bonbonAudio.Play();
                        StartCoroutine(DoorCheck(1));
                    }
                }
                break;
            case 20:
                rand = Random.Range(0, 100);
                if (rand <= 20)
                {
                    funtimefreddyAudio.volume = 1;
                    funtimefreddyAudio.panStereo = 0;
                    funtimefreddyAudio.Play();
                    StartCoroutine(DownTime());
                }
                else
                {
                    rand = Random.Range(0, 100);
                    if (rand <= 50)
                    {
                        bonbonAudio.volume = 1;
                        bonbonAudio.panStereo = -.75f;
                        bonbonAudio.Play();
                        StartCoroutine(DoorCheck(0));

                    }
                    else
                    {
                        bonbonAudio.volume = 1;
                        bonbonAudio.panStereo = .75f;
                        bonbonAudio.Play();
                        StartCoroutine(DoorCheck(1));
                    }
                }
                break;
        }
    }
    //Se comprueba si tienes cerrado el lado adecuado. Si no, jumpscare. Si si, se repite el ciclo.
    IEnumerator DoorCheck(int side)
    {
        yield return new WaitForSeconds(3);
        if (side == 0)
        {
            if (main.leftClosed)
            { StartCoroutine(DownTime()); }
            else
            { activator.ActivateJumpscare(1); }
        }
        else
        {
            if (main.rightClosed)
            { StartCoroutine(DownTime()); }
            else
            { activator.ActivateJumpscare(1); }
        }
    }
}
