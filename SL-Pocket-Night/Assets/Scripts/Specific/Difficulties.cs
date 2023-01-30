using UnityEngine;
using UnityEngine.SceneManagement;
public class Difficulties : MonoBehaviour
{
    //Referenciamos el manager de la escena.
    public Night_Selector_Manager main;
    //Variable con el numero de cada preset
    public int preset; 
    //Variables de cada enemigo;
    public int ballora;
    public int funtimeFreddy;
    public int yenndo;
    public int funtimeFoxy;
    public int bonnet;
    public int bidybab;
    public int electrobab;
    public int lolbit;
    public int minireenas;
    public int minireenas2;
    void Start()
    {
        //Evitamos que el objeto se destruya en la siguiente escena, para poder pasar las dificultades de cada personaje dentro de la noche.
        DontDestroyOnLoad(this);
        //Si se completa la noche, eliminamos el objeto para que no se acumulen.
        //Si se vuelve al menu principal, tambien eliminamos el objeto para que no se acumulen.
        if (SceneManager.GetActiveScene().name == "Post_Night" || SceneManager.GetActiveScene().name == "Main_Menu")
        { Destroy(this); }
    }
    void Update()
    {
        //Si estamos en la escena de seleccion de nivel.
        if (SceneManager.GetActiveScene().name == "Night_Selector")
        {
            //Dependiendo del preset seleccionado cambiamos las dificultades de cada personaje.
            switch (main.selection)
            {
                case 0: //Angry Ballet
                    preset = 0;
                    ballora = 20;
                    funtimeFreddy = 0;
                    yenndo = 0;
                    funtimeFoxy = 0;
                    bonnet = 0;
                    bidybab = 0;
                    electrobab = 0;
                    lolbit = 0;
                    minireenas = 20;
                    minireenas2 = 10;
                    break;
                case 1: //Freddy & Co.
                    preset = 1;
                    ballora = 0;
                    funtimeFreddy = 20;
                    yenndo = 10;
                    funtimeFoxy = 5;
                    bonnet = 10;
                    bidybab = 0;
                    electrobab = 0;
                    lolbit = 0;
                    minireenas = 0;
                    minireenas2 = 0;
                    break;
                case 2: //Funtime Frenzy
                    preset = 2;
                    ballora = 0;
                    funtimeFreddy = 20;
                    yenndo = 5;
                    funtimeFoxy = 20;
                    bonnet = 0;
                    bidybab = 0;
                    electrobab = 0;
                    lolbit = 10;
                    minireenas = 0;
                    minireenas2 = 0;
                    break;
                case 3: //Dolls, Attack!
                    preset = 3;
                    ballora = 0;
                    funtimeFreddy = 0;
                    yenndo = 0;
                    funtimeFoxy = 0;
                    bonnet = 10;
                    bidybab = 20;
                    electrobab = 20;
                    lolbit = 0;
                    minireenas = 20;
                    minireenas2 = 20;
                    break;
                case 4: //Girls' Night
                    preset = 4;
                    ballora = 20;
                    funtimeFreddy = 0;
                    yenndo = 0;
                    funtimeFoxy = 20;
                    bonnet = 20;
                    bidybab = 10;
                    electrobab = 0;
                    lolbit = 0;
                    minireenas = 10;
                    minireenas2 = 5;
                    break;
                case 5: //Weirdos
                    preset = 5;
                    ballora = 0;
                    funtimeFreddy = 0;
                    yenndo = 20;
                    funtimeFoxy = 0;
                    bonnet = 10;
                    bidybab = 0;
                    electrobab = 10;
                    lolbit = 20;
                    minireenas = 10;
                    minireenas2 = 0;
                    break;
                case 6: //Top Shelf
                    preset = 6;
                    ballora = 10;
                    funtimeFreddy = 20;
                    yenndo = 5;
                    funtimeFoxy = 10;
                    bonnet = 5;
                    bidybab = 0;
                    electrobab = 0;
                    lolbit = 0;
                    minireenas = 0;
                    minireenas2 = 0;
                    break;
                case 7: //Bottom Shelf
                    preset = 7;
                    ballora = 0;
                    funtimeFreddy = 0;
                    yenndo = 0;
                    funtimeFoxy = 0;
                    bonnet = 0;
                    bidybab = 20;
                    electrobab = 10;
                    lolbit = 10;
                    minireenas = 5;
                    minireenas2 = 10;
                    break;
                case 8: //Cupcake Challenge
                    preset = 8;
                    ballora = 10;
                    funtimeFreddy = 10;
                    yenndo = 0;
                    funtimeFoxy = 10;
                    bonnet = 10;
                    bidybab = 0;
                    electrobab = 10;
                    lolbit = 10;
                    minireenas = 10;
                    minireenas2 = 0;
                    break;
                case 9: //Golden Freddy
                    preset = 9;
                    ballora = 20;
                    funtimeFreddy = 20;
                    yenndo = 20;
                    funtimeFoxy = 20;
                    bonnet = 20;
                    bidybab = 20;
                    electrobab = 20;
                    lolbit = 20;
                    minireenas = 20;
                    minireenas2 = 20;
                    break;
            }
        }
    }
}
