using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGainedStack : CrossObjecEventListenerWithData
{
    public Transform content;
    private List<ItemSO> thingsToAppear = new List<ItemSO>();
    private List<GameObject> spawnedObjects = new List<GameObject>();
    public GameObject itemStack;

    public override void TriggerEvent(Component sender, object data) {
        itemStack.SetActive(true);
        foreach (ItemSO item in (List<ItemSO>)data)
        {
            thingsToAppear.Add(item);
        }
        foreach (ItemSO item in thingsToAppear)
        {
            GameObject spawned = Instantiate(((ItemSO) item).itemWithGridImageAndName, content);
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
