using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[System.Serializable]
public class EmotionTagToImageDictionary
{
    [SerializedDictionary("Emotion keys", "Sprite")]
    public SerializedDictionary<string, Sprite> expressionImage;

    public Sprite GetValue(string key) {
        return expressionImage[key];
    }
}

public class DialogueNPC : MonoBehaviour
{
    [SerializeField]
    public List<TextAsset> dialogueTextList;
    public EmotionTagToImageDictionary expressionImage; 
    [SerializeField]
    private string name;
    private NPC npc;
    private int index = 0;
    public CrossObjectEventWithData startDialogue;

    void Start() {
        npc = GetComponent<NPC>();
    }

    public void PlayDialogue() {
        startDialogue.TriggerEvent(this, dialogueTextList[index], name, expressionImage);
    }

    public void PlayDialogueAndIncrementIndex() {
        PlayDialogue();
        IncrementIndex();
    }

    public void IncrementIndex() {
        index += 1;
        index = Mathf.Min(index, dialogueTextList.Count - 1);
    }

}
