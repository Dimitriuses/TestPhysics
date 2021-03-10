using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    Enemy,
    Frendly
}

public class Block : MonoBehaviour
{
    public BlockType Type;

    public OnEvent onBlockDestruct;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Ball")
        {
            onBlockDestruct();
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
