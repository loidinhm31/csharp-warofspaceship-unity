using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{   

    [SerializeField]
    private float blockHP = 99;

    [SerializeField]
    private float fallingSpeed = 3.0f;

    private float timer;

    public AudioSource source;
    public AudioClip hitSound;

    public GameObject explosion;

    [SerializeField]
    private GameObject bulletPrefab;
    
    [SerializeField]
    private Transform bulletSpawnPoint;

    private bool isShooting = true;

    [SerializeField]
    private float fireRate = 0.2f;

    
    // Start is called before the first frame update
    void Start()
    {   
        timer = fallingSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        // Every 3 seconds, the block will move down 1 time
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f);
            timer = fallingSpeed;
        }
    }

    void FixedUpdate()
    {
        if (isShooting)
        {   
            StartCoroutine(Shoot());
        }
    }

    public void OnDamagedEnemy(float damage)
    {   
        // Make sound more real
        float vol = Random.Range(0.35f, 1.5f);
        // Play audio effect 
        source.PlayOneShot(hitSound, vol);

        // HP of block will decrease by the amount of damage dealt by a bullet
        blockHP -= damage;

        // Count Player Score when bullet hit Enemy
        GameController.instance.PlayerScore++;

    
        // If HP of the block less than or equal 0, block will be destroy
        if (blockHP <= 0)
        {
            Destroy(gameObject);

            Instantiate(explosion, transform.position, transform.rotation);

            
            BlockController.instance.blockCount--;
           
            if (BlockController.instance.blockCount <= 0)
            {
                GameController.instance.ActiveWinPopUp();
            }
        }
    
    }
    
    IEnumerator Shoot()
    {   
        // Instantiate 01 bullet at bulletSpawnPoint's position, Quaternion set default as quaternion of bulletPrefab
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        
        

        // After bullet spwan, player will stop fire in #fireRate time
        isShooting = false;
        yield return new WaitForSeconds(fireRate);

        // After #fireRate time, player will start firing again
        isShooting = true;
    }


    // Collide with Player
    private void GetDamageOnCollide(float damageCol)
    {
        blockHP -= damageCol;
    }
}
