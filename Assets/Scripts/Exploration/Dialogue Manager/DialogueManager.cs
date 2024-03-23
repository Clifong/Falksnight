using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using AYellowpaper.SerializedCollections;

public class DialogueManager : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public TextMeshProUGUI name;
    public TextMeshProUGUI dialogueText;
    private Story currentStory;
    private bool dialogueIsPlaying;
    [SerializeField]
    private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    private bool choiceMaking;
    public CrossObjectEvent dialogueEnd;
    public CrossObjectEvent specialDialogueEnd;
    public Image dialgoueCharacterImage;
    private EmotionTagToImageDictionary emotionTagToImageDictionary;

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

    public void StartDialogue(Component component, object data) {
        object[] temp = (object[]) data;
        TextAsset inkJson = (TextAsset) temp[0];
        string name = (string) temp[1];
        EmotionTagToImageDictionary emotionTagToImageDictionary = (EmotionTagToImageDictionary) temp[2];
        this.name.text = name;
        this.emotionTagToImageDictionary = emotionTagToImageDictionary;
        currentStory = new Story(inkJson.text);
        dialogueIsPlaying = true;
        dialogueCanvas.enabled = true;
        choiceMaking = false;
        currentStory.BindExternalFunction("ExitDialogueEventSpecial", () => {
            ExitDialogueEventSpecial();
        });
        ContinueStory();
    }

    private void ExitDialogue() {
        HideChoices();
        dialogueCanvas.enabled = false;
        dialogueIsPlaying = false;
        dialogueEnd.TriggerEvent();
    }

    private void ExitDialogueEventSpecial() {
        specialDialogueEnd.TriggerEvent();
    }

    private void ContinueStory() {
        if (currentStory.canContinue) {
            dialogueText.text = currentStory.Continue();
            List<string> tags = currentStory.currentTags;
            if (tags.Count > 0) {
                dialgoueCharacterImage.sprite = emotionTagToImageDictionary.GetValue(tags[0]);
            }
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
        choiceMaking = false;
        ContinueStory();
    }

    public void HideChoices() {
        int index = 0;
        foreach (GameObject choice in choices) {
            choices[index].gameObject.SetActive(false);
            index++;
        }
    }
}
