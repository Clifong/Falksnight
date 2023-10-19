using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerIcon : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI name;
    public TextMeshProUGUI healthValue;
    
    public void SetField(PlayerSO playerSO){
        name.text = playerSO.name;
        healthSlider.value = playerSO.getHealthRatio();
        healthValue.text = playerSO.currentHealth.ToString() + "/" + playerSO.baseHealth.ToString();
    }
}
