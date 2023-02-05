using UnityEngine;
using System.Collections.Generic;
public class Minireenas_2_Behavior : MonoBehaviour
{
    Difficulties preset;
    int diff;
    public SpriteRenderer minireenas2Renderer;
    public List<Sprite> minireenas2Sprites = new List<Sprite>();
    void Start()
    {
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[9];
        if (diff == 0) { minireenas2Renderer.sprite = minireenas2Sprites[0]; }
        else if (diff == 5) { minireenas2Renderer.sprite = minireenas2Sprites[1]; }
        else if (diff == 10) { minireenas2Renderer.sprite = minireenas2Sprites[2]; }
        else { minireenas2Renderer.sprite = minireenas2Sprites[3]; }
    }
}
