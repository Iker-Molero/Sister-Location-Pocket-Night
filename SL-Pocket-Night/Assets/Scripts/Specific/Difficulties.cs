using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Difficulties : MonoBehaviour
{
    //Referenciamos el manager de la escena.
    public Night_Selector_Manager main;
    //Variable con el numero de cada preset
    public int preset;
    //Un Array con variables de cada enemigo;
    public List<int> selectedDifficulties = new List<int>();
    void Start()
    {
        //Evitamos que el objeto se destruya en la siguiente escena, para poder pasar las dificultades de cada personaje dentro de la noche.
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        //Si se completa la noche, eliminamos el objeto para que no se acumulen.
        //Si se vuelve al menu principal, tambien eliminamos el objeto para que no se acumulen.
        if (SceneManager.GetActiveScene().name == "Post_Night" || SceneManager.GetActiveScene().name == "Main_Menu")
        { Destroy(gameObject); }
        //Si estamos en la escena de seleccion de nivel.
        if (SceneManager.GetActiveScene().name == "Night_Selector")
        {
            //Dependiendo del preset seleccionado cambiamos las dificultades de cada personaje.
            switch (main.selection)
            {
                case 0: //Angry Ballet
                    preset = 0;
                    selectedDifficulties[0] = 20;
                    selectedDifficulties[1] = 0;
                    selectedDifficulties[2] = 0;
                    selectedDifficulties[3] = 0;
                    selectedDifficulties[4] = 0;
                    selectedDifficulties[5] = 0;
                    selectedDifficulties[6] = 0;
                    selectedDifficulties[7] = 0;
                    selectedDifficulties[8] = 20;
                    selectedDifficulties[9] = 10;
                    break;
                case 1: //Freddy & Co.
                    preset = 1;
                    selectedDifficulties[0] = 0;
                    selectedDifficulties[1] = 20;
                    selectedDifficulties[2] = 10;
                    selectedDifficulties[3] = 5;
                    selectedDifficulties[4] = 10;
                    selectedDifficulties[5] = 0;
                    selectedDifficulties[6] = 0;
                    selectedDifficulties[7] = 0;
                    selectedDifficulties[8] = 0;
                    selectedDifficulties[9] = 0;
                    break;
                case 2: //Funtime Frenzy
                    preset = 2;
                    selectedDifficulties[0] = 0;
                    selectedDifficulties[1] = 20;
                    selectedDifficulties[2] = 5;
                    selectedDifficulties[3] = 20;
                    selectedDifficulties[4] = 0;
                    selectedDifficulties[5] = 0;
                    selectedDifficulties[6] = 0;
                    selectedDifficulties[7] = 10;
                    selectedDifficulties[8] = 0;
                    selectedDifficulties[9] = 0;
                    break;
                case 3: //Dolls, Attack!
                    preset = 3;
                    selectedDifficulties[0] = 0;
                    selectedDifficulties[1] = 0;
                    selectedDifficulties[2] = 0;
                    selectedDifficulties[3] = 0;
                    selectedDifficulties[4] = 10;
                    selectedDifficulties[5] = 20;
                    selectedDifficulties[6] = 20;
                    selectedDifficulties[7] = 0;
                    selectedDifficulties[8] = 20;
                    selectedDifficulties[9] = 20;
                    break;
                case 4: //Girls' Night
                    preset = 4;
                    selectedDifficulties[0] = 20;
                    selectedDifficulties[1] = 0;
                    selectedDifficulties[2] = 0;
                    selectedDifficulties[3] = 20;
                    selectedDifficulties[4] = 20;
                    selectedDifficulties[5] = 10;
                    selectedDifficulties[6] = 0;
                    selectedDifficulties[7] = 0;
                    selectedDifficulties[8] = 10;
                    selectedDifficulties[9] = 5;
                    break;
                case 5: //Weirdos
                    preset = 5;
                    selectedDifficulties[0] = 0;
                    selectedDifficulties[1] = 0;
                    selectedDifficulties[2] = 20;
                    selectedDifficulties[3] = 0;
                    selectedDifficulties[4] = 10;
                    selectedDifficulties[5] = 0;
                    selectedDifficulties[6] = 10;
                    selectedDifficulties[7] = 20;
                    selectedDifficulties[8] = 10;
                    selectedDifficulties[9] = 0;
                    break;
                case 6: //Top Shelf
                    preset = 6;
                    selectedDifficulties[0] = 10;
                    selectedDifficulties[1] = 20;
                    selectedDifficulties[2] = 5;
                    selectedDifficulties[3] = 10;
                    selectedDifficulties[4] = 5;
                    selectedDifficulties[5] = 0;
                    selectedDifficulties[6] = 0;
                    selectedDifficulties[7] = 0;
                    selectedDifficulties[8] = 0;
                    selectedDifficulties[9] = 0;
                    break;
                case 7: //Bottom Shelf
                    preset = 7;
                    selectedDifficulties[0] = 0;
                    selectedDifficulties[1] = 0;
                    selectedDifficulties[2] = 0;
                    selectedDifficulties[3] = 0;
                    selectedDifficulties[4] = 0;
                    selectedDifficulties[5] = 20;
                    selectedDifficulties[6] = 10;
                    selectedDifficulties[7] = 10;
                    selectedDifficulties[8] = 5;
                    selectedDifficulties[9] = 10;
                    break;
                case 8: //Cupcake Challenge
                    preset = 8;
                    selectedDifficulties[0] = 10;
                    selectedDifficulties[1] = 10;
                    selectedDifficulties[2] = 0;
                    selectedDifficulties[3] = 10;
                    selectedDifficulties[4] = 10;
                    selectedDifficulties[5] = 0;
                    selectedDifficulties[6] = 10;
                    selectedDifficulties[7] = 10;
                    selectedDifficulties[8] = 10;
                    selectedDifficulties[9] = 0;
                    break;
                case 9: //Golden Freddy
                    preset = 9;
                    selectedDifficulties[0] = 20;
                    selectedDifficulties[1] = 20;
                    selectedDifficulties[2] = 20;
                    selectedDifficulties[3] = 20;
                    selectedDifficulties[4] = 20;
                    selectedDifficulties[5] = 20;
                    selectedDifficulties[6] = 20;
                    selectedDifficulties[7] = 20;
                    selectedDifficulties[8] = 20;
                    selectedDifficulties[9] = 20;
                    break;
            }
        }
    }
}
