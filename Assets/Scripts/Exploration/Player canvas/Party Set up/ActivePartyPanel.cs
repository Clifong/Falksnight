using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivePartyPanel : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        GameObject dropped = eventData.pointerDrag;
        PlayerIcon droppedIcon = dropped.GetComponent<PlayerIcon>();
        if (droppedIcon != null) {
            droppedIcon.ChangeParent(transform);
        }
    }
}
