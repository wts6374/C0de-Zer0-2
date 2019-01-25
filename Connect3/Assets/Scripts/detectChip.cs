using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectChip : MonoBehaviour
{

    public GameObject chip;
    public int version;


    // Use this for initialization
    void Start()
    {
        version = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Detects when a bchips hit the bottom, beginning the process
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "RCube")
        {
            version = 1;
            chip = other.gameObject;
        }
        else if (other.gameObject.tag == "BCube")
        {
            version = 0;
            chip = other.gameObject;
        }

}
}
