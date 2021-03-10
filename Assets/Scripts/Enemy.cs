using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public OnEvent OnEnemyLose;
    public OnEvent OnBallColiderEnter;
    public Rigidbody Rigidbody;
    public Transform Ball;
    private int health;
    public int Health { get { return health; } }
    public float speed;
    public List<Block> Blocks;
    bool EnemyLock = false;
    // Start is called before the first frame update
    void Start()
    {
        health = Blocks.Count;
        foreach (var item in Blocks)
        {
            item.onBlockDestruct = OnBlockDestruct;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            OnBallColiderEnter();
            Rigidbody.velocity = Vector3.zero;
            
        }
    }

    void OnBlockDestruct()
    {
        health--;
        if (health == 0)
        {
            OnEnemyLose();
            
        }

    }

    private void MoveToBall(float speed)
    {
        float BallX = Ball.position.x;
        float EnemyX = transform.position.x;
        //Debug.Log(speed);
        if (BallX > EnemyX)
        {
            Rigidbody.AddForce(transform.right * speed, ForceMode.Force);
            //Debug.Log("Right " + transform.right * speed);
        }
        else if (BallX < EnemyX)
        {
            Rigidbody.AddForce(-transform.right * speed, ForceMode.Force);
            //Debug.Log("Left " + -transform.right * speed);
        }
        else if(BallX == EnemyX)
        {
            Rigidbody.velocity = Vector3.zero;
        }
    }

    public void RespawnBlcok()
    {
        health = Blocks.Count;
        foreach (var item in Blocks)
        {
            item.gameObject.SetActive(true);
        }
    }

    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }

    public void Paused(bool isPaused)
    {
        EnemyLock = isPaused;
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnemyLock)
        {
            MoveToBall(speed);
        }
    }
}
