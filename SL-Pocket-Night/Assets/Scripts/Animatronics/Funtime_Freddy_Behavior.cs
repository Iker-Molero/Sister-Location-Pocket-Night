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
    //Audios del enemigo.
    public AudioSource bonbonStep;
    public AudioSource doorBang;
    //Para detectar las puertas.
    public In_Night_Manager main;
    //Para activar el jumpscare.
    public Jumpscare activator;
    void Start()
    {
        //Extraemos la variable de dificultad y se la asignamos al script.
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[1];
        //Si la dificultad no es 0 iniciamos el loop.
        if (diff != 0)
        { StartCoroutine(DownTime()); }
        //Preparamos los audios.
        bonbonStep.volume = 0;
        bonbonStep.panStereo = 0;
        doorBang.volume = 1;
    }
    //Tiempo hasta que se activa el enemigo.
    IEnumerator DownTime()
    {
        bonbonStep.volume = 0;
        bonbonStep.panStereo = 0;
        yield return new WaitForSeconds(30 - diff);
        Initiate();
    }
    //Si elige el lado de ataque.
    void Initiate()
    {
        rand = Random.Range(0, 100);
        if (rand <= 50)
        { StartCoroutine(AttackLeft()); }
        else { StartCoroutine(AttackRight()); }
    }
    //Si la puerta correspondiente esta cerrada, se repite el ciclo, si no jumpscare.
    IEnumerator AttackLeft()
    {
        bonbonStep.volume = 1;
        bonbonStep.panStereo = -.75f;
        bonbonStep.Play();
        yield return new WaitForSeconds(5);
        if (main.leftClosed)
        { 
            doorBang.Play();
            StartCoroutine(DownTime()); }
        else
        { activator.ActivateJumpscare(1); }
    }
    //Si la puerta correspondiente esta cerrada, se repite el ciclo, si no jumpscare.
    IEnumerator AttackRight()
    {
        bonbonStep.volume = 1;
        bonbonStep.panStereo = .75f;
        bonbonStep.Play();
        yield return new WaitForSeconds(5);
        if (main.rightClosed)
        {
            doorBang.Play();
            StartCoroutine(DownTime()); }
        else
        { activator.ActivateJumpscare(1); }
    }
}
