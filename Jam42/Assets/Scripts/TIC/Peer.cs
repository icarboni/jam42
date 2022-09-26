using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peer : MonoBehaviour
{
    public float time = 2;
    public Vector2 minMaxPoints;
    public Animator animPeer;

    private void Start()
    {
        animPeer = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.GetComponent<playerMovement>().interactable)
        {
            PeerEject(collision);
        }
    }
    public void PeerEject(Collider2D _other) => StartCoroutine("Peers", _other);

    IEnumerator Peers(Collider2D _other)
    {
        animPeer.SetBool("Chatting", true);
        _other.GetComponent<playerMovement>().stunned = true;
        yield return new WaitForSeconds(time);
        _other.GetComponent<playerMovement>().stunned = false;
        animPeer.SetBool("Chatting", false);
        GameManager.instance.coins += (int)Random.Range(minMaxPoints.x, minMaxPoints.y);
        Destroy(this.gameObject);
        yield return null;
    }
}
