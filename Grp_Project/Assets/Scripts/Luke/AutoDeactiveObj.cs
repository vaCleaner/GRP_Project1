using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeactiveObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactiveSelf()
    {
        this.gameObject.SetActive(false);
    }
}
