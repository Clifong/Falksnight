using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerHelper : MonoBehaviour
{
    public Scene scene;
    public void ChangeLevel() {
        LevelManager.LoadLevel(this, scene.name);
    }
}
