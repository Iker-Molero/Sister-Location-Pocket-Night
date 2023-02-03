using System.Collections;
using UnityEngine;
public class Ballora_Behavior : MonoBehaviour
{
    Difficulties preset;
    int diff;
    int rand;
    public AudioSource balloraAudio;
    public In_Night_Manager main;
    public Jumpscare activator;
    void Start()
    {
        preset = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>();
        diff = preset.selectedDifficulties[0];
        if (diff != 0)
        { StartCoroutine(DownTime()); }
        balloraAudio.volume = 0;
        balloraAudio.panStereo = 0;
    }
    IEnumerator DownTime()
    {
        balloraAudio.Stop();
        balloraAudio.volume = 0;
        balloraAudio.panStereo = 0;
        yield return new WaitForSeconds(35 - diff);
        Initiate();
    }
    void Initiate()
    {
        switch (diff)
        {
            case 10:
                rand = Random.Range(0, 100);
                if (rand <= 25)
                { FeintPickSide(); }
                else
                { AttackPickSide(); }
                break;
            case 20:
                rand = Random.Range(0, 100);
                if (rand <= 5)
                { FeintPickSide(); }
                else
                { AttackPickSide(); }
                break;
        }
    }
    void FeintPickSide()
    {
        rand = Random.Range(0, 100);
        if (rand <= 50)
        { StartCoroutine(FeintVolume(0)); }
        else
        { StartCoroutine(FeintVolume(1)); }
    }
    void AttackPickSide()
    {
        rand = Random.Range(0, 100);
        if (rand <= 50)
        { StartCoroutine(AttackVolume(0)); }
        else
        { StartCoroutine(AttackVolume(1)); }
    }
    IEnumerator FeintVolume(int side)
    {
        balloraAudio.Play();
        if (side == 0)
        { balloraAudio.panStereo = -.75f; }
        else
        { balloraAudio.panStereo = .75f; }
        while (balloraAudio.volume < 0.75f)
        {
            balloraAudio.volume += 0.005f;
            yield return null;
        }
        while (balloraAudio.volume > 0)
        {
            balloraAudio.volume -= 0.005f;
            yield return null;
        }
        { StartCoroutine(DownTime()); }
    }
    IEnumerator AttackVolume(int side)
    {
        balloraAudio.Play();
        if (side == 0)
        { balloraAudio.panStereo = -.75f; }
        else
        { balloraAudio.panStereo = .75f; }
        while (balloraAudio.volume < 1)
        {
            balloraAudio.volume += 0.005f;
            yield return null;
        }
        if (side == 0) {
            if (main.leftClosed) {
                while (balloraAudio.volume > 0)
                {
                    balloraAudio.volume -= 0.005f;
                    yield return null;
                }
                StartCoroutine(DownTime());
            }
            else {
                balloraAudio.volume = 0;
                activator.ActivateJumpscare(0);
            }
        } else {
            if (main.rightClosed) {
                while (balloraAudio.volume > 0)
                {
                    balloraAudio.volume -= 0.01f;
                    yield return null;
                }
                StartCoroutine(DownTime());
            }
            else
            {
                balloraAudio.volume = 0;
                activator.ActivateJumpscare(0);
            }
        }
    }
}
