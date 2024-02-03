using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager dialogueManager;
    public Canvas dialogueCanvas;
    public TextMeshProUGUI name;
    public TextMeshProUGUI dialogueText;
    private Story currentStory;
    private bool dialogueIsPlaying;
    [SerializeField]
    private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    [SerializeField]
    private bool choiceMaking;
    public CrossObjectEvent dialogueStart;
    public CrossObjectEvent dialogueEnd;

    private void Awake() {
        if (dialogueManager != null) {
            Destroy(dialogueManager);
        }
        else {
            dialogueManager = this;
        }
    }

    private void Start() {
        dialogueIsPlaying = false;
        choiceMaking = false;
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices) {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update() {
        if (!dialogueIsPlaying) {
            return;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame) {
            ContinueStory();
        }
    }

    public void StartDialogue(TextAsset inkJson, string name) {
        this.name.text = name;
        dialogueStart.TriggerEvent();
        currentStory = new Story(inkJson.text);
        dialogueIsPlaying = true;
        dialogueCanvas.enabled = true;
        choiceMaking = false;
        ContinueStory();
    }

    private void ExitDialogue() {
        HideChoices();
        dialogueCanvas.enabled = false;
        dialogueIsPlaying = false;
        dialogueEnd.TriggerEvent();
    }

    private void ContinueStory() {
        if (currentStory.canContinue) {
            dialogueText.text = currentStory.Continue();
            if (currentStory.currentChoices.Count != 0) {
                DisplayChoices();
            }
        }
        else {
            if (!choiceMaking) {
                ExitDialogue();
            }
        }

    }   

    private void DisplayChoices() {
        choiceMaking = true;
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
        choiceMaking = false;
    }

    public void HideChoices() {
        int index = 0;
        foreach (GameObject choice in choices) {
            choices[index].gameObject.SetActive(false);
            index++;
        }
    }
}
