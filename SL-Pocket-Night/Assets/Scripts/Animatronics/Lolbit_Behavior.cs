using System.Collections.Generic;
using UnityEngine;
public class Lolbit_Behavior : MonoBehaviour
{
    Difficulties preset;
    int diff;
    public In_Night_Manager main;
    public Jumpscare activator;
    public float lolbitRage = 0;
    public AudioSource distraction;
    public List<Sprite> lolbitSprites = new List<Sprite>();
    public SpriteRenderer lolbitRenderer;
    bool active = false;
    public AudioSource deactivate;
    void Start()
    {
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[7];
    }
    void Update()
    {
        lolbitRage += (diff * Time.deltaTime) / 5.2f;
        if (lolbitRage > 33 && lolbitRage < 60) { lolbitRenderer.sprite = lolbitSprites[1]; }
        if (lolbitRage > 66 && lolbitRage < 100) { lolbitRenderer.sprite = lolbitSprites[2]; }
        if (lolbitRage > 100) { lolbitRenderer.sprite = lolbitSprites[3]; distraction.volume = 0.02f; active = true; }
        else { lolbitRenderer.sprite = lolbitSprites[0]; distraction.volume = 0.00f;}
        if (!main.camsUp && Input.GetKeyDown(KeyCode.X) && active) { lolbitRage = 0; active = false; deactivate.Play(); }
    }
}
