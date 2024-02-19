using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public static int currentViewIndex;
    private int openCamIndex, LeftRightIndex;
    private bool canMoveCam, canActivate;

    //Camera
    [SerializeField] private Camera PlayerCam, SercruityCam;

    // public GameObject CamDisplay;
    //CCTV View
    [SerializeField] private GameObject[] AllRooms;

    //CamBtn 
    [SerializeField] private Button[] AllCamBtn;

    //Boundary
    private Vector2 screenBound;
    private float camWidth;
    private float camHeight;
    [SerializeField] CameraAnomaly cameraAnomaly;
    [SerializeField]SpriteRenderer MapObj;

    // Start is called before the first frame update
    void Start()
    {
        SercruityCam.enabled = false;
        currentViewIndex = -1;
        openCamIndex = 0;
        canMoveCam = false;
        canActivate = true;
        CamBoundSetup();
    }

    private void setUpCamBtn()
    {
        for(int i = 0; i < AllCamBtn.Length; i++)
        {
            AllCamBtn[i].onClick.AddListener(() => changeCam(i));
        }
    }

    private void CamBoundSetup()
    {
     
        screenBound = new Vector2(MapObj.bounds.extents.x, MapObj.bounds.extents.y);

        camHeight = SercruityCam.orthographicSize;
        camWidth = camHeight * SercruityCam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        moveLeftRight();
    }

    public void checkCamera(bool onOff)
    {
        if (onOff)
        {

            if (canActivate)
            {
                canMoveCam = false;
                SercruityCam.transform.localPosition = new Vector3(0, 0, SercruityCam.transform.position.z);
                StartCoroutine(delayMovingCam(1));
                canActivate = false;
                PlayerCam.enabled = false;
                SercruityCam.enabled = true;
            }

            currentViewIndex = openCamIndex;
           
            displayCorrectCam();
        }
        else
        {
            openCamIndex = currentViewIndex;
            currentViewIndex = -1;
            canMoveCam = false;
            canActivate = true;
            PlayerCam.enabled = true;
            SercruityCam.enabled = false;
        }
      
    }

    public void notViewingCam()
    {
        currentViewIndex = -1;
    }
    public void changeCam(int value)
    {
        currentViewIndex = value;
        LeftRightIndex = Random.Range(0, 2);
        canMoveCam = false;
        StartCoroutine(delayMovingCam(1));
        SercruityCam.transform.localPosition = new Vector3(0, 0, SercruityCam.transform.position.z);
        displayCorrectCam();
        
    }

    public void moveLeftRight()
    {
        if (!canMoveCam)
        {
            return;
        }
        
        if(LeftRightIndex == 0)
        {
            if (SercruityCam.transform.position.x <= screenBound.x * -1 + camWidth)
            {
                canMoveCam = false;
                StartCoroutine(delayMovingCam(1.5f));
                LeftRightIndex = 1;
            }
            else
            {
                SercruityCam.transform.position -= Vector3.right * 1.5f * Time.deltaTime;
            }
        }
        else
        {
            if (SercruityCam.transform.position.x >= screenBound.x - camWidth)
            {
                canMoveCam = false;
                StartCoroutine(delayMovingCam(1.5f));
                LeftRightIndex = 0;
            }
            else
            {
                SercruityCam.transform.position += Vector3.right * 1.5f * Time.deltaTime;
            }
        }

        Vector3 viewPos = SercruityCam.transform.position;

        viewPos.x = Mathf.Clamp(viewPos.x, screenBound.x * -1 + camWidth, screenBound.x - camWidth);
        SercruityCam.transform.position = viewPos;
    }

    public void displayCorrectCam()
    {

        for(int i = 0; i < AllRooms.Length; i++)
        {
            if(i == currentViewIndex)
            {
                AllRooms[i].SetActive(true);
            }
            else
            {
                AllRooms[i].SetActive(false);
            }
        }

        for(int i = 0; i < AllCamBtn.Length; i++)
        {
            if(i == currentViewIndex)
            {
                AllCamBtn[i].interactable = false;
            }
            else
            {
                AllCamBtn[i].interactable = true;
            }
        }
        cameraAnomaly.purple(currentViewIndex);
    }

    IEnumerator delayMovingCam(float value)
    {
        yield return new WaitForSeconds(value);
        canMoveCam = true;
    }
}
