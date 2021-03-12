using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AssetBall", menuName = "AssetBall", order = 1)]
public class Ball : ScriptableObject //MonoBehaviour
{
    public OnEvent OnBallDestroy;
    public Callback ReMove;
    public CallbackWithParameters Respawn;

    [Header("Parameters")]
    [SerializeField]
    private float _speed = 0;
    [SerializeField]
    private bool _ready = true;

    public float Speed => _speed;
    public bool RaedyToStart => _ready;

    public Vector3 SaveVelosity;

    public void OnCollisionTriger()
    {
        //Debug.Log("Trigered");
        OnBallDestroy();
    }
    public void StartBall(float arrowScale)
    {
        //Debug.Log(arrowScale);
        //Debug.Log(_ready);
        if (_ready)
        {
            _ready = false;
            _speed = arrowScale * 2;
            ReMove();
            //Debug.Log("ReMove");
        }
    }

    public void RespawnBall(Vector2 position)
    {
        Respawn(position);
        _ready = true;
    }
}
