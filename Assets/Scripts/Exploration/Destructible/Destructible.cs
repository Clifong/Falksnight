using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private Animator anime;
    [SerializeField]
    private List<ItemSO> allItems;
    public CrossObjectEventWithData destroyObjectEvent;
  
    private void Start(){
        anime = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "target"){
            anime.SetTrigger("break");
        }
    }

    public void DestroyObject(){
        destroyObjectEvent.TriggerEvent(this, allItems);
        if (allItems != null && allItems.Count != 0) {
            InventoryManager.inventoryManager.AddNewItems(allItems);
        }
        Destroy(gameObject);
    }
}
