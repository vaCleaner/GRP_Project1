using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class activeAbnormalActivites
{
    public string RoomName;
    public List<AbnormalAction> ActiveAbnormal;
    
}

public class GameManager : MonoBehaviour
{
    private float Seconds, Minute, nextSpawnTime;
    private int Hour, modulNum;
    private string AmOrPm;
    private int RandomRoomIndex;
    private int currentNight, difficultyLevel;
    [SerializeField] private Text TimeDisplay;
    [SerializeField]private ListOfAbnormal[] AllAbnormalList;
    [SerializeField]private activeAbnormalActivites[] activeAbnormals = new activeAbnormalActivites[5];
    [SerializeField]private Displayed_Rooms[] ListOfRooms;
    [SerializeField]private SendAbnormalResult sendResultScript;
    [SerializeField] private LevelData[] AllLevelData;
    private ReportResult currentResult = new ReportResult();
    public bool GameIsOver;

    public static GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        if(GM == null)
        {
            GM = this;
        }
        else
        {
            Destroy(gameObject);
        }

        GameIsOver = false;
        AmOrPm = "PM";
        modulNum = 13;
        Seconds = 46800;
        //Seconds = 39600;
        difficultyLevel = 0;
        currentNight = 0;
        nextSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        timeCalculation();
        checkGameProgression();

    }

    public void addRandomAbnormal()
    {
        RandomRoomIndex = randomRoom();

        if(calculateTotalAbnormal() < 10)
        {
           
            if (activeAbnormals[RandomRoomIndex].ActiveAbnormal.Count < AllAbnormalList[RandomRoomIndex].ListOfAbnormalData.Length)
            {
                AbnormalAction currentAbnormal = getAbnormalData();
                activeAbnormals[RandomRoomIndex].ActiveAbnormal.Add(currentAbnormal);
                ListOfRooms[RandomRoomIndex].setAbnormal(currentAbnormal, false);
            }
            else
            {
                addRandomAbnormal();
            }
        }
        else
        {
            
        }

     
    }

    public void GameStop(bool WinLose)
    {
        GameIsOver = true;

        if (WinLose)
        {
            difficultyLevel = 1;
        }
        else
        {
            difficultyLevel = 2;
        }
    }

    public void CheckAbnormal(AbnormalAction reciveData)
    {
        currentResult = new ReportResult();
        int roomIndex = (int)reciveData.Location;
        if (activeAbnormals[roomIndex].ActiveAbnormal.Count > 0)
        {
            bool gotItRight = false;

            foreach (AbnormalAction Data in activeAbnormals[roomIndex].ActiveAbnormal)
            {
                if (reciveData.Location == Data.Location && reciveData.TypesOfAbnormal == Data.TypesOfAbnormal)
                {
                    gotItRight = true;
                    activeAbnormals[roomIndex].ActiveAbnormal.Remove(Data);
                    ListOfRooms[roomIndex].setAbnormal(reciveData, true);

                    reportLog(reciveData, "Success");
                    break;
                }
            }

            if (!gotItRight)
            {
                reportLog(reciveData, "Fail");
            }
        }
        else
        {
            reportLog(reciveData, "There is no Abnormal");
        }

       
    }

    public void timeCalculation()
    {
        Seconds += 30 * Time.deltaTime;
        Minute = Mathf.FloorToInt((Seconds / 60) % 60);
        Hour = Mathf.FloorToInt((Seconds / 60 / 60) % modulNum);

        if(Seconds >= 46800)
        {
            modulNum = 12;
            AmOrPm = "AM";
        }
        else
        {
            modulNum = 13;
            AmOrPm = "AM";
        }

        TimeDisplay.text =  string.Format("{0:00}:{1:00} " + AmOrPm, Hour, Minute);

        if (Hour == 6)
        {
            GameStop(true);
        }
    }

    public void checkGameProgression()
    {
        if(Seconds < 45000)
        {
            return;
        }

        if(Hour == 2)
        {
            difficultyLevel = 1;
        }
        else if(Hour == 4)
        {
            difficultyLevel = 2;
        }
        
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + AllLevelData[currentNight].EverySecTier[difficultyLevel];
            addRandomAbnormal();
        }

    }

    private void reportLog(AbnormalAction data, string status)
    {
        currentResult.ResultStauts = status;
        currentResult.RoomName = data.Location.ToString();
        currentResult.AbnormalName = data.TypesOfAbnormal.ToString();
        currentResult.TimeReported = string.Format("{0:00}:{1:00} " + AmOrPm, Hour, Minute);

        sendResultScript.RecordResult(currentResult);

    }

    public AbnormalAction getAbnormalData()
    {
        int getSpawnChance = Random.Range(1, 101);
        bool repeat = true;
        AbnormalAction selectedAbnormal = null;

        do
        {
            repeat = false;
            foreach (AllAbnormlData currentAbnormal in AllAbnormalList[RandomRoomIndex].ListOfAbnormalData)
            {
                if (getSpawnChance >= currentAbnormal.ChanceRateMinimum && getSpawnChance <= currentAbnormal.ChanceRateMaximum)
                {
                    selectedAbnormal = currentAbnormal.AbnormalData;
                }
            }

            foreach (AbnormalAction gottenData in activeAbnormals[RandomRoomIndex].ActiveAbnormal)
            {
                if (selectedAbnormal == gottenData)
                {
                    getSpawnChance = Random.Range(1, 101);
                    repeat = true;
                    break;
                }
                
            }
        } while (repeat);




        return selectedAbnormal;
    }

    public int calculateTotalAbnormal()
    {
        int counter = 0;
        for(int i = 0; i < activeAbnormals.Length; i++)
        {
            counter += activeAbnormals[i].ActiveAbnormal.Count;
        }

        return counter;
    }

    public int randomRoom()
    {
        
        int randomIndex = Random.Range(0, AllAbnormalList.Length);
        while(randomIndex == CameraScript.currentViewIndex)
        {
            randomIndex = Random.Range(0, AllAbnormalList.Length);
        }
        return randomIndex;
    }


}
