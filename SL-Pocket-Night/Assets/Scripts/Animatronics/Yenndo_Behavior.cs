using System.Collections;
using UnityEngine;
public class Yenndo_Behavior : MonoBehaviour
{
    Difficulties preset;
    int diff;
    int rand;
    public In_Night_Manager main;
    public Jumpscare activator;
    bool yenndo;
    public SpriteRenderer yenndoRenderer;
    float timer;
    bool canActivate;
    void Start()
    {
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[2];
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
        if (main.camsUp && yenndo) { yenndo = false; canActivate = false; }
        yenndoRenderer.enabled = yenndo;
    }
    IEnumerator Appear()
    {
        main.oxigen -= 30;
        yenndo = true;
        yield return new WaitForSeconds(15 - (diff / 2));
        if (yenndo)
        { activator.ActivateJumpscare(2); }
    }
}
