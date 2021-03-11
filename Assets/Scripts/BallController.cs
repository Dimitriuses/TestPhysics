using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Ball Ball;
    public Transform Arrow;
    public Transform EndArrow;

    private Rigidbody Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tmptag = collision.gameObject.tag;
        if (tmptag == "Enemy" || tmptag == "Block")
        {
            gameObject.SetActive(false);
            Stop();
            //OnBallDestroy();
        }
    }

    private void Move()
    {
        //Rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    public Vector3 Stop()
    {
        Vector3 tmp = Rigidbody.velocity;
        Rigidbody.velocity = Vector3.zero;
        return tmp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
