using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDescription : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI descriptionText;

    public void SetUIInfo(Component component, object data) {
        ItemSO itemSO = (ItemSO)((object[]) data)[0];
        itemImage.sprite = itemSO.itemImage;
        nameText.text = itemSO.name;
        descriptionText.text = itemSO.description;
        costText.text = itemSO.cost.ToString();
    }
}
