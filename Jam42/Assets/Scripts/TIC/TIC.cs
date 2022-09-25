using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIC : MonoBehaviour
{
    public float time = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled == false)
        {
            TicEject(collision);
        }
        else
            collision.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
    }
    public void TicEject(Collider2D _other) => StartCoroutine("Tic", _other);

    IEnumerator Tic(Collider2D _other)
    {
        _other.GetComponent<playerMovement>().stunned = true;
        _other.GetComponent<Animator>().SetTrigger("Stunned");
        _other.transform.GetChild(1).GetComponent<Animator>().SetTrigger("CerbSpawn");
        yield return new WaitForSeconds(time);
        _other.GetComponent<playerMovement>().stunned = false;
        Destroy(this.gameObject);
        yield return null;
    }
}