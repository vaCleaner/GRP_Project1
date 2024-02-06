using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
   [SerializeField] private Generator genScript;

    public int ids = 0;

    float timer;

    public GameObject EntitiesLuky;

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



    }

    private void Bocan()
    {




    }

    private void IsEntitiesPresent()
    {



    }
}
