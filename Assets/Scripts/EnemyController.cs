using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //delegate void Comeback();
    
    private Rigidbody Rigidbody;
    public Transform Ball;
    [Header("Parameters")]
    public List<Block> Blocks;
    public Enemy Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = new Enemy();
        Rigidbody = gameObject.GetComponent<Rigidbody>();
        foreach (var item in Blocks)
        {
            item.onBlockDestruct = Enemy.OnBlockDestruct;
        }
        Enemy.ReRespawn = RespawnBlocks;
        Enemy.RespawnBlcoks(Blocks);
    }

    public void RespawnBlocks()
    {
        Enemy.RespawnBlcoks(Blocks);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //OnBallColiderEnter();
            Rigidbody.velocity = Vector3.zero;

        }
    }

    //public void SetScale(float scale)
    //{
    //    transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    //}

    private void MoveToBall()
    {
        Rigidbody.AddForce(Enemy.MoveTo(transform,Ball.position.x), ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enemy.isLock)
        {
            MoveToBall();
        }
    }
}
