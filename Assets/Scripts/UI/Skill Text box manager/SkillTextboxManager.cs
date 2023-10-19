using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillTextboxManager : MonoBehaviour
{
    public static SkillTextboxManager skillTextboxManager;
    public GameObject skillTextBox;
    private TextMeshProUGUI skillText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (skillTextboxManager != null){
            Destroy(skillTextboxManager);
        }
        skillTextboxManager = this;
        skillText = skillTextBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ChangeText(string skillName){
        skillTextBox.SetActive(true);
        skillText.text = skillName;
    }

    public void HideText(){
        skillTextBox.SetActive(false);
    }
}
