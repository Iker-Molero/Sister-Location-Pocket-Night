using System.Collections;
using UnityEngine;
public class Bidybab_Behavior : MonoBehaviour
{
    Difficulties preset;
    int diff;
    int rand;
    public AudioSource bidyStep;
    public AudioSource doorBang;
    public In_Night_Manager main;
    public Jumpscare activator;
    void Start()
    {
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[5];
        if (diff != 0)
        { StartCoroutine(DownTime()); }
    }
    IEnumerator DownTime()
    {
        rand = Random.Range(20, 32);
        yield return new WaitForSeconds(27 - diff + rand);
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        bidyStep.Play();
        yield return new WaitForSeconds(3);
        if (main.ventClosed)
        {
            doorBang.Play();
            StartCoroutine(DownTime());
        }
        else
        { activator.ActivateJumpscare(5); }
    }
}
