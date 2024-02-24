using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackUIManager : MonoBehaviour
{
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
        damageText = damageTextParent.GetComponentInChildren<TextMeshPro>();
    }

    void Update(){
        if (currentPlayer != null){
            playerHealth.value = currentPlayer.GetCurrentHealthRatio();
        }
    }

    //Responsible for targeting and skillIcons creation
    public void SelectPlayer(Component component, object data){
        object[] temp = (object[]) data;
        Player player = (Player) temp[0];
        currentPlayer = player;
        PlayerSO playerSO = currentPlayer.GetPlayerSO();
        foreach (GameObject spawnedSkillicon in spawnedSkillIcons)
        {
            Destroy(spawnedSkillicon);
        }
        foreach (SkillsSO skillSO in playerSO.skillSet)
        {
            GameObject spawnedSkillicon = Instantiate(skillIcon, contentTransform);
            SkillIcon skillIconScript = spawnedSkillicon.GetComponent<SkillIcon>();
            skillIconScript.SetSkillSO(skillSO);
            player.CheckIfThisSkillIsUsed(skillSO, skillIconScript);
            spawnedSkillIcons.Add(spawnedSkillicon);
        }
    }

    public void AllPartyMembersActionsSelected(){
        attackButton.SetActive(true);
    }

    public void SpawnDamageText(Component component, object data){
        object[] temp = (object[]) data;
        Vector3 pos = (Vector3) temp[0];
        int damage = (int) temp[1];
        bool critOrNot = (bool) temp[2];
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
