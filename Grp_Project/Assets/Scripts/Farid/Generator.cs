using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject generator;
    [SerializeField] private Light light;
    private float timer;

    private void Start()
    {
        
        
    }

    private void Update()
    {
        
    }

    public void DeactivateGenerators()
    {
        StartTimerr();
        if(timer>= 15)
        {
            // off light
            light.gameObject.SetActive(false);

            return;

        }
        Debug.Log("YES");

    }

    public void StartTimerr()
    {
        timer += Time.deltaTime;

    }


    

}
