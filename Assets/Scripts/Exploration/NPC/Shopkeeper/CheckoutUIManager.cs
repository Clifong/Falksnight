using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckoutUIManager : MonoBehaviour
{
    public Transform content;
    public GameObject checkoutPanel;
    public TextMeshProUGUI costText;
    private List<GameObject> icons = new List<GameObject>();

    public void InstantiateData(Component component, object obj) {
        foreach (GameObject icon in icons)
        {   
            Destroy(icon);
        }
        checkoutPanel.SetActive(true);
        object[] temp = (object[]) obj;
        List<ItemSO> stackOfItemsBought = (List<ItemSO>) temp[0];
        List<WeaponSO> stackOfWeaponsBought = (List<WeaponSO>) temp[1];
        costText.text = "Total cost: " + ((int) temp[2]).ToString();
        foreach (ItemSO item in stackOfItemsBought)
        {
            GameObject icon = Instantiate(item.itemWithGridImageAndName, content);
            icons.Add(icon);
        }
        foreach (WeaponSO weapon in stackOfWeaponsBought)
        {
            GameObject icon = Instantiate(weapon.weaponInSphereAndName, content);
            icons.Add(icon);
        }
    }
}
