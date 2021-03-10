using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Transform ArrowEnd;
    public Camera Camera;

    public OnEvent OnInputExit;
    bool InputLock;
    private void OnMouseDrag()
    {
        if (!InputLock)
        {
            Vector3 InputMP = Input.mousePosition;
            InputMP.z = Camera.farClipPlane / 2;
            //Debug.Log(InputMP);
            Vector3 MousePos = Camera.ScreenToWorldPoint(InputMP);
            MousePos.x = (MousePos.x >= -4.5 && MousePos.x <= 4.5) ? MousePos.x : ((MousePos.x > -4.5) ? 4.5f : -4.5f);
            MousePos.z = (MousePos.z >= -9.5 && MousePos.z <= 9.5) ? MousePos.z : ((MousePos.z > -9.5) ? 9.5f : -9.5f);
            //Debug.Log(Input.mousePosition + " | " + MousePos);
            //Debug.Log(MousePos);
            ArrowEnd.position = new Vector3(MousePos.x, ArrowEnd.position.y, MousePos.z);
        }
        
    }

    private void OnMouseUp()
    {
        if (!InputLock)
        {
            OnInputExit();
        }

    }
    public void Paused(bool isPaused)
    {
        InputLock = isPaused;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
