using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Comeback();
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy", order = 1)]
public class Enemy : ScriptableObject
{
    [Header("Parameters")]
    [SerializeField]
    private int _health;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private bool _enemyLock = false;
    public int Health { get { return _health; } }
    public float Speed { get { return _speed; } set { _speed = value; } }
    public bool isLock { get { return _enemyLock; } }

    public OnEvent OnEnemyLose;
    //public OnEvent OnBallColiderEnter;
    public Comeback ReRespawn;

    public Enemy()
    {

    }

    public void OnBlockDestruct()
    {
        _health--;
        if(_health == 0)
        {
            OnEnemyLose();
        }
    }
    public void RespawnBlcoks(List<Block> blocks)
    {
        _health = blocks.Count;
        foreach (var item in blocks)
        {
            item.Respawn();
        }
    }

    public Vector3 MoveTo(Transform EnemyTransform, float PositionX)
    {
        float EnemyX = EnemyTransform.position.x;
        if (PositionX > EnemyX)
        {
            return EnemyTransform.right * _speed;
        }
        else if (PositionX < EnemyX)
        {
            return -EnemyTransform.right * _speed;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public void Paused(bool isPaused)
    {
        _enemyLock = isPaused;
    }
}
