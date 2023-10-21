using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCollectionManager : MonoBehaviour
{
    [SerializeField]
    private List<PlantSO> allPlantSO;
    public static PlantCollectionManager plantCollectionManager;
    private static int counter = 0;

    void Start()
    {
        if (PlantCollectionManager.counter >= 1){
            Destroy(this.gameObject);
        }
        plantCollectionManager = this;
        PlantCollectionManager.counter += 1;
        if (PlantCollectionManager.counter == 10){
            PlantCollectionManager.counter = 1;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public List<PlantSO> ReturnAllPlantSO() {
        return allPlantSO;
    }
}
