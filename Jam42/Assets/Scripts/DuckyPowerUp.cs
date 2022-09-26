using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckyPowerUp : MonoBehaviour
{
    public AudioSource audiomanager;
    public AudioClip duckSound;
    public void Start()
    {
        audiomanager = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && (other.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled == false))
        {

            other.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
            audiomanager.PlayOneShot(duckSound, 1f);
            Destroy(this.gameObject);

        }
        else
        {
            audiomanager.PlayOneShot(duckSound, 1f);
            GameManager.instance.coins += 5;
            Destroy(this.gameObject);
        }
    }
}
