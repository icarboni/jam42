using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVolumenIngame : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioManager;
    void Start()
    {
        audioManager.volume = AudioManager.instance.actualSound;
    }


}
