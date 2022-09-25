using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolinAnim : MonoBehaviour
{
    public GameObject trampolin;
    public GameObject trampolinExtend;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            trampolin.SetActive(true);
            trampolinExtend.SetActive(false);
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
