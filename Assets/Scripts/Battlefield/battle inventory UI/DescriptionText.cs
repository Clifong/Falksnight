using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionText : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetDescriptionText(Component component, object data) {
        object[] temp = (object[]) data;
        text.text = ((ItemSO) temp[0]).description;
    }
}
