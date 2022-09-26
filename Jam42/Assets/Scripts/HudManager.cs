using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public AudioSource audioManager;
    public AudioClip buttonSound;

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
        gameClock.text = GameManager.instance.timeToFinish.ToString("F0");
        
        if (GameManager.instance.gameStarted)
        {
            if (GameManager.instance.score < (playerTransform.position.x - origin))
            {
                GameManager.instance.score = playerTransform.position.x - origin;
                scoreTXT.text = "Score: " + GameManager.instance.totalScore.ToString("F0");
            }
        }
    }


    public void SuccessOrFailure(float _totalScore)
    {
        if(_totalScore >= 2)
        {
            playerTransform.GetComponent<playerMovement>().stunned = true;
            successMenu.SetActive(true);
            successText.text = _totalScore.ToString("F0");
        }
        else
        {
            playerTransform.GetComponent<playerMovement>().stunned = true;
            failureMenu.SetActive(true);
            failureText.text = _totalScore.ToString("F0");
        }
    }

    public void ChangeScene(string _nextScene)
    {
        audioManager.PlayOneShot(buttonSound, 1f);
        SceneManager.LoadScene(_nextScene);
    }
    public void RestartGame(string _nextScene)
    {
        origin = 0;
        GameManager.instance.score = 0;
        GameManager.instance.coins = 0;
        GameManager.instance.totalScore = 0;
        GameManager.instance.timeToFinish = 0;
        GameManager.instance.gameStarted = true;
        audioManager.PlayOneShot(buttonSound, 1f);
        SceneManager.LoadScene(_nextScene);
    }
}
