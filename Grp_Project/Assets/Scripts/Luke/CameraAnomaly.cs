﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnomaly : MonoBehaviour
{

    public GameObject BlackScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void purple(int value)
    {

        BlackScreen.SetActive(GameManager.GM.checkRoom(value));
    }
}