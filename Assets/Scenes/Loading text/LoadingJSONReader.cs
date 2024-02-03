using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingJSONReader : MonoBehaviour
{
    public TextAsset loadingJsonFile;
    public TextMeshProUGUI title;
    public TextMeshProUGUI loadingText;

    [System.Serializable]
    private class LoadingData {
        //Name of variablemust match JSON
        public string title;
        public string text;   
    }

    [System.Serializable]
    private class LoadingDataList {
        //Name of variablemust match JSON
        public LoadingData[] loadingDataArray;
    }

    void Start()
    {
        LoadingDataList loadingDataArray = JsonUtility.FromJson<LoadingDataList>(loadingJsonFile.text);
        int randomIndex = Random.Range(0, loadingDataArray.loadingDataArray.Length);
        title.text = loadingDataArray.loadingDataArray[randomIndex].title;
        loadingText.text = loadingDataArray.loadingDataArray[randomIndex].text;
    }

}
