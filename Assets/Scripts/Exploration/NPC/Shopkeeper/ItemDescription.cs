using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDescription : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public void SetUIInfo(Component component, object data) {
        ItemSO itemSO = (ItemSO) data;
        itemImage.sprite = itemSO.itemImage;
        nameText.text = itemSO.name;
        descriptionText.text = itemSO.description;
    }
}
