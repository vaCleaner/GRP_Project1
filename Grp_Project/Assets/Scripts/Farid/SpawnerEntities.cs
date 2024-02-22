using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEntities : MonoBehaviour
{

    public List<SpawnEntities> spawn;
    public GameObject CurrentEntities;

    
    public Entities EntitiesOK;
    public static SpawnerEntities Staticscript;

    private void Start()
    {
        Staticscript = this;
    }
    
    public GameObject Spawner(int roomids , Transform Pos)
    {
       
        
            int getSpawnChance = Random.Range(1, 101);
        foreach (SpawnEntities currentEntities in spawn)
        {

            if (getSpawnChance >= currentEntities.minSpawn && getSpawnChance <= currentEntities.maxspawn)
            {
                CurrentEntities = Instantiate(currentEntities.Entities,Pos);
                CurrentEntities.transform.position = currentEntities.instances[roomids].Position;
                Debug.Log("i was here");
                EntitiesOK.EntitiesGameObject = CurrentEntities;
                EntitiesOK.Lukky(currentEntities.idss);
                spawn.Remove(currentEntities);

                break;


            }
           
        } 

          return CurrentEntities;

    }




}
