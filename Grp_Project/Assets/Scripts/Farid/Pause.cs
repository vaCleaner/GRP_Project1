using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public GameObject Pausepanel;
   
    private void Start()
    {
        Pausepanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Pausepanel.activeSelf == false)
        {
            Pausepanel.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Pausepanel.activeSelf == true)
        {
            Pausepanel.SetActive(false);
        }

    }

    public void resume()
    {
        Pausepanel.SetActive(false);
    }
    
    public void Restart()
    {
      SceneManager.LoadScene("MainMenu");
    }
    public void skillissue()
    {
        Application.Quit();
    }



}
