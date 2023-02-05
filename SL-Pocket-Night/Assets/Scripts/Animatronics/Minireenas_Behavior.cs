using System.Collections.Generic;
using UnityEngine;
public class Minireenas_Behavior : MonoBehaviour
{
    Difficulties preset;
    int diff;
    int rand;
    public In_Night_Manager main;
    bool active;
    public List<Sprite> minireenasSprites = new List<Sprite>();
    public SpriteRenderer minireenasRenderer;
    public GameObject minireenasAlert;
    public AudioSource deactivate;
    float timer = 0;
    bool alreadyRand;
    void Start()
    {
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[8];
        active = false;
        alreadyRand = false;
    }
    void Update()
    {
        if (!alreadyRand) { rand = Random.Range(61, 69); alreadyRand = true; }
        if (!active && diff != 0) { timer += Time.deltaTime; }
        if (timer > rand - diff) { active = true; main.minireenasActive = true; timer = 0; }
        if (main.camsUp && Input.GetKeyDown(KeyCode.X) && active) { active = false; alreadyRand = false; main.minireenasActive = false; deactivate.Play(); }
        minireenasAlert.SetActive(main.minireenasActive);
        if (!active && diff != 0) { minireenasRenderer.sprite = minireenasSprites[1]; }
        if (active) { minireenasRenderer.sprite = minireenasSprites[2]; }
    }
}
