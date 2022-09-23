using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIC : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TicEject(collision);
    }
    public void TicEject(Collider2D _other) => StartCoroutine("Tic", _other);

    IEnumerator Tic(Collider2D _other)
    {
        _other.GetComponent<playerMovement>().stunned = true;
        _other.GetComponent<Animator>().SetTrigger("Stunned");
        //_other.GetComponentInChildren<Animator>().SetTrigger("CerbSpawn");
        _other.transform.GetChild(1).GetComponent<Animator>().SetTrigger("CerbSpawn");
        yield return new WaitForSeconds(2);
        _other.GetComponent<playerMovement>().stunned = false;
        Destroy(this.gameObject);
        yield return null;
    }
}
