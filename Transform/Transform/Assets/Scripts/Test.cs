using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
             this.transform.position = this.transform.position + new Vector3(0, 0, 1) * Time.deltaTime;
             
             // Direction Vector property
             //this.transform.up this.transfrom.right 
        } else if (Input.GetKey((KeyCode.J)))
        {
            this.transform.Rotate(new Vector3(90,0,0) * Time.deltaTime);   
        } else if (Input.GetKey(KeyCode.L))
        {
            this.transform.localScale = this.transform.localScale + new Vector3(2, 2, 2) * Time.deltaTime;
        }
    }
}
