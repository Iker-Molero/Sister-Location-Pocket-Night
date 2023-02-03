using System.Collections;
using UnityEngine;
public class Bonnet_Behavior : MonoBehaviour
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
    //Para saber si bonnet ya esta activado.
    bool bonnet;
    //Sprite de Bonnet.
    public SpriteRenderer bonnetRenderer;
    //Espera entre activaciones.
    float timer;
    bool canActivate;
    void Start()
    {
        //Extraemos la variable de dificultad y se la asignamos al script.
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[4];
        timer = 0;
        canActivate = true;
    }
    void Update()
    {
        if (!canActivate) { timer += Time.deltaTime; }
        if (timer > 10) { timer = 0; canActivate = true; }
        if (!main.camsUp && Input.GetKeyDown(KeyCode.DownArrow) && diff != 0)
        {
            //Cams up
            rand = Random.Range(0, 100);
            if (rand <= diff + 10 && canActivate)
            { StartCoroutine(Appear()); }
        }
        if (!main.camsUp && Input.GetKeyDown(KeyCode.Z)) { bonnet = false; canActivate = false; }
        bonnetRenderer.enabled = bonnet;
    }
    IEnumerator Appear()
    {
        bonnet = true;
        yield return new WaitForSeconds(15 - (diff / 2));
        if (bonnet)
        { activator.ActivateJumpscare(4); }
    }
}
