using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftItemButton : MonoBehaviour
{
    public void GiftItem() {
        GiftingManager.giftingManager.GiftItem();
    }
}
