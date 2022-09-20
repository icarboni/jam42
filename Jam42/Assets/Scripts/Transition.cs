using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public Image transitionImage;
    public float transvelocity = 0.5f;
    public float alpha = 0;

    public void Start()
    {
        StartCoroutine("TransitionPanel");
    }


    public void GoBlack() => StartCoroutine("TransitionPanelGoBlack");
    public void GoWhite() => StartCoroutine("TransitionPanelGoWhite");

    public IEnumerator TransitionPanelGoBlack()
    {
            yield return null;
    }
    public IEnumerator TransitionPanelGoWhite()
    {
        yield return null;
    }
}
