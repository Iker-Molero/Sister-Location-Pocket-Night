using System.Collections.Generic;
using UnityEngine;
public class Main_Menu_Manager : MonoBehaviour
{
    //Variable para el numero de frames por segundo
    int frames = 20; //Para crear el efecto retro
    //Variable para detectar el boton seleccionado
    int selection;
    //Variables de los SpriteRenderers
    SpriteRenderer startRenderer;
    SpriteRenderer howRenderer;
    SpriteRenderer exitRenderer;
    //Listas con los sprites de cada boton
    public List<Sprite> startSprites = new List<Sprite>();
    public List<Sprite> howSprites = new List<Sprite>();
    public List<Sprite> exitSprites = new List<Sprite>();
    void Start()
    {
        //Limitamos los fps del juego
        Application.targetFrameRate = frames;
        //Asignamos la variable de seleccion a 1 (El boton start)
        selection = 1;
        //Asignamos las variables de los SpriteRenderers
        startRenderer = GameObject.FindGameObjectWithTag("Main_Start").GetComponent<SpriteRenderer>();
        howRenderer = GameObject.FindGameObjectWithTag("Main_How").GetComponent<SpriteRenderer>();
        exitRenderer = GameObject.FindGameObjectWithTag("Main_Exit").GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //Limitamos la seleccion a los 3 botones
        selection = Mathf.Clamp(selection, 1, 3);
        //Cambiamos la seleccion en base a los inputs
        if (Input.GetKeyDown(KeyCode.DownArrow))
        { selection++; }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { selection--; }
        //Cambiamos el sprite de los botones del menu en base al numero seleccionado
        switch (selection)
        {
            case 1:
                startRenderer.sprite = startSprites[1];
                howRenderer.sprite = howSprites[0];
                exitRenderer.sprite = exitSprites[0];
                break;
            case 2:
                startRenderer.sprite = startSprites[0];
                howRenderer.sprite = howSprites[1];
                exitRenderer.sprite = exitSprites[0];
                break;
            case 3:
                startRenderer.sprite = startSprites[0];
                howRenderer.sprite = howSprites[0];
                exitRenderer.sprite = exitSprites[1];
                break;
        }
    }
}
