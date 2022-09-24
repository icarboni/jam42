using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypingText : MonoBehaviour
{
    [TextArea]
    public string textToWrite;
    public TextMeshProUGUI text;
    public static int fontSize = 30;
    public float typingSpeed;

    public float actualTypingSpeed;
    public bool isWritting;


    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("TypeSentence", textToWrite);
    }

    IEnumerator TypeSentence(string _message)
    {
        actualTypingSpeed = typingSpeed;
        text.text = "";
        isWritting = true;
       // writeAudio.volume = 1f;
        foreach (char letter in _message.ToCharArray())
        {
            text.text += letter;
            //TODO Ejecutar sonido aqui creacion de letras.
            //writeAudio.PlayOneShot(sounds[0], 0.1f);
            yield return new WaitForSeconds(actualTypingSpeed);

        }
        isWritting = false;
    }

}
