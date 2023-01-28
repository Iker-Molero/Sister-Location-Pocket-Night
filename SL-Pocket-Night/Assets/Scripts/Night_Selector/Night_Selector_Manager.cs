using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Night_Selector_Manager : MonoBehaviour
{
    //Variable para el numero de frames por segundo
    int frames = 20; //Para crear el efecto retro
    //Variable para detectar el boton seleccionado
    public int selection;
    //Variable para el SpriteRenderer de la seleccion
    SpriteRenderer selectedRenderer;
    //Lista con los sprites seleccionables
    public List<Sprite> presets = new List<Sprite>();
    void Start()
    {
        //Limitamos los fps del juego
        Application.targetFrameRate = frames;
        //Asignamos la variable de seleccion a 1 (El boton start)
        selection = 0;
        //Asignamos las variables de los SpriteRenderers
        selectedRenderer = GameObject.FindGameObjectWithTag("Presets").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Limitamos la seleccion a los 3 botones
        selection = Mathf.Clamp(selection, 0, 9);
        //Cambiamos la seleccion en base a los inputs
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selection == 9)
            { selection = 0; }
            else { selection++; }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selection == 0)
            { selection = 9; }
            else { selection--; }
        }
        //Cambiamos los sprites del selector en base a preset seleccionado
        selectedRenderer.sprite = presets[selection];
        //Iniciamos la noche
        if (Input.GetKeyDown(KeyCode.Z))
        { SceneManager.LoadScene("Night"); }
        //Volvemos al menu
        if (Input.GetKeyDown(KeyCode.X))
        { SceneManager.LoadScene("Main_Menu"); }
    }
}
