using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 destination;
    private bool isShooting = true;

    [SerializeField]
    private float fireRate = 0.2f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPoint;

    public AudioSource sourceShoot;
    public AudioClip shootSound;

    public AudioSource sourceHit;
    public AudioClip hitSound;
    //Change private
    public float PlayerHP = 200;

   
    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) 
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position, new Vector3(destination.x, destination.y, transform.position.z), 0.1f);

        }

        if (isShooting)
        {
            StartCoroutine(Shoot());
        }


        // If HP of the block less than or equal 0, block will be destroy
        if (PlayerHP <= 0)
        {   
            GameController.instance.DeadTime += 1;
            PlayerPrefs.SetInt("DeadTime", GameController.instance.DeadTime);


            Debug.Log("Dead Time: " + GameController.instance.DeadTime);

            Destroy(gameObject);

            GameController.instance.StatusText.text = "You Lose!!!";

            GameController.instance.ActiveWinPopUp();
        }
    }
    

    IEnumerator Shoot()
    {   
        // Instantiate 01 bullet at bulletSpawnPoint's position, Quaternion set default as quaternion of bulletPrefab
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Make sound more real
        float vol = Random.Range(0.25f, 0.8f);

        // Play Audio
        sourceShoot.PlayOneShot(shootSound, vol);

        // After bullet spwan, player will stop fire in #fireRate time
        isShooting = false;
        yield return new WaitForSeconds(fireRate);

        // After #fireRate time, player will start firing again
        isShooting = true;
    }


    public void OnDamagedPlayer(float damage)
    {   
        // Make sound more real
        float vol = Random.Range(0.35f, 1.5f);
        // Play audio effect 
        sourceHit.PlayOneShot(hitSound, vol);

        // HP of block will decrease by the amount of damage dealt by a bullet
        PlayerHP -= damage;

    
    }

    
    // Get damage when player collide with enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Damage on Enemy
            other.SendMessageUpwards("GetDamageOnCollide", 10f);
            // Damage on Player
            PlayerHP -= 30f;
        }

    }
   
}
