using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jumpscare : MonoBehaviour
{
    public List<Sprite> jumpscareList = new List<Sprite>();
    public In_Night_Manager main;
    public SpriteRenderer jumpscareRender;
    public AudioListener mainListener;
    public void ActivateJumpscare(int index)
    {
        main.battery = 0;
        jumpscareRender.sprite = jumpscareList[index];
        StartCoroutine(ResetNight());
    }
    IEnumerator ResetNight()
    {
        mainListener.enabled = false;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main_Menu");
    }
}
