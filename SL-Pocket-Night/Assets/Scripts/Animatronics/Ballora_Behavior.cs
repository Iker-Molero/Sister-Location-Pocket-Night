using System.Collections;
using UnityEngine;
public class Ballora_Behavior : MonoBehaviour
{
    //Variable para extraer la variable de dificultad elegida.
    Difficulties preset;
    //Variable para manejar la dificultad del enemigo.
    int diff;
    //Variable para el componente aleatorio del juego.
    int rand;
    //Caja de musica de Ballora.
    public AudioSource balloraAudio;
    //Para detectar las puertas.
    public In_Night_Manager main;
    //Para activar el jumpscare.
    public Jumpscare activator;
    void Start()
    {
        //Extraemos la variable de dificultad y se la asignamos al script.
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[0];
        //Si la dificultad no es 0 iniciamos el loop.
        if (diff != 0)
        { StartCoroutine(DownTime()); }
        //Marcamos el volumen del audio a 0.
        balloraAudio.volume = 0;
        balloraAudio.panStereo = 0;
    }
    //Tiempo hasta que se activa el enemigo.
    IEnumerator DownTime()
    {
        balloraAudio.Stop();
        balloraAudio.volume = 0;
        balloraAudio.panStereo = 0;
        yield return new WaitForSeconds(35 - diff);
        Initiate();
    }
    //Ballora elige si atacar o fingir un ataque.
    void Initiate()
    {
        switch (diff)
        {
            case 10:
                rand = Random.Range(0, 100);
                if (rand <= 25)
                { FeintPickSide(); }
                else
                { AttackPickSide(); }
                break;
            case 20:
                rand = Random.Range(0, 100);
                if (rand <= 5)
                { FeintPickSide(); }
                else
                { AttackPickSide(); }
                break;
        }
    }
    //Si Ballora elige fingir un ataque, se elige el lado.
    void FeintPickSide()
    {
        rand = Random.Range(0, 100);
        if (rand <= 50)
        { StartCoroutine(FeintVolume(0)); }
        else
        { StartCoroutine(FeintVolume(1)); }
    }
    //Si Ballora elige atacar, se elige un lado.
    void AttackPickSide()
    {
        rand = Random.Range(0, 100);
        if (rand <= 50)
        { StartCoroutine(AttackVolume(0)); }
        else
        { StartCoroutine(AttackVolume(1)); }
    }
    //Una vez elegido el lado se aumenta el sonido de la musica de la manera adecuada
    IEnumerator FeintVolume(int side)
    {
        balloraAudio.Play();
        if (side == 0)
        { balloraAudio.panStereo = -.75f; }
        else
        { balloraAudio.panStereo = .75f; }
        while (balloraAudio.volume < 0.75f)
        {
            balloraAudio.volume += 0.005f;
            yield return null;
        }
        while (balloraAudio.volume > 0)
        {
            balloraAudio.volume -= 0.005f;
            yield return null;
        }
        //Despues de fingir el ataque reiniciamos el ciclo.
        { StartCoroutine(DownTime()); }
    }
    IEnumerator AttackVolume(int side)
    {
        balloraAudio.Play();
        //Si el lado elegido es la izquierda.
        if (side == 0)
        { balloraAudio.panStereo = -.75f; }
        else
        { balloraAudio.panStereo = .75f; }
        //Se aumenta el volumen hasta el maximo.
        while (balloraAudio.volume < 1)
        {
            balloraAudio.volume += 0.005f;
            yield return null;
        }
        //Si la puerta izquierda esta cerrada se disminuye el volumen hasta 0.
        if (side == 0) {
            if (main.leftClosed) {
                while (balloraAudio.volume > 0)
                {
                    balloraAudio.volume -= 0.005f;
                    yield return null;
                }
                //Despues se reinicia el ciclo.
                StartCoroutine(DownTime());
            }
            else {
                //Si no jumpsacre.
                balloraAudio.volume = 0;
                activator.ActivateJumpscare(0);
            }
            //Lo mismo si se elige la derecha.
        } else {
            if (main.rightClosed) {
                while (balloraAudio.volume > 0)
                {
                    balloraAudio.volume -= 0.01f;
                    yield return null;
                }
                StartCoroutine(DownTime());
            }
            else
            {
                balloraAudio.volume = 0;
                activator.ActivateJumpscare(0);
            }
        }
    }
}
