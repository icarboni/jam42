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
    private void Start()
    {
        score = 0;
        timeToFinish = 0;
        coins = 0;
    }
    private void Update()
    {
        Cronomechronometer();
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
        if (timeToFinish >= 10 && gameStarted)
        {
            gameStarted = false;

            if (HudManager.instance != null)
            {
                totalScore = score + coins;
                HudManager.instance.SuccessOrFailure(totalScore);
            }
            
        }
        else if (timeToFinish < 10 && gameStarted)
        {
            timeToFinish += Time.deltaTime;
        }
    }
}

