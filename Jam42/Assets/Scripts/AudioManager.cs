using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioManager;
    public Slider volumen;
    [Range(0,1)]
    public float actualSound = 0.2f;
    void Start()
    {
        instance = this;
        audioManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        volumen.value = 
        audioManager.volume = actualSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSound() 
    {
        actualSound = volumen.value;
        audioManager.volume = actualSound;
    }



}
