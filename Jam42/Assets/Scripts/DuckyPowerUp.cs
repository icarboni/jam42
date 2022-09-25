using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckyPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && (other.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled == false))
        {
            
                other.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
                Destroy(this.gameObject);
            
        }
        else 
        { 
            GameManager.instance.coins += 5;
            Destroy(this.gameObject);
        }
    }
}
