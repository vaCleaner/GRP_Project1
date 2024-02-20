using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
    [SerializeField] private Generator genScript;


    float timer;



    public GameObject EntitiesGameObject;





    private void Start()
    {

    }

    private void Update()
    {

    }

    public void Lukky(int ids)
    {


       
        

            switch(ids)
            {
                case 1:
                    {

                        genScript.DeactivateGenerators();
                        Debug.Log("yes");
                        break;
                    }

            }
           
        



    }

}