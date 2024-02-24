using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillTextboxManager : MonoBehaviour
{
    public GameObject skillTextBox;
    private TextMeshProUGUI skillText;
    
    // Start is called before the first frame update
    void Start()
    {
        skillText = skillTextBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ChangeText(Component component, object data) {
        object[] temp = (object[]) data;
        skillTextBox.SetActive(true);
        skillText.text = (string) temp[0];
        Debug.Log(temp[0]);
    }

    public void HideText(){
        skillTextBox.SetActive(false);
    }
}
