using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LocationInfo
{
   
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;

    public LocationInfo(GameObject usedPrefab, Transform transform)
    {
       
        Rotation = transform.rotation;
        Position = transform.position;
        Scale = transform.localScale;
    }

    
}
[CreateAssetMenu]
public class SpawnEntities : ScriptableObject
{

    public GameObject Entities;
   
   public float minSpawn;
    public float maxspawn;
    public int idss;



    public List<LocationInfo> instances = new List<LocationInfo>();




}
