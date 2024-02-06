using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displayed_Rooms : MonoBehaviour
{
    [SerializeField] private GameObject[] MoveableObject = new GameObject[1];
    [SerializeField] private GameObject[] RemoveableObj = new GameObject[1];
    [SerializeField] private Transform[] ListOfPos = new Transform[1];
    private GameObject selectedMoveObj;
    private Vector3 saveMovingPos;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void setAbnormal(AbnormalAction category, bool clear)
    {
        switch (category.TypesOfAbnormal)
        {
            case AbnormalAction.AbnormalTypes.Item_Changes_Place:
                changeObjPos(clear);
                break;

            case AbnormalAction.AbnormalTypes.Missing_Item:
                RemoveObj(clear);
                break;

            case AbnormalAction.AbnormalTypes.Abnormal3:

                break;

            case AbnormalAction.AbnormalTypes.Abnormal4:

                break;

            case AbnormalAction.AbnormalTypes.Abnormal5:

                break;

            default:
                Debug.Log("Invalid Abnormal");
                break;
        }
    }

    private void changeObjPos(bool clearIt)
    {
        if (clearIt)
        {
            selectedMoveObj.transform.position = saveMovingPos;
            selectedMoveObj = null;
            saveMovingPos = Vector3.zero;
        }
        else
        {
            int randomIndex = Random.Range(0, MoveableObject.Length);
            int randomPosIndex = Random.Range(0, ListOfPos.Length);
            selectedMoveObj = MoveableObject[randomIndex];
            saveMovingPos = selectedMoveObj.transform.position;
            Debug.Log(randomPosIndex);
            Vector3 randomSpawnPos = new Vector3(Random.Range(ListOfPos[randomPosIndex].position.x - 2f, ListOfPos[randomPosIndex].position.x + 2f), Random.Range(ListOfPos[randomPosIndex].position.y - 2f, ListOfPos[randomPosIndex].position.y + 2f), 0);
            MoveableObject[randomIndex].transform.position = randomSpawnPos;
        }
      
    }

    private void RemoveObj(bool clearIt)
    {
        if (clearIt)
        {
            foreach (GameObject currentObj in RemoveableObj)
            {
                currentObj.SetActive(true);
            }
        }
        else
        {
            int RandomNum = Random.Range(0, RemoveableObj.Length);
            RemoveableObj[RandomNum].SetActive(false);
        }

    }
}
