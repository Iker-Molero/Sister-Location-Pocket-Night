using UnityEngine;
public class Monitor : MonoBehaviour
{
    //Referenciamos el manager de la escena.
    public In_Night_Manager main;
    //Referenciamos el HUD que se muestra en la pantalla del monitor.
    public GameObject screenHUD;
    void Start()
    { screenHUD.SetActive(false); }
    void ScreensUp()
    { screenHUD.SetActive(true); }
    void ScreensDown()
    { screenHUD.SetActive(false); }
}
