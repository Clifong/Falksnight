using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReservePartyPanel : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        GameObject dropped = eventData.pointerDrag;
        PlayerIcon droppedIcon = dropped.GetComponent<PlayerIcon>();
        droppedIcon.ChangeParent(transform);
        Debug.Log("Reserve");
    }
}
