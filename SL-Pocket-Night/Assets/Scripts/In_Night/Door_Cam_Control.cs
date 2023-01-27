using UnityEngine;
public class Door_Cam_Control : MonoBehaviour
{
    //Variables para las puertas
    bool ventClosed = false;
    bool rightClosed = false;
    bool leftClosed = false;
    //Variables para las animaciones de las puertas
    Animator ventAnim;
    Animator rightAnim;
    Animator leftAnim;
    //Variable para las camaras
    bool camsUp = false;
    //Variable para las animaciones de las camaras
    Animator camsAnim;
    //Variables para detectar el uso de bateria
    public int totalUsage;
    void Start()
    {
        //Asignamos las variables de los animadores
        ventAnim = GameObject.FindGameObjectWithTag("Vent_Door").GetComponent<Animator>();
        rightAnim = GameObject.FindGameObjectWithTag("Right_Door").GetComponent<Animator>();
        leftAnim = GameObject.FindGameObjectWithTag("Left_Door").GetComponent<Animator>();
        camsAnim = GameObject.FindGameObjectWithTag("Cams").GetComponent<Animator>();
        //Asignamos el valor de las puertas a las variables de los animadores
        ventAnim.SetBool("Closed", ventClosed);
        rightAnim.SetBool("Closed", rightClosed);
        leftAnim.SetBool("Closed", leftClosed);
        camsAnim.SetBool("Open", camsUp);
    }
    void Update()
    {
        //Si se pulsan las teclas necesarias, hacer la accion correspondiente.
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            rightClosed = !rightClosed;
            rightAnim.SetBool("Closed", rightClosed);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            leftClosed = !leftClosed;
            leftAnim.SetBool("Closed", leftClosed);
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            ventClosed = !ventClosed;
            ventAnim.SetBool("Closed", ventClosed);
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            camsUp = !camsUp;
            camsAnim.SetBool("Open", camsUp);
        }
        //Detectar el uso de bateria
        int rightUsage = rightClosed ? 1 : 0;
        int leftUsage = leftClosed ? 1 : 0;
        int ventUsage = ventClosed ? 1 : 0;
        int camsUsage = camsUp ? 1 : 0;
        totalUsage = rightUsage + leftUsage + ventUsage + camsUsage;
    }
}
