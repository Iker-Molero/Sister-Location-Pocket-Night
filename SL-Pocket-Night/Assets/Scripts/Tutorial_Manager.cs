using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial_Manager : MonoBehaviour
{
    //Variable para el numero de frames por segundo.
    int frames = 20; //Para crear el efecto retro.
    //Variable para detectar el boton seleccionado.
    int selection;
    //Variable para el renderer de la seleccion.
    SpriteRenderer selectedRenderer;
    //Lista con los sprites seleccionables.
    public List<Sprite> pages = new List<Sprite>();
    void Start()
    {
        //Limitamos los fps del juego.
        Application.targetFrameRate = frames;
        //Asignamos la variable de seleccion a 0. (En este caso la pagina 1)
        selection = 0;
        //Asignamos la variable del renderer.
        selectedRenderer = GameObject.FindGameObjectWithTag("Pages").GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //Limitamos la seleccion a las 5 paginas.
        selection = Mathf.Clamp(selection, 0, 4);
        //Cambiamos la seleccion en base a los inputs.
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selection == 4)
            { selection = 0; }
            else { selection++; }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selection == 0)
            { selection = 4; }
            else { selection--; }
        }
        //Cambiamos los sprites del selector en base a la pagina seleccionada.
        selectedRenderer.sprite = pages[selection];
        //Volvemos al menu principal.
        if (Input.GetKeyDown(KeyCode.X))
        { SceneManager.LoadScene("Main_Menu"); }
    }
}
