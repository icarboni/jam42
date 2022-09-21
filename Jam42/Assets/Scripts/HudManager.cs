using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour
{
    public TextMeshProUGUI gameClock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeClockNumber();
    }


    public void ChangeClockNumber()
    {
        gameClock.text = "Time: " + GameManager.instance.timeToFinish.ToString("F0");
    }
}
