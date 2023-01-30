using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loop : MonoBehaviour
{
    //En el incio de la escena iniciamos una co-rutina.
    void Start()
    { StartCoroutine(WaitTime()); }
    //La co-rutina espera 7 segundos y luego cambia la escena al menu principal.
    IEnumerator WaitTime()
    { 
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Main_Menu");
    }
}
