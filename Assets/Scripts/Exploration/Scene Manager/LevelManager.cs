using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager{
    // public static LevelManager levelManager;
    // private static int counter = 0;
    private static string previousLevel;

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
      previousLevel = SceneManager.GetActiveScene().name;
      DataPersistenceManager.dataPersistenceManager.setDataFileName(previousLevel);
      DataPersistenceManager.dataPersistenceManager.SaveGame();
      mono.StartCoroutine(LevelManager.LoadScene(name));
    }

    public static void WinBattle(MonoBehaviour mono){
        // DataPersistenceManager.dataPersistenceManager.LoadGame();
        mono.StartCoroutine(LoadScene(previousLevel));
    }

    private static IEnumerator LoadScene(string name){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        while (!asyncLoad.isDone){
            yield return null;
        }
    }
}
