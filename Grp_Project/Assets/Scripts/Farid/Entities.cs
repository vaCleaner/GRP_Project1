using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
    [SerializeField] private Generator genScript;


    float timer;

    public SpriteRenderer Changedstage;

    public Sprite[] changesprite;

    public GameObject EntitiesGameObject, JumpscareObj;

    float timeforbocan;

    bool ischange;

    private void Start()
    {
        ischange = false;
        timeforbocan = 0;
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
                case 2:
                {
                    Changedstage = EntitiesGameObject.GetComponent<SpriteRenderer>();
                    StartCoroutine(StartTimerr());
                    Debug.Log("ok");
                    break;
                }

            }
           
        



    }

    public void bocandabocan()
    {
        
       

    }

    IEnumerator StartTimerr()
    {
        while (timeforbocan < 40 && EntitiesGameObject != null)
        {
          
            timeforbocan += Time.deltaTime;
              Debug.Log("timer is running" + timeforbocan);
             if(timeforbocan >= 10 && ischange ==false)
             {
               Changedstage.sprite = changesprite[0];
                ischange = true;
             }
             if(timeforbocan >= 25 && ischange== true)
            {
                Changedstage.sprite = changesprite[1];

            }
            yield return null;
           
        }
       
        if (timeforbocan >= 40)
            {
            AudioManager.instance.Play("Jumpscare_SFX");
            JumpscareObj.SetActive(true);
            yield return new WaitForSeconds(3);
            GameManager.GM.GameStop(false);
            }

    }

}