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

    public AudioSource audioManager;
    public AudioClip buttonSound;

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
        audioManager.PlayOneShot(buttonSound, 1f);
       // transitionScript.GoBlack();
        listMenus[actualIDMenu].SetActive(false);
        listMenus[_nextMenuID].SetActive(true);
        actualIDMenu = _nextMenuID;
        //transitionScript.GoWhite();
    }

    public void StartGame(string _nextScene)
    {
        audioManager.PlayOneShot(buttonSound, 1f);
        GameManager.instance.score = 0;
        GameManager.instance.coins = 0;
        GameManager.instance.totalScore = 0;
        GameManager.instance.timeToFinish = 0;
        GameManager.instance.gameStarted = true;
        SceneManager.LoadScene(_nextScene);
    }

    public void ChangeScene(string _nextScene)
    {
        audioManager.PlayOneShot(buttonSound, 1f);
        SceneManager.LoadScene(_nextScene);
    }

    public void QuitGame()
    {
        audioManager.PlayOneShot(buttonSound, 1f);
        Application.Quit();
    }    
}
