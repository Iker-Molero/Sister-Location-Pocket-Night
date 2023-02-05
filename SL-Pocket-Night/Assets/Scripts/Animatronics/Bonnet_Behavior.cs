using System.Collections;
using UnityEngine;
public class Bonnet_Behavior : MonoBehaviour
{
    Difficulties preset;
    int diff;
    int rand;
    public In_Night_Manager main;
    public Jumpscare activator;
    bool bonnet;
    public SpriteRenderer bonnetRenderer;
    float timer;
    bool canActivate;
    public AudioSource bonnetAudio;
    void Start()
    {
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[4];
        timer = 0;
        canActivate = true;
    }
    void Update()
    {
        if (!canActivate) { timer += Time.deltaTime; }
        if (timer > 10) { timer = 0; canActivate = true; }
        if (!main.camsUp && Input.GetKeyDown(KeyCode.DownArrow) && diff != 0)
        {
            rand = Random.Range(0, 100);
            if (rand <= diff + 10 && canActivate)
            { StartCoroutine(Appear()); }
        }
        if (!main.camsUp && Input.GetKeyDown(KeyCode.Z) && bonnet) { bonnet = false; canActivate = false; bonnetAudio.Play(); }
        bonnetRenderer.enabled = bonnet;
    }
    IEnumerator Appear()
    {
        bonnet = true;
        yield return new WaitForSeconds(15 - (diff / 2));
        if (bonnet)
        { activator.ActivateJumpscare(4); }
    }
}
