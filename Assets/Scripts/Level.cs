﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnEvent();
public class Level : MonoBehaviour
{
    public int Difictly = 0;
    public Vector2 RespawnBallPosition;
    public Player Player;
    public Enemy Enemy;
    public Ball Ball;
    public InputController InputController;

    public Text Text;
    //bool isBallInWorkSpace;
    // Start is called before the first frame update
    void Start()
    {
        Player.OnPlayerLose = PlayerLose;
        Enemy.OnEnemyLose = EnemyLose;
        Enemy.OnBallColiderEnter = CaughtTheBall;
        Enemy.speed = Difictly;
        Ball.OnBallDestroy = OnBallDestroy;
        InputController.OnInputExit = Ball.StartBall;
    }

    public void PlayerLose()
    {
        Ball.Stop();
    }

    public void EnemyLose()
    {
        Difictly++;
        Text.text = "" + Difictly;
        Text.fontSize = (Difictly < 10) ? 100 : ((Difictly >= 10 && Difictly < 100) ? 75 : ((Difictly >= 100 && Difictly < 1000) ? 50 : 25));
        Ball.RespawnBall(RespawnBallPosition);
        int ESMax = 4;
        int EScale = (Difictly <= ESMax) ? Difictly : ((Difictly % (ESMax * 2) >= ESMax) ? (ESMax - Difictly % ESMax) : (Difictly % ESMax));
        EScale = (EScale == 0) ? 1 : EScale;
        Enemy.SetScale(EScale);
        //Debug.Log(Difictly);
        Enemy.speed = Difictly;//10f;
        //Enemy.RespawnBlcok();
        StartCoroutine(RespawnEnemy());
    }

    IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(1f);
        Enemy.RespawnBlcok();
    }

    public void CaughtTheBall()
    {

    }

    public void OnBallDestroy()
    {
        Ball.RespawnBall(RespawnBallPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}