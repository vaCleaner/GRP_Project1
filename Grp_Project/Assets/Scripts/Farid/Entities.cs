using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
   [SerializeField] private Generator genScript;

    public int ids = 0;

    float timer, Botimer;
    
    public GameObject EntitiesLuky;

    public GameObject EntitiesFaroid;

    public GameObject EntitiesBocan;



    private void Start()
    {
       
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Lukky();
    }

    public void Lukky()
    {
        
        if(EntitiesLuky.activeSelf == true)
        {
            if (timer > 15)
            {
                 genScript.DeactivateGenerators();
                  Debug.Log("yes");
            }
        }
      


    }

    private void Faroid()
    {

        if(EntitiesFaroid.activeSelf == true)
        {



        }


    }

    private void Bocan()
    {


        if (EntitiesBocan.activeSelf == true)
        {

            StartBotimer();

        }


    }

    private void IsEntitiesPresent()
    {




    }

    public void StartBotimer()
    {

        Botimer += Time.deltaTime;
    }




}
