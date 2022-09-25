using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public AudioSource audiomanager;
    public AudioClip coinSound;
    public void Start()
    {
        audiomanager = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AddCoins();
           audiomanager.GetComponent<AudioSource>().PlayOneShot(coinSound, 1f);
        }
    }

    private void AddCoins()
    {
        GameManager.instance.coins++;
        Destroy(this.gameObject);
    }
}
