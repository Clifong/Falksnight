using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private Animator anime;
    [SerializeField]
    private List<Item> allItems;
  
    private void Start(){
        anime = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "target"){
            anime.SetTrigger("break");
        }
    }

    public void DestroyObject(){
        InventoryManager.inventoryManager.AddNewItems(allItems);
        Destroy(gameObject);
    }
}
