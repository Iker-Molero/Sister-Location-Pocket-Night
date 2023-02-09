using UnityEngine;
public class Saving_System : MonoBehaviour
{
    public int[] stars = new int[10];
    public Difficulties main;
    public void Save()
    {
        main = GameObject.FindGameObjectWithTag("Difficulties").GetComponent<Difficulties>(); 
        PlayerPrefs.SetInt(main.preset.ToString(), 1);
    }
    public void Read()
    {
        stars[0] = PlayerPrefs.GetInt("0");
        stars[1] = PlayerPrefs.GetInt("1");
        stars[2] = PlayerPrefs.GetInt("2");
        stars[3] = PlayerPrefs.GetInt("3");
        stars[4] = PlayerPrefs.GetInt("4");
        stars[5] = PlayerPrefs.GetInt("5");
        stars[6] = PlayerPrefs.GetInt("6");
        stars[7] = PlayerPrefs.GetInt("7");
        stars[8] = PlayerPrefs.GetInt("8");
        stars[9] = PlayerPrefs.GetInt("9");
    }
}
