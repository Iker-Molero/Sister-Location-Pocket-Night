using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial_Manager : MonoBehaviour
{
    int frames = 20;
    int selection;
    SpriteRenderer selectedRenderer;
    public List<Sprite> pages = new List<Sprite>();
    public AudioSource select;
    public AudioSource pick;
    void Start()
    {
        Application.targetFrameRate = frames;
        selection = 0;
        selectedRenderer = GameObject.FindGameObjectWithTag("Pages").GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        selection = Mathf.Clamp(selection, 0, 4);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            select.Play();
            if (selection == 4)
            { selection = 0; }
            else { selection++; }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            select.Play();
            if (selection == 0)
            { selection = 4; }
            else { selection--; }
        }
        selectedRenderer.sprite = pages[selection];
        if (Input.GetKeyDown(KeyCode.X))
        { SceneManager.LoadScene("Main_Menu"); pick.Play(); }
    }
}
