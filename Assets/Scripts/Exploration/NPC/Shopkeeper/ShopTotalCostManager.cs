using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopTotalCostManager : MonoBehaviour
{
    public TextMeshProUGUI totalCostText;

    public void ChangeCostText(int amount) {
        totalCostText.text = amount.ToString();
    }
}
