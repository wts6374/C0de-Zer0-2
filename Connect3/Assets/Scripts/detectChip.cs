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

    //Detects when a bchips hit a grid, picking up on the chips properties and saving them
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "RCube")
        {
            version = other.gameObject.GetComponent<Chips>().chipNumCode-1;
            chip = other.gameObject;
        }


}
}
