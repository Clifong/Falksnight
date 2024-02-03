using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGainedStack : CrossObjecEventListenerWithData
{
    public Transform content;
    private List<Item> thingsToAppear = new List<Item>();
    private List<GameObject> spawnedObjects = new List<GameObject>();
    public GameObject itemStack;

    public override void TriggerEvent(Component sender, object data) {
        itemStack.SetActive(true);
        foreach (Item item in (List<Item>)data)
        {
            thingsToAppear.Add(item);
        }
        foreach (Item item in thingsToAppear)
        {
            GameObject spawned = Instantiate(((Item) item).itemWithGridImageAndName, content);
            spawnedObjects.Add(spawned);
        }
        StartCoroutine(DisappearAfterAWhile());
    }

    IEnumerator DisappearAfterAWhile() {
        yield return new WaitForSeconds(3.5f);
        itemStack.SetActive(false);
        foreach (GameObject spawn in spawnedObjects)
        {
            Destroy(spawn);
        }
    }
}
