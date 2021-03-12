using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Ball Ball;

    private Rigidbody Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = gameObject.GetComponent<Rigidbody>();
        Ball.ReMove = Move;
        Ball.Respawn = RespawnToPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tmptag = collision.gameObject.tag;
        if (tmptag == "Enemy" || tmptag == "Block")
        {
            gameObject.SetActive(false);
            Stop();
            Ball.OnCollisionTriger();
        }
    }
    private void RespawnToPosition(Vector2 position)
    {
        transform.position = new Vector3(position.x, transform.position.y, position.y);
        gameObject.SetActive(true);
    }

    private void Move()
    {
        Rigidbody.AddForce(transform.forward * Ball.Speed, ForceMode.Impulse);
    }

    public Vector3 Stop()
    {
        Vector3 tmp = Rigidbody.velocity;
        Rigidbody.velocity = Vector3.zero;
        return tmp;
    }

    public void Paused(bool isPaused)
    {
        if (isPaused)
        {
            Ball.SaveVelosity = Stop();
        }
        else
        {
            Rigidbody.velocity = Ball.SaveVelosity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
