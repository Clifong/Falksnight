using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackUIManager : MonoBehaviour
{
    public static AttackUIManager attackUIManager;
    // private Player playerSelected;
    public GameObject skillIcon;
    public GameObject attackButton;
    public Canvas attackUICanvas;
    public Slider playerHealth;
    public GameObject damageTextParent;
    private TextMeshPro damageText;
    private Player currentPlayer;
    
    [SerializeField]
    private Transform contentTransform;
    private List<GameObject> spawnedSkillIcons = new List<GameObject>();
    
    void Awake()
    {
        if (attackUIManager != null){
            Destroy(attackUIManager);
        }
        attackUIManager = this;
        damageText = damageTextParent.GetComponentInChildren<TextMeshPro>();
    }

    void Update(){
        if (currentPlayer != null){
            playerHealth.value = currentPlayer.GetCurrentHealthRatio();
        }
    }

    //Responsible for targeting and skillIcons creation
    public void SelectPlayer(Player player){
        currentPlayer = player;
        PlayerSO playerSO = player.GetPlayerSO();
        foreach (GameObject spawnedSkillicon in spawnedSkillIcons)
        {
            Destroy(spawnedSkillicon);
        }
        foreach (SkillsSO skillSO in playerSO.skillSet)
        {
            GameObject spawnedSkillicon = Instantiate(skillIcon, contentTransform);
            spawnedSkillicon.GetComponent<SkillIcon>().SetSkillSO(skillSO);
            spawnedSkillIcons.Add(spawnedSkillicon);
        }
    }

    public void AllPartyMembersActionsSelected(){
        attackButton.SetActive(true);
    }

    public void HidePlayerUIElements(){
        attackButton.SetActive(false);
        attackUICanvas.enabled = false;
    }

    public void ShowPlayerUIElements(){
        attackUICanvas.enabled = true;
    }

    public void InstantiateDamageText(Vector2 pos, int damage, bool critOrNot){
        if (critOrNot) {
            damageText.color = new Color(1,0,0,1);
        }
        else {
            damageText.color = new Color(1,1,1,1);
        }
        damageText.text = damage.ToString();
        Instantiate(damageTextParent, pos, Quaternion.identity);
    }
    
}
