using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockController : MonoBehaviour
{   
    public int blockCount = 0;

    public static BlockController instance;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Count number of blocks (child of Blocks) when starting game
        blockCount = gameObject.transform.childCount;
    }

    

    

    
}
