using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public Text DisplayIntro;
    public IntructionScriptable[] listofIntruction = new IntructionScriptable[1];
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(displayInstructionA());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator displayInstructionA()
    {
        int counter = 0;
        yield return new WaitForSeconds(1);
        Panel.SetActive(true);
        while (counter < listofIntruction.Length)
        {
            DisplayIntro.text = listofIntruction[counter].instructionText;
            yield return new WaitForSeconds(7);
            counter++;


        }
        Panel.SetActive(false);



    }
}
