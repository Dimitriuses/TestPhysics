using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public OnEvent OnBallDestroy;
    
    public float speed = 0;
    public Vector3 SaveVelosity;
    public Rigidbody Rigidbody;

    public bool RedyToStart = true;
    bool BallLock = false;
    public Transform Arrow;
    public Transform EndArrow;

    // Start is called before the first frame update
    void Start()
    {
        //Move();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        string tmptag = collision.gameObject.tag;
        //Debug.Log(collision.collider.gameObject.tag);
        if (tmptag == "Enemy" || tmptag == "Block")
        {
            gameObject.SetActive(false);
            Stop();
            OnBallDestroy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (RedyToStart && !BallLock)
        //{
        //    transform.LookAt(EndArrow);
        //    float tmpDistance = Vector3.Distance(EndArrow.position, transform.position);
        //    speed = tmpDistance * 2;
        //    float HeightArrow = tmpDistance / 12.5f;
        //    Arrow.gameObject.transform.localScale = new Vector3(HeightArrow,HeightArrow,1);
        //}
    }

    public void StartBall()
    {
        if (RedyToStart)
        {
            RedyToStart = false;
            Arrow.gameObject.SetActive(false);
            Move();
        }

    }

    public void RespawnBall(Vector2 position)
    {
        transform.position = new Vector3(position.x, transform.position.y, position.y);
        EndArrow.position = transform.position;
        gameObject.SetActive(true);
        Arrow.gameObject.SetActive(true);
        RedyToStart = true;
    }

    private void Move()
    {
        Rigidbody.AddForce(transform.forward * speed,ForceMode.Impulse);
    }



    public void Paused(bool isPaused)
    {
        if (isPaused)
        {
            SaveVelosity = Stop();
        }
        else
        {
            Rigidbody.velocity = SaveVelosity;
        }
        BallLock = isPaused;
    }

    public Vector3 Stop()
    {
        Vector3 tmp = Rigidbody.velocity;
        Rigidbody.velocity = Vector3.zero;
        return tmp;
    }
}
