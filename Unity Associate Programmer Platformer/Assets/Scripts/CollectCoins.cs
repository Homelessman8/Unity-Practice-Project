using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    [Tooltip("The particles that appear after the player collects a coin.")]
    public GameObject coinParticles;

    PlayerMovement playerMovementScript;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMovementScript = other.GetComponent<PlayerMovement>();
            playerMovementScript.soundManager.PlayCoinSound();
            ScoreManager.score += 10;
            //add the health
            if (playerMovementScript.playerStats.health < 100)
            {
                playerMovementScript.ChangeHealth(1);
            }
            else
            { 
                playerMovementScript.ChangeHealth(0);
            }
            
            GameObject particles = Instantiate(coinParticles, transform.position, new Quaternion());
            Destroy(gameObject);
        }
    }
}