using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
  
    private float timer;

    [SerializeField] private PC_Monitor Offscreen;

    public static bool isGeneOff;
    private bool isrange;

    public Slider Sliderss;

    private float Minval;




    private void Start()
    {
        Sliderss.maxValue = 7;
        Sliderss.gameObject.SetActive(false);
    }

    private void Update()
    {
        ActivateGeni();
    }

    public void DeactivateGenerators()
    {
        StartCoroutine(StartTimerr());

      

    }
    public void ActivateGeni()
    {
        if(isGeneOff == true && isrange == true)
        {

            if(Input.GetKey(KeyCode.E))
            {

                Sliderss.gameObject.SetActive(true);
                Sliderss.value = Minval;

                Minval += Time.deltaTime;

                if(Minval >=7)
                {
                   
                    isGeneOff = false;
                    Sliderss.value = 0;
                    Minval = 0;
                    timer = 0;
                   
                    
                }



            }
            else
            {
                Minval = 0;
                Sliderss.gameObject.SetActive(false);

            }


        }
     
        

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isrange = true;
        }
        Debug.Log("HEheheha");



    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isrange = true;
        }
        Debug.Log("i am out");



    }
    IEnumerator StartTimerr()
    {
        while(timer <15)
        {

            timer += Time.deltaTime;
            Debug.Log("Timer" + timer);
           yield return null;

        }
        isGeneOff = true;
        Offscreen.Nopower();
        Debug.Log("off");

    }


    

}
