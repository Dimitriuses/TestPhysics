using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Transform ArrowEnd;
    public Transform Arrow;
    public Transform Ball;
    public Camera Camera;
    public PlaceService PlaceService;
    public LineRenderer Line;

    //public OnEvent OnInputExit;
    public OnEventWithParameters OnInputExit;

    float ArrowScale;
    bool InputLock;
    private void OnMouseDrag()
    {
        if (!InputLock)
        {
            float MaxX = PlaceService.GetMaxX();
            float MinX = PlaceService.GetMinX();
            float MaxY = PlaceService.GetMaxY();
            float MinY = PlaceService.GetMinY();
            Vector3 InputMP = Input.mousePosition;
            InputMP.z = Camera.farClipPlane;
            Vector3 tmpPos = Camera.ScreenToWorldPoint(InputMP);
            //InputMP.z = PlaceService.NextDistance(tmpPos);
            Line.SetPosition(1, tmpPos);
            //Line.SetPosition(2, new Vector3(tmpPos.x, 0, tmpPos.z));
            //InputMP.z = PlaceService.GetInputZ();
            //Debug.Log(InputMP + " " + MaxX + " " + MinX + " " + MaxY + " " + MinY);
            //Debug.Log(InputMP);
            Vector3 MousePos = PlaceService.GetNextPos(tmpPos); //Camera.ScreenToWorldPoint(InputMP);
            MousePos.x = (MousePos.x >= MinX && MousePos.x <= MaxX) ? MousePos.x : ((MousePos.x > MinX) ? MaxX : MinX);
            //MousePos.z = MousePos.z - PlaceService.GetMoveX(MousePos.y);
            MousePos.z = (MousePos.z >= MinY && MousePos.z <= MaxY) ? MousePos.z : ((MousePos.z > MinY) ? MaxY : MinY);


            //Debug.Log(Input.mousePosition + " | " + MousePos);
            //Debug.Log(MousePos);
            ArrowEnd.position = new Vector3(MousePos.x, ArrowEnd.position.y, MousePos.z);

            ArrowSetActive(true);
            Ball.LookAt(ArrowEnd);
            float tmpDistance = Vector3.Distance(ArrowEnd.position, transform.position);
            ArrowScale = tmpDistance;
            float HeightArrow = tmpDistance/12.5f;
            Arrow.gameObject.transform.localScale = new Vector3(HeightArrow, HeightArrow, 1);
        }
        
    }

    private void OnMouseUp()
    {
        if (!InputLock)
        {
            ArrowSetActive(false);
            OnInputExit(ArrowScale);
            //Debug.Log(ArrowScale);
        }

    }
    public void Paused(bool isPaused)
    {
        InputLock = isPaused;
    }

    public void ArrowSetActive(bool isActive)
    {
        Arrow.gameObject.SetActive(isActive);
    }

    public void RespawnArrow()
    {
        ArrowEnd.position = Ball.position;
        //ArrowSetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Line.SetPosition(0, Camera.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
