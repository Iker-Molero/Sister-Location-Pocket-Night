using System.Collections.Generic;
using UnityEngine;
public class Electrobab_Behavior : MonoBehaviour
{
    Difficulties preset;
    int diff;
    int rand;
    public In_Night_Manager main;
    bool active;
    public List<Sprite> electroSprites = new List<Sprite>();
    public SpriteRenderer electroRenderer;
    public GameObject electroAlert;
    public AudioSource deactivate;
    float timer = 0;
    bool alreadyRand;
    void Start()
    {
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[6];
        active = false;
        alreadyRand = false;
    }
    void Update()
    {
        if (!alreadyRand) { rand = Random.Range(57, 62); alreadyRand = true; }
        if (!active && diff != 0) { timer += Time.deltaTime; }
        if (timer > rand - diff) { active = true; main.electroActive = true; timer = 0; }
        if (main.camsUp && Input.GetKeyDown(KeyCode.Z) && active) { active = false; alreadyRand = false; main.electroActive = false; deactivate.Play(); }
        electroAlert.SetActive(main.electroActive);
        if (!active && diff != 0) { electroRenderer.sprite = electroSprites[1]; }
        if (active) { electroRenderer.sprite = electroSprites[2]; }
    }
}
