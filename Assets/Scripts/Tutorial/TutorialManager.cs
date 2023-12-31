using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager tutorialManager;
    public List<GameObject> allPopups;
    private int index = -1;

    void Awake() {
        if (tutorialManager != null) {
            Destroy(tutorialManager);
        } else {
            tutorialManager = this;
        }
        foreach (GameObject popup in allPopups)
        {
            popup.SetActive(false);
        }
    }

    public void ShowPopup() {
        index ++;
        allPopups[index].SetActive(true);
    }
}
