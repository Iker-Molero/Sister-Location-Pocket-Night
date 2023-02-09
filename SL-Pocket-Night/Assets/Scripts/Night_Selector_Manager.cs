using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Night_Selector_Manager : MonoBehaviour
{
    int frames = 20;
    public int selection;
    SpriteRenderer selectedRenderer;
    public List<Sprite> presets = new List<Sprite>();
    public AudioSource select;
    public AudioSource pick;
    public SpriteRenderer starRenderer;
    public Sprite starObtained;
    public Sprite starNotObtained;
    public Saving_System saving;
    void Start()
    {
        Application.targetFrameRate = frames;
        selection = 0;
        selectedRenderer = GameObject.FindGameObjectWithTag("Presets").GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (PlayerPrefs.GetInt(selection.ToString()) == 1)
        { starRenderer.sprite = starObtained; }
        else { starRenderer.sprite = starNotObtained; }
        selection = Mathf.Clamp(selection, 0, 9);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selection == 9)
            { selection = 0; }
            else { selection++; }
            select.Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selection == 0)
            { selection = 9; }
            else { selection--; }
            select.Play();
        }
        selectedRenderer.sprite = presets[selection];
        if (Input.GetKeyDown(KeyCode.Z))
        { SceneManager.LoadScene("In_Night"); pick.Play(); }
        if (Input.GetKeyDown(KeyCode.X))
        { SceneManager.LoadScene("Main_Menu"); pick.Play(); }
    }
}
