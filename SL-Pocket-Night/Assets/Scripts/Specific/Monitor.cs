using UnityEngine;
public class Monitor : MonoBehaviour
{
    public In_Night_Manager main;
    public GameObject screenHUD;
    void Start()
    { screenHUD.SetActive(false); }
    void ScreensUp()
    { screenHUD.SetActive(true); }
    void ScreensDown()
    { screenHUD.SetActive(false); }
}
