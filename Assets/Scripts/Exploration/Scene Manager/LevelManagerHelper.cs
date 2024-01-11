using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerHelper : MonoBehaviour
{
    public string sceneName;
    public void ChangeLevel() {
        LevelManager.LoadLevel(this, sceneName);
    }
}
