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
    //Para detectar las camaras.
    public In_Night_Manager main;
    //Para activar el jumpscare.
    public Jumpscare activator;
    //Sprite renderer para mostrar a Yenndo en la officina.
    public SpriteRenderer yenndoRenderer;
    bool yenndo;
    void Start()
    {
        //Extraemos la variable de dificultad y se la asignamos al script.
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.yenndo;
        yenndo = false;
    }
    void Update()
    {
        //Si se cierran las camaras, aparece Yenndo (Con una probabilidad).
        if (!main.camsUp && Input.GetKeyDown(KeyCode.DownArrow) && diff != 0)
        {
            Debug.Log("Cams Down");
            StartCoroutine(Activate());
        }
        if (main.camsUp)
        { yenndo = false; }
        yenndoRenderer.enabled = yenndo;
    }
    IEnumerator Activate()
    {
        rand = Random.Range(0, 100);
        if (diff == 5)
        {
            if (rand <= 10)
            {
                yenndo = true;
                main.oxigen -= 30;
                yield return new WaitForSeconds(6);
                if (!yenndo) yield break;
                if (yenndo)
                { activator.ActivateJumpscare(2); }
            }
        }
        else if (diff == 20)
        {
            if (rand <= diff)
            {
                yenndo = true;
                main.oxigen -= 30;
                yield return new WaitForSeconds(5);
                if (!yenndo) yield break;
                if (yenndo)
                { activator.ActivateJumpscare(2); }
            }
        }
        else
        {
            if (rand <= 35)
            {
                yenndo = true;
                main.oxigen -= 30;
                yield return new WaitForSeconds(3);
                if (!yenndo) yield break;
                if (yenndo)
                { activator.ActivateJumpscare(2); }
            }
        }
    }
}
