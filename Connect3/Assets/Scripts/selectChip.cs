using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectChip : MonoBehaviour {

    public GameObject selector;
    public BoxCollider bg;

	// Use this for initialization
	void Start () {
        selector.transform.position = new Vector3(-6.5f, 4.01f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.W) && selector.transform.position.y<4.01f)
        {
            selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y+1.0f, 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.S) && selector.transform.position.y > -2.01f)
        {
            selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y-1.0f, 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.A) && selector.transform.position.x > -6.5f)
        {
            selector.transform.position = new Vector3(selector.transform.position.x-1.0f, selector.transform.position.y, 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.D) && selector.transform.position.x < 0.5f)
        {
            selector.transform.position = new Vector3(selector.transform.position.x+1.0f, selector.transform.position.y, 0.1f);
        }


    }


//Selects an object
    private void OnCollisionEnter(Collision other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(other.gameObject.tag=="RCube")
            {
                
            }
        }
    }


}
