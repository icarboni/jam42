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

    public Button SaveButton;
    //public TextMeshProUGUI NameField;
    public GameObject inputField; 
    

    // Start is called before the first frame update
    void Start()
    {
        Button btn = SaveButton.GetComponent<Button>();
        
        btn.onClick.AddListener(SavePlayer);
    }

    // Update is called once per frame
    void SavePlayer()
    {

        string name = inputField.GetComponent<TMP_InputField>().text;
        if (!string.IsNullOrEmpty(name))
        {
            PlayerData playerData = new PlayerData();
            playerData.name = name;
            playerData.score = GameManager.instance.totalScore;

            string filePath = Application.persistentDataPath + "/ranking.json";
            Debug.Log(filePath);
            if (!File.Exists(filePath))
            {
                Debug.Log("NO EXIST");
                string parentData = JsonUtility.ToJson(playerData);
                File.WriteAllText(filePath, "{\"Items\":[" + parentData + "]}");
            }
            else
            {
     
                string jsonLoaded = File.ReadAllText(filePath);
                Debug.Log(jsonLoaded);


                //Load as Array
                PlayerData[] _tempLoadListData = JsonHelper.FromJson<PlayerData>(jsonLoaded);
                //Convert to List
                List<PlayerData> loadListData = _tempLoadListData.OfType<PlayerData>().ToList();
                loadListData.Add(playerData);
                for (int i = 0; i < loadListData.Count; i++)
                {
                    Debug.Log("Got: " + loadListData[i].name);
                }

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
