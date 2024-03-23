using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CutsceneTextManager : MonoBehaviour
{
    public Canvas sceneCanvas;
    public List<TextAsset> inkJson;
    public Canvas choiceCanvas;
    [SerializeField]
    private GameObject[] choices;
    public TextMeshProUGUI cutsceneText;
    private TextMeshProUGUI[] choicesText;
    private bool cutsceneIsPlaying;
    private Story currentStory;
    private bool completeText = false;
    private string fullText = "";
    public List<UnityEvent> cutsceneEnd;
    private int counter = 0;
    
    void Start()
    {
        currentStory = new Story(inkJson[counter].text);
        choiceCanvas.enabled = false;
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices) {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }    
        StartDialogue();
    }

    private void Update() {
        if (!cutsceneIsPlaying) {
            return;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame) {
            if (completeText) {
                ContinueStory();
            } else {
                StopAllCoroutines();
                cutsceneText.text = fullText;
                completeText = true;
            }
        }
    }

    public void StartDialogue() {
        currentStory = new Story(inkJson[counter].text);
        cutsceneIsPlaying = true;
        sceneCanvas.enabled = true;
        ContinueStory();
    }

    private void ExitDialogue() {
        HideChoices();
        cutsceneIsPlaying = false;
        cutsceneEnd[counter]?.Invoke();
        counter++;
        if (counter >= inkJson.Count) {
            this.enabled = false;
        }
    }

    private void ContinueStory() {
        completeText = false;
        if (currentStory.canContinue) {
            cutsceneText.text = "";
            StartCoroutine(TypeOutText());
        } else {
            if (currentStory.currentChoices.Count != 0) {
                DisplayChoices();
            }
            else {
                ExitDialogue();
            } 
        }
    }   

    private void DisplayChoices() {
        choiceCanvas.enabled = true;
        List<Choice> currentChoices = currentStory.currentChoices;
        int index = 0;
        foreach (Choice choice in currentChoices) {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
    }

    public void MakeChoice(int index) {
        HideChoices();
        currentStory.ChooseChoiceIndex(index);
        ContinueStory();
    }

    public void HideChoices() {
        int index = 0;
        foreach (GameObject choice in choices) {
            choices[index].gameObject.SetActive(false);
            index++;
        }
    }

    IEnumerator TypeOutText() {
        fullText = currentStory.Continue();
        for (int i = 0; i < fullText.Length; i++) {
            yield return new WaitForSeconds(0.05f);
            cutsceneText.text += fullText[i];
        }
        completeText = true;
    }

    public void ChangeScene(string level) {
        LevelManager.LoadLevel(this, level);
    }
}
