using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int eHealth = 3;
    public float moveSpeed = 3f;
    public int damageAmount = 1;

    private Transform player;

    //public GameObject deathEffect;

    private void Awake()
    {
        // Ensure the player object is present before initializing the enemy
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (player == null || !player.gameObject.activeSelf)
        {
            return;
        }
        
        //move towards the player
        Vector3 direction = player.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Damage the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakePDamage(damageAmount);
            }
        }
    }

    public void TakeEDamage (int Edamage)
    {
        eHealth -= Edamage;

        if (eHealth <= 0)
        {
            dieEnemy();
        }
    }

    void dieEnemy()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy (gameObject);
    }

}
