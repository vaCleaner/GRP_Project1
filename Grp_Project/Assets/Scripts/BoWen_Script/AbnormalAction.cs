using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbnormalAction
{
    public enum RoomName {Diner = 0, Kitchen =1 , Storage = 2, Toilet_Hall_Way = 3, Room5 = 4};
    public RoomName Location;

    public enum AbnormalTypes { Item_Changes_Place = 0, Missing_Item = 1, Abnormal3 = 2, Abnormal4 = 3, Abnormal5 = 4 };
    public AbnormalTypes TypesOfAbnormal;
}
