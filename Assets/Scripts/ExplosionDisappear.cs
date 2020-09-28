using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDisappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        // Destroy Particle System Effect
        Destroy(gameObject, 5f);
    }

    
}
