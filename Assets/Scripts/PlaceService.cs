using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceService : MonoBehaviour
{
    [Header("Place Parameters")]
    [SerializeField]
    private Transform Floor;
    [SerializeField]
    private Transform RightWall;
    [SerializeField]
    private Transform LeftWall;
    [SerializeField]
    private Transform TopWall;
    [SerializeField]
    private Transform BotomWall;
    [Header("Camera")]
    [SerializeField]
    private Transform Camera;
    [Header("Text")]
    [SerializeField]
    private Text Text;

    public enum ServiceTarget
    {
        Floor,
        RightWall,
        LeftWall,
        TopWall,
        BotomWall
    }

    public float GetMaxX()
    {
        return RightWall.position.x;
    }
    public float GetMinX()
    {
        return LeftWall.position.x;
    }
    public float GetMaxY()
    {
        return TopWall.position.z;
    }
    public float GetMinY()
    {
        return BotomWall.position.z;
    }
    //public float GetMoveX(float mouseY)
    //{
    //    float distance = Mathf.Abs(Floor.position.y - mouseY);
    //    return distance / (Mathf.Tan(Camera.rotation.x));
    //}

    public Vector3 GetNextPos(Vector3 pos1)
    {
        float distance = Vector3.Distance(pos1, Camera.position);
        float b = Vector3.Distance(pos1, new Vector3(pos1.x, Floor.position.y, pos1.z));
        //float a = b / Mathf.Tan(Camera.eulerAngles.x);
        float a = b / DegresTangens(Camera.eulerAngles.x);
        float c = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
        float undistance = distance - c;
        //Debug.Log(a + " " + b + " " + c);
        float F = Mathf.Atan2(pos1.y - Camera.position.y, pos1.z - Camera.position.z) * (180 / Mathf.PI);
        //Debug.Log(pos1 + " " + Camera.position);
        //Debug.Log(F + " Sin = " + Mathf.Sin(RadianToDegres(F)) + " Cos = " + Mathf.Cos(RadianToDegres(F)));
        return new Vector3(pos1.x, Camera.position.y + undistance * Mathf.Sin(RadianToDegres(F)), Camera.position.z + undistance * Mathf.Cos(RadianToDegres(F)));
    }

    public float NextDistance(Vector3 pos1)
    {
        float distance = Vector3.Distance(pos1, Camera.position);
        float b = Vector3.Distance(pos1, new Vector3(pos1.x, Floor.position.y, pos1.z));
        //float a = b / Mathf.Tan(Camera.eulerAngles.x);
        float a = b / DegresTangens(Camera.eulerAngles.x);
        float c = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
        //Debug.Log("a = " + a + " b = " + b + " c = " + c + " B = " + Camera.eulerAngles.x);
        return distance - c;
    }

    private float DegresTangens(float angle)
    {
        return Mathf.Tan(angle * (Mathf.PI / 180));
    }
    private float RadianToDegres(float angle)
    {
        return Mathf.PI * (angle / 180);
    }

    public void SetDiffictlyText(int diffictly)
    {
        Text.text = "" + diffictly;
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
