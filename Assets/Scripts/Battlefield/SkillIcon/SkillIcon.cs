using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite selectedVersion;
    public Sprite unselectedVersion;
    private SkillsSO skillSO;
    private bool mouse_over;
    public GameObject aboutSkillPopup;
    public TextMeshProUGUI aboutSkillText;
    [SerializeField]
    private TextMeshProUGUI skillName;
    public Image image;
    private bool unselected = true;
    public CrossObjectEventWithData selectThisSkill;

    private void Start() {
        skillName.text = skillSO.name;
    }

    public void SetSkillSO(SkillsSO skillSO){
        this.skillSO = skillSO;
    }

    public void TellCharacterToAttackEnemy(){
        selectThisSkill.TriggerEvent(this, this.skillSO, this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        aboutSkillText.text = skillSO.description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;

    }

    void Update()
    {
        if (mouse_over) {
            aboutSkillPopup.SetActive(true);
        } else {
            aboutSkillPopup.SetActive(false);
        }
    }

    public void Switch() {
        if (unselected) {
            image.sprite = selectedVersion;
            unselected = false;
        } else {
            image.sprite = unselectedVersion;
            unselected = true;
        }
    }

    public void NotAttacking() {
        image.sprite = unselectedVersion;
        unselected = true;
    }
}
