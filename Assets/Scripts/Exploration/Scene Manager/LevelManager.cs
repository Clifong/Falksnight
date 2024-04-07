using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public static class LevelManager{
    // public static LevelManager levelManager;
    // private static int counter = 0;
    private static string previousLevel;
    private static CrossObjectEvent startLoading;
    private static CrossObjectEvent loadingComplete;

    // void Awake(){
    //     if (LevelManager.counter >= 1){
    //         Destroy(this.gameObject);
    //     }
    //     levelManager = this;
    //     LevelManager.counter += 1;
    //     if (LevelManager.counter == 10){
    //         LevelManager.counter = 1;
    //     }
    //     DontDestroyOnLoad(this.gameObject);
    // }

    public static void LoadLevel(MonoBehaviour mono, string name){
      if (loadingComplete == null && startLoading == null) {
        startLoading = (CrossObjectEvent)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("Start loading")[0]), typeof(CrossObjectEvent));
        loadingComplete = (CrossObjectEvent)AssetDatabase.LoadAssetAtPath(AssetDatabase.FindAssets("Finish loading")[0], typeof(CrossObjectEvent));
      }
      if (name != "Lose") {
        previousLevel = SceneManager.GetActiveScene().name;
      }
      mono.StartCoroutine(LevelManager.LoadScene(name));
    }

    public static string GetCurrentLevel() {
      return SceneManager.GetActiveScene().name;
    }

    public static void WinBattle(MonoBehaviour mono){
        // DataPersistenceManager.dataPersistenceManager.LoadGame();
        mono.StartCoroutine(LoadScene(previousLevel));
    }

    private static IEnumerator LoadScene(string name){
        startLoading.TriggerEvent();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        while (!asyncLoad.isDone){
            yield return null;
        }

        if (loadingComplete != null) {
          loadingComplete.TriggerEvent();
        }

        // DataPersistenceManager.dataPersistenceManager.LoadGame();
    }

    public static void Retry(MonoBehaviour mono) {
        Debug.Log(previousLevel);
        mono.StartCoroutine(LevelManager.LoadScene(previousLevel));
    }
}
