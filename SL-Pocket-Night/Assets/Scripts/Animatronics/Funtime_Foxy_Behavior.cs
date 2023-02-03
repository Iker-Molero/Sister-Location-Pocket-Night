using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Funtime_Foxy_Behavior : MonoBehaviour
{
    Difficulties preset;
    int diff;
    public In_Night_Manager main;
    public Jumpscare activator;
    public float foxyRage = 0;
    bool alreadyOut;
    public AudioSource doorBang;
    public SpriteRenderer foxyRenderer;
    public List<Sprite> spriteList = new List<Sprite>();
    void Start()
    {
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[3];
        alreadyOut = false;
    }
    void Update()
    {
        if (!main.camsUp)
        { foxyRage += (diff * Time.deltaTime) / 10; }
        if (foxyRage < 50) { foxyRenderer.sprite = spriteList[1]; }
        if (foxyRage > 50 && foxyRage < 100) { foxyRenderer.sprite = spriteList[2]; }
        if (foxyRage >= 100 && !alreadyOut)
        {
            StartCoroutine(Attack());
            foxyRenderer.sprite = spriteList[3];
            alreadyOut = true;
        }
    }
    IEnumerator Attack()
    {
        Debug.Log("Attack");
        yield return new WaitForSeconds(7);
        if (main.rightClosed)
        {
            doorBang.Play();
            foxyRage = 0;
            alreadyOut = false;
        }
        else
        { activator.ActivateJumpscare(3); }
    }
}
