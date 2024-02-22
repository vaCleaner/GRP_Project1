using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displayed_Rooms : MonoBehaviour
{
    [SerializeField] private GameObject[] MoveableObject = new GameObject[1];
    [SerializeField] private GameObject[] RemoveableObj = new GameObject[1];
    [SerializeField] private Transform[] ListOfPos = new Transform[1];

    [SerializeField] private GameObject[] SpawnAnomaly = new GameObject[1];
    [SerializeField] private Transform[] SetPosAnomaly = new Transform[1];

    public ChangeSpriteClass[] ChangeTheSprrite;

    int Checkindex;

    private GameObject selectedMoveObj, savedObject, saveEntitieso;
    private Vector3 saveMovingPos;

    [SerializeField] private int Roomids;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnAnomaly(bool report)
    {
        if (report)
        {
            Destroy(savedObject.gameObject);
        }
        else
        {
            int randomNumber = Random.Range(0, SpawnAnomaly.Length);
            int randomPosition = Random.Range(0, SetPosAnomaly.Length);
            savedObject = Instantiate(SpawnAnomaly[randomNumber], SetPosAnomaly[randomPosition]);
        }
    }

    public void SpawnEntites(bool Clearit)
    {
        if (Clearit)
        {
           Destroy(saveEntitieso.gameObject);
          
        }
        else
        {
            saveEntitieso = SpawnerEntities.Staticscript.Spawner(Roomids,this.transform);
        }
    }


    public void setAbnormal(AbnormalAction category, bool clear)
    {
        switch (category.TypesOfAbnormal)
        {
            case AbnormalAction.AbnormalTypes.Object_Moved_Abnormalities:
                changeObjPos(clear);
                break;

            case AbnormalAction.AbnormalTypes.Missing_Item:
                RemoveObj(clear);
                break;

            case AbnormalAction.AbnormalTypes.Add_Item:
                spawnAnomaly(clear);
                break;

            case AbnormalAction.AbnormalTypes.Change_Object_abnormalities:
                ChangeSpriteAdnomalies(clear);
                break;

            case AbnormalAction.AbnormalTypes.Entities:
                SpawnEntites(clear);
                break;

            default:
                Debug.Log("Invalid Abnormal");
                break;
        }
    }
    private void ChangeSpriteAdnomalies(bool IsChange)
    {

        if(IsChange)
        {

            for (int i = 0; i < ChangeTheSprrite[Checkindex].ChangeSprite.Length; i++ )
            {

                ChangeTheSprrite[Checkindex].ChangeSprite[i].sprite = ChangeTheSprrite[Checkindex].StoreOriginal[i];
            }

        }
        else
        {

            for (int i = 0; i < ChangeTheSprrite[Checkindex].ChangeSprite.Length; i++)
            {
                ChangeTheSprrite[Checkindex].StoreOriginal[i] = ChangeTheSprrite[Checkindex].ChangeSprite[i].sprite;
                ChangeTheSprrite[Checkindex].ChangeSprite[i].sprite = ChangeTheSprrite[Checkindex].StoreSprite;
            }


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
            Vector3 randomSpawnPos = new Vector3(Random.Range(ListOfPos[randomPosIndex].position.x - 0.1f, ListOfPos[randomPosIndex].position.x + 0.1f), Random.Range(ListOfPos[randomPosIndex].position.y - 0.1f, ListOfPos[randomPosIndex].position.y + 0.1f), 0);
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
