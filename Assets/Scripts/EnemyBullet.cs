using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private float bulletDamage;

    private Rigidbody2D rb;
    // Start is called before the first frame update


    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(-Vector2.up * bulletSpeed);
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            other.SendMessageUpwards("OnDamagedPlayer", bulletDamage);
            
        }

        // Destroy bullet when hitting object
        Destroy(gameObject);
        
        
    }
    
    // Destroy bullet after it moves out of screen
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
