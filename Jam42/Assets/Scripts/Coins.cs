using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            AddCoins();
    }

    private void AddCoins()
    {
        GameManager.instance.coins++;
        Destroy(this.gameObject);
    }
}
