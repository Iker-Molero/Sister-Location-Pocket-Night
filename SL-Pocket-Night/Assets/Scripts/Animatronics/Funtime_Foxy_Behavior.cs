using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Funtime_Foxy_Behavior : MonoBehaviour
{
    //Variable para extraer la variable de dificultad elegida.
    Difficulties preset;
    //Variable para manejar la dificultad del enemigo.
    int diff;
    //Para detectar las puertas.
    public In_Night_Manager main;
    //Para activar el jumpscare.
    public Jumpscare activator;
    //Progreso de Foxy.
    public float foxyRage = 0;
    bool alreadyOut;
    //Ruido al parar el ataque.
    public AudioSource doorBang;
    //Spriterender de Foxy.
    public SpriteRenderer foxyRenderer;
    public List<Sprite> spriteList = new List<Sprite>();
    void Start()
    {
        //Extraemos la variable de dificultad y se la asignamos al script.
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[3];
        alreadyOut = false;
    }
    void Update()
    {
        if (!main.camsUp)
        { foxyRage += (diff * Time.deltaTime) / 10; }
        if (foxyRage < 50) { foxyRenderer.sprite = spriteList[1]; }
        if (foxyRage > 50 && foxyRage < 100) { foxyRenderer.sprite = spriteList[2]; }
        if (foxyRage >= 100 && !alreadyOut)
        {
            StartCoroutine(Attack());
            foxyRenderer.sprite = spriteList[3];
            alreadyOut = true;
        }
    }
    IEnumerator Attack()
    {
        Debug.Log("Attack");
        yield return new WaitForSeconds(7);
        if (main.rightClosed)
        {
            doorBang.Play();
            foxyRage = 0;
            alreadyOut = false;
        }
        else
        { activator.ActivateJumpscare(3); }
    }
}
