using System.Collections;
using UnityEngine;
public class Yenndo_Behavior : MonoBehaviour
{
    //Variable para extraer la variable de dificultad elegida.
    Difficulties preset;
    //Variable para manejar la dificultad del enemigo.
    int diff;
    //Variable para el componente aleatorio del juego.
    int rand;
    //Para detectar las puertas.
    public In_Night_Manager main;
    //Para activar el jumpscare.
    public Jumpscare activator;
    //Para saber si yenndo ya esta activado.
    bool yenndo;
    //Sprite de Yenndo.
    public SpriteRenderer yenndoRenderer;
    void Start()
    {
        //Extraemos la variable de dificultad y se la asignamos al script.
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[2];
    }
    void Update()
    {
        if (!main.camsUp && Input.GetKeyDown(KeyCode.DownArrow) && diff != 0)
        {
            //Cams down
            rand = Random.Range(0, 100);
            if (rand <= diff + 10)
            { StartCoroutine(Appear()); }
        }
        if (main.camsUp) { yenndo = false; }
        yenndoRenderer.enabled = yenndo;
    }
    IEnumerator Appear()
    {
        main.oxigen -= 30;
        yenndo = true;
        yenndoRenderer.enabled = true;
        yield return new WaitForSeconds(12 - (diff / 2));
        if (yenndo)
        { activator.ActivateJumpscare(2); }
    }
}
