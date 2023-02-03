using System.Collections;
using UnityEngine;
public class Funtime_Freddy_Behavior : MonoBehaviour
{
    Difficulties preset;
    int diff;
    int rand;
    public AudioSource bonbonStep;
    public AudioSource doorBang;
    public In_Night_Manager main;
    public Jumpscare activator;
    void Start()
    {
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[1];
        if (diff != 0)
        { StartCoroutine(DownTime()); }
        bonbonStep.volume = 0;
        bonbonStep.panStereo = 0;
        doorBang.volume = 1;
    }
    IEnumerator DownTime()
    {
        bonbonStep.volume = 0;
        bonbonStep.panStereo = 0;
        yield return new WaitForSeconds(30 - diff);
        Initiate();
    }
    void Initiate()
    {
        rand = Random.Range(0, 100);
        if (rand <= 50)
        { StartCoroutine(AttackLeft()); }
        else { StartCoroutine(AttackRight()); }
    }
    IEnumerator AttackLeft()
    {
        bonbonStep.volume = 1;
        bonbonStep.panStereo = -.75f;
        bonbonStep.Play();
        yield return new WaitForSeconds(5);
        if (main.leftClosed)
        { 
            doorBang.Play();
            StartCoroutine(DownTime()); }
        else
        { activator.ActivateJumpscare(1); }
    }
    IEnumerator AttackRight()
    {
        bonbonStep.volume = 1;
        bonbonStep.panStereo = .75f;
        bonbonStep.Play();
        yield return new WaitForSeconds(5);
        if (main.rightClosed)
        {
            doorBang.Play();
            StartCoroutine(DownTime()); }
        else
        { activator.ActivateJumpscare(1); }
    }
}
