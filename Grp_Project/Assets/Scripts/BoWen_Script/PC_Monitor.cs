﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Monitor : MonoBehaviour
{
    public GameObject PCMonitor;
    [SerializeField]private CameraScript camScript;
    [SerializeField] private SendAbnormalResult reportScript;

    private int leftOffIndex;
    private bool canOpen;
    // Start is called before the first frame update
    void Start()
    {
        leftOffIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMonitor();
    }

    public void CheckTab(int index)
    {
        leftOffIndex = index;
        switch (index)
        {
            case 0:
                camScript.checkCamera(true);
                reportScript.checkReport(false);
                break;

            case 1:
                reportScript.checkReport(true);
                camScript.notViewingCam();
                break;
        }
       
    }

    public void CheckMonitor()
    {
        if (!canOpen)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!PCMonitor.activeSelf)
            {
                PCMonitor.SetActive(true);
                CheckTab(leftOffIndex);
            }
            else
            {
                camScript.checkCamera(false);
                reportScript.checkReport(false);
                PCMonitor.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpen = false;
        }
    }
}