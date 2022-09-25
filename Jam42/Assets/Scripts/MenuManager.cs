using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    //public Transition transitionScript;
    public GameObject[] listMenus;
    [SerializeField]
    private int actualIDMenu = 0;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (instance == null)
            instance = this;
    }

    public void ChangeMenu(int _nextMenuID)
    {
       // transitionScript.GoBlack();
        listMenus[actualIDMenu].SetActive(false);
        listMenus[_nextMenuID].SetActive(true);
        actualIDMenu = _nextMenuID;
        //transitionScript.GoWhite();
    }

    public void StartGame(string _nextScene)
    {
        GameManager.instance.score = 0;
        GameManager.instance.totalScore = 0;
        GameManager.instance.timeToFinish = 0;
        GameManager.instance.gameStarted = true;
        SceneManager.LoadScene(_nextScene);
    }

    public void ChangeScene(string _nextScene)
    {
        SceneManager.LoadScene(_nextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }    
}
