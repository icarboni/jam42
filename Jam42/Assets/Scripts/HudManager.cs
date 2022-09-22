using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour
{
    public float origin;
    public TextMeshProUGUI gameClock;
    public TextMeshProUGUI scoreTXT;
    public Transform playerTransform;

    void Start()
    {
        origin = playerTransform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeClockNumber();
    }


    public void ChangeClockNumber()
    {
        gameClock.text = "Time: " + GameManager.instance.timeToFinish.ToString("F0");
        if (GameManager.instance.gameStarted)
        {
            if (GameManager.instance.score < (playerTransform.position.x - origin))
            {
                GameManager.instance.score = playerTransform.position.x - origin;
                Debug.Log("Hit: " + GameManager.instance.score.ToString("F0"));
                scoreTXT.text = "Score: " + GameManager.instance.score.ToString("F0");
            }
        }
    }
}
