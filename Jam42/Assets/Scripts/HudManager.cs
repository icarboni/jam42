using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour
{
    public static HudManager instance;
    public float origin;
    public TextMeshProUGUI gameClock;
    public TextMeshProUGUI scoreTXT;
    public Transform playerTransform;
    public GameObject successMenu;
    public GameObject failureMenu;
    public TextMeshProUGUI successText;
    public TextMeshProUGUI failureText;

    void Start()
    {
        Singleton();
        origin = playerTransform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeClockNumber();
    }

    private void Singleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

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


    public void SuccessOrFailure()
    {
        if(GameManager.instance.totalScore >= 50)
        {
            playerTransform.GetComponent<playerMovement>().stunned = true;
            successMenu.SetActive(true);
            successText.text = GameManager.instance.totalScore.ToString("F0");
        }
        else
        {
            playerTransform.GetComponent<playerMovement>().stunned = true;
            failureMenu.SetActive(true);
            failureText.text = GameManager.instance.totalScore.ToString("F0");
        }
    }
}
