using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loop : MonoBehaviour
{
    void Start()
    { StartCoroutine(WaitTime()); }
    IEnumerator WaitTime()
    { 
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Main_Menu");
    }
}
