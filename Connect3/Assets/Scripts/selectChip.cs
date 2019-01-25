using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectChip : MonoBehaviour {

    public GameObject selector;
    public BoxCollider bg;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        //These check the bounds of the top, left, bottom, right grid objects so the grid can be moved anywhere at will!
        if(Input.GetKeyDown(KeyCode.W) && selector.transform.position.y < GameObject.Find("Grid (8) H").transform.position.y - 1)
        {
            selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y+1.0f, 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.S) && selector.transform.position.y > GameObject.Find("Grid (7) H").transform.position.y + 1)
        {
            selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y-1.0f, 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.A) && selector.transform.position.x > GameObject.Find("Grid (7) V").transform.position.x + 1)
        {
            selector.transform.position = new Vector3(selector.transform.position.x-1.0f, selector.transform.position.y, 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.D) && selector.transform.position.x < GameObject.Find("Grid (8) V").transform.position.x - 1)
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
