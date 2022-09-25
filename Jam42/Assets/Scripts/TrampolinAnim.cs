using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolinAnim : MonoBehaviour
{
    public GameObject trampolin;
    public GameObject trampolinExtend;
    public AudioSource audiomanager;
    public AudioClip trampolinSound;
    public void Start()
    {
        audiomanager = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            trampolin.SetActive(true);
            trampolinExtend.SetActive(false);
            audiomanager.PlayOneShot(trampolinSound, 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            trampolin.SetActive(false);
            trampolinExtend.SetActive(true);
        }
        
    }
}
