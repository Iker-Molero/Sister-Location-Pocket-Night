using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jumpscare : MonoBehaviour
{
    //Lista de jumpscares en este orden:
    // -Ballora
    // -Bon-Bon
    // -Yenndo
    // -Funtime-Foxy
    // -Bonnet
    // -Bidybab
    public List<Sprite> jumpscareList = new List<Sprite>();
    //Manager del juego para desactivar los controles al hacer un jumpscare.
    public In_Night_Manager main;
    //Variable para cambiar el sprite del jumpscare.
    public SpriteRenderer jumpscareRender;
    public void ActivateJumpscare(int index)
    {
        main.battery = 0;
        jumpscareRender.sprite = jumpscareList[index];
        StartCoroutine(ResetNight());
    }
    IEnumerator ResetNight()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main_Menu");
    }
}
