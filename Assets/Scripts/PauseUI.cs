using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public BallController Ball;
    public Enemy Enemy;
    public InputController InputController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PauseGame(bool isPause)
    {
        Ball.Paused(isPause);
        Enemy.Paused(isPause);
        InputController.Paused(isPause);
        //Time.timeScale = (isPause) ? 0f : 1f;
    }

    public void OutTheGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
