using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ReportResult
{
    public string RoomName;
    public string AbnormalName;
    public string TimeReported;
    public string ResultStauts;
}

public class SendAbnormalResult : MonoBehaviour
{
    [SerializeField] private Button sendButton;
    [SerializeField] private AbnormalAction AbnormalResult;
    [SerializeField]private Dropdown roomValue, abnormalValue;
    [SerializeField]private GameObject checkReportPanel;
    [SerializeField] private GameObject resultPanel, PanelHolder, PanelObj;
    [SerializeField]private Slider ProgressBar;
    [SerializeField] private List<ReportResult> RecordedResult = new List<ReportResult>();
    private float Timer;

    // Start is called before the first frame update
    void Awake()
    {
        RecordedResult = new List<ReportResult>();
        ProgressBar.maxValue = 5;
        ProgressBar.gameObject.SetActive(false);
        sendButton.onClick.AddListener(sendResult);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkReport(bool OnOff)
    {
        checkReportPanel.SetActive(OnOff);

        roomValue.value = 0;
        abnormalValue.value = 0;
        AbnormalResult = new AbnormalAction();

        if (!OnOff)
        {
            resultPanel.SetActive(false);
        }
    }

    public void checkResultPanel()
    {
        if (resultPanel.activeSelf)
        {
            resultPanel.SetActive(false);
        }
        else
        {
            resultPanel.SetActive(true);
        }
        
    }

    public void sendResult()
    {
        roomValue.interactable = false;
        abnormalValue.interactable = false;
        sendButton.interactable = false;
        int roomIndex = roomValue.value;
        int abnormalIndex = abnormalValue.value;

        AbnormalResult.Location = (AbnormalAction.RoomName)roomIndex;
        AbnormalResult.TypesOfAbnormal = (AbnormalAction.AbnormalTypes)abnormalIndex;

        StartCoroutine(sendTimer());
    }

    public void DisplayResult()
    {
        GameObject currentObj = Instantiate(PanelObj, PanelHolder.transform);
        currentObj.transform.SetAsFirstSibling();
        currentObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = RecordedResult[0].RoomName;
        currentObj.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = RecordedResult[0].AbnormalName;
        currentObj.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = RecordedResult[0].ResultStauts;
        currentObj.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = RecordedResult[0].TimeReported;
    }

    public void RecordResult(ReportResult results)
    {
        RecordedResult.Insert(0,results);
        DisplayResult();
    }

    IEnumerator sendTimer()
    {
        Timer = 0;
        ProgressBar.gameObject.SetActive(true);
        ProgressBar.value = 0;
        while(Timer < 5)
        {
            Timer += Time.deltaTime;
            ProgressBar.value = Timer;
            yield return null;
        }

        ProgressBar.gameObject.SetActive(false);
        GameManager.GM.CheckAbnormal(AbnormalResult);
        sendButton.interactable = true;
        roomValue.interactable = true;
        abnormalValue.interactable = true;  
        roomValue.value = 0;
        abnormalValue.value = 0;
        AbnormalResult = new AbnormalAction();
    }


}
