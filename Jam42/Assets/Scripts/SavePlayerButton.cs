using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;
using System;

public class SavePlayerButton : MonoBehaviour
{
    string filePath;
    public Button SaveButton;
    public TextMeshProUGUI rankingScoreText1;
    public TextMeshProUGUI rankingNameText1;
    public TextMeshProUGUI rankingScoreText2;
    public TextMeshProUGUI rankingNameText2;
    public GameObject inputField;
    List<PlayerData> rankingData;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/ranking.json";
        Button btn = SaveButton.GetComponent<Button>();
        PlayerData youData = new PlayerData();
        youData.name = "you";
        youData.score = GameManager.instance.totalScore;
        Debug.Log(filePath);
        if (!File.Exists(filePath))
        {
            Debug.Log("noexist");
            rankingData = new List<PlayerData>();
            rankingData.Add(youData);
            rankingScoreText1.text += youData.score.ToString("F0") + "\n";
            rankingNameText1.text += "you\n";
        }
        else
        {
            string jsonLoaded = File.ReadAllText(filePath);

            //Load as Array
            rankingData = JsonHelper.FromJson<PlayerData>(jsonLoaded).ToList();
            //Convert to List
            //List<PlayerData> loadListData = rankingData.OfType<PlayerData>().ToList();
            rankingData.Add(youData);
            rankingData = rankingData.OrderByDescending(x => x.score).ToList();
            //for (int i = 0; i < rankingData.Count; i++)
            //{
            //    Debug.Log(rankingData[i].name + " " + rankingData[i].score);
            //}
            showRanking(rankingData);
        }

        btn.onClick.AddListener(SavePlayer);
    }

   

    void showRanking(List<PlayerData> rankingData)
    {
        for (int i = 0; i < rankingData.Count && i < 10; i++)
        {
            if (i < 5)
            {
                rankingScoreText1.text += rankingData[i].score.ToString("F0") + "\n";
                rankingNameText1.text += rankingData[i].name + "\n";
            }
            else
            {
                rankingScoreText2.text += rankingData[i].score.ToString("F0") + "\n";
                rankingNameText2.text += rankingData[i].name+ "\n";

            }
        }

    }

    void SavePlayer()
    {

        string name = inputField.GetComponent<TMP_InputField>().text;
        if (!string.IsNullOrEmpty(name))
        {
            PlayerData playerData = new PlayerData();
            playerData.name = name;
            playerData.score = GameManager.instance.totalScore;

            if (!File.Exists(filePath))
            {
                string parentData = JsonUtility.ToJson(playerData);
                File.WriteAllText(filePath, "{\"Items\":[" + parentData + "]}");
                
            }
            else
            {
     
                string jsonLoaded = File.ReadAllText(filePath);
                //Debug.Log(jsonLoaded);

                //Load as Array
                PlayerData[] _tempLoadListData = JsonHelper.FromJson<PlayerData>(jsonLoaded);
                //Convert to List
                List<PlayerData> loadListData = _tempLoadListData.OfType<PlayerData>().ToList();
                loadListData.Add(playerData);
                loadListData = loadListData.OrderByDescending(x => x.score).ToList();

                string parentData = JsonHelper.ToJson(loadListData.ToArray());
                File.WriteAllText(filePath, parentData);
            }

            //string json = JsonUtility.ToJson(playerData);
            //Debug.Log(json);

            //File.WriteAllText(Application.dataPath + "/ranking.json", json);
            //string json = File.ReadAllText(Application.dataPath + "/ranking.json");

            //PlayerData loadedPlayer = JsonUtility.FromJson<PlayerData>(json);
            //Debug.Log("name: " + loadedPlayer.name);
            //Debug.Log("score: " + loadedPlayer.score);
        }
        else
            Debug.Log("empty");

    }

    [Serializable]
    private class PlayerData
    {
        public string name;
        public float score;
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
