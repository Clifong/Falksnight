using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[CreateAssetMenu(fileName = "ConfidantItemSO", menuName = "ConfidantItemSO", order = 1)]
public class ConfidantItemSO : ScriptableObject
{
    public GameObject confidantItemWithGrid;
    public Sprite confidantItemIcon;
    public string name;
    public string description;
    public int relationshipExp;

    public void SetUIInfo(TextMeshProUGUI nameText, TextMeshProUGUI effectText, TextMeshProUGUI descriptionText, Image itemIcon) {
        itemIcon.sprite = confidantItemIcon;
        nameText.text = name;
        effectText.text = "Increase relationship by " + relationshipExp.ToString();
        descriptionText.text = description;
    }
}
