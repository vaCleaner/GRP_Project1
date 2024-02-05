using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AllAbnormlData
{
    public AbnormalAction AbnormalData;
    public float ChanceRateMinimum;
    public float ChanceRateMaximum;
} 

[CreateAssetMenu]
public class ListOfAbnormal : ScriptableObject
{
  public AllAbnormlData[] ListOfAbnormalData;
}
