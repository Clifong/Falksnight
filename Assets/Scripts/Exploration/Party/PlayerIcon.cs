using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

// IBeginDragHandler, IEndDragHandler
public class PlayerIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Slider healthSlider;
    public TextMeshProUGUI name;
    public TextMeshProUGUI healthValue;
    private Transform parentAfterDrag;
    public Image image;
    private Transform originalParent;
    private PlayerSO playerSO;
    
    public void SetField(PlayerSO playerSO){
        this.playerSO = playerSO;
        name.text = playerSO.name;
        originalParent = transform.parent.parent;
        healthSlider.value = playerSO.getHealthRatio();
        playerSO.SetHealthText(healthValue);
    }

    public PlayerSO GetPlayerSO() {
        return playerSO;
    }

    public void OnBeginDrag(PointerEventData eventData){
        ChangeParent(transform.parent);
        transform.SetParent(transform.parent.parent.parent);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        SetObjectParent();
    }

    private void SetObjectParent() {
        transform.SetParent(parentAfterDrag);
    }

    public void ChangeParent(Transform parent) {
        parentAfterDrag = parent;
    }
}
