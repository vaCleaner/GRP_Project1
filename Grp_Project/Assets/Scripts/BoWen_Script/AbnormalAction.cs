using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbnormalAction
{
    public enum RoomName {Diner = 0, Kitchen =1 , Storage = 2, Toilet_Hall_Way = 3, Room5 = 4};
    public RoomName Location;

    public enum AbnormalTypes { Object_Moved_Abnormalities = 0, Missing_Item = 1, Add_Item = 2, Camera_Abnormalities = 3, Entities = 4 , Change_Object_abnormalities = 5};
    public AbnormalTypes TypesOfAbnormal;
}
