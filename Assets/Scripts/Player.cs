using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public OnEvent OnPlayerLose;
    private int health;
    public int Health { get { return health; } }
    public List<Block> Blocks;
    // Start is called before the first frame update
    void Start()
    {
        health = Blocks.Count;
        foreach (var item in Blocks)
        {
            item.onBlockDestruct = OnBlockDestruct;
        }   
    }

    void OnBlockDestruct()
    {
        health--;
        if (health == 0)
        {
            OnPlayerLose();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
