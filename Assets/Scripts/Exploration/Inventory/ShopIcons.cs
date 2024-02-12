using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopIcons : MonoBehaviour
{
    public Image image;
    protected bool isPurchasing = false;
    
    public void UnselectThis() {
        image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void SelectThis() {
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    public virtual void SetDataForCrossObjectEventWithData() {}

    public virtual void ChangeBuyingForSingleBuy() {}
}
