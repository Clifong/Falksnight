using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpawnManager : MonoBehaviour
{
    public static EnergySpawnManager energySpawnManager;
    public GameObject mainAttackGrid; //A grid representing the arema
    public GameObject energyBall; //Energy ball to spawn
    private List<Transform> attackGrid = new List<Transform>(); //Individual grid
    private int turnCooldown; //Cooldown before spawning some energy

    [SerializeField]
    private int minNumberOfEnergyToSpawn; //Min number of energy to spawm
    [SerializeField]
    private int maxNumberOfEnergyToSpawn; //Max number of energy to spawm

    // Start is called before the first frame update
    void Start()
    {
        if (energySpawnManager != null){
            Destroy(energySpawnManager);
        }
        energySpawnManager = this;
        Transform mainAttackGridTransform = mainAttackGrid.GetComponent<Transform>();
        foreach (Transform gridChild in mainAttackGridTransform)
        {
            attackGrid.Add(gridChild);            
        }
        SpawnEnergy();
    }

    public void SpawnEnergy(){
        int numberOfEnergyToSpawn = Random.Range(minNumberOfEnergyToSpawn, maxNumberOfEnergyToSpawn);
        for (int i = 0; i < numberOfEnergyToSpawn; i++){
            int index = Random.Range(0, attackGrid.Count - 1);
            GameObject spawnedEnergyBall = Instantiate(energyBall, attackGrid[i].transform);
            spawnedEnergyBall.transform.localPosition = Vector3.zero;
        }   
    }
}
