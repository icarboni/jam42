using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float timeToFinish = 0;
    public int coins = 0;
    public float score = 0;
    public float totalScore = 0;
    public bool gameStarted = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Singleton();
    }
    private void Update()
    {
        Cronomechronometer();
    }

    public void StartGame(string _nextScene)
    {
        gameStarted = true;
        SceneManager.LoadScene(_nextScene);
    }



    private void Singleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

    }
    public void Cronomechronometer()
    {
        if (timeToFinish < 100 && gameStarted)
        {
            timeToFinish += Time.deltaTime;
        }
        else
        { 
            gameStarted = false;
            HudManager.instance.SuccessOrFailure();
            totalScore = score + coins;
        }
    }

}

