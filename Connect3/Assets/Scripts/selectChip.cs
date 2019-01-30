using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectChip : MonoBehaviour {

    public GameObject selector;
    public GameObject selector2;
    public BoxCollider bg;
    public MySceneManager sceneManager;

	// Use this for initialization
	void Start () {
        selector.transform.position = selector2.transform.position = new Vector3(-100f, 4.01f, 0.1f);
        sceneManager = GameObject.Find("MySceneManager").GetComponent<MySceneManager>();
    }
	
	// Update is called once per frame
	void Update () {
        sceneManager = GameObject.Find("MySceneManager").GetComponent<MySceneManager>();


        //Basically, if the an item is selected for each element, update the selector pos to the chip, otherwise get off the screen
        if (sceneManager.switchingArray[0] != null)
        {
            selector.transform.position = sceneManager.switchingArray[0].transform.position + new Vector3(0, 0, -.2f);
        }
        else
        {
            selector.transform.position = new Vector3(-100f, 4.01f, 0.1f);
        }
        if (sceneManager.switchingArray[1] != null)
        {
            selector2.transform.position = sceneManager.switchingArray[1].transform.position + new Vector3(0, 0, -.2f);
        }
        else
        {
            selector2.transform.position = new Vector3(-100f, 4.01f, 0.1f);
        }

        //REMOVED BECAUSE NOT IN USE
        //if(Input.GetKeyDown(KeyCode.W) && selector.transform.position.y<4.01f)
        //{
        //    selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y+1.0f, 0.1f);
        //}
        //
        //if (Input.GetKeyDown(KeyCode.S) && selector.transform.position.y > -2.01f)
        //{
        //    selector.transform.position = new Vector3(selector.transform.position.x, selector.transform.position.y-1.0f, 0.1f);
        //}
        //
        //if (Input.GetKeyDown(KeyCode.A) && selector.transform.position.x > -6.5f)
        //{
        //    selector.transform.position = new Vector3(selector.transform.position.x-1.0f, selector.transform.position.y, 0.1f);
        //}
        //
        //if (Input.GetKeyDown(KeyCode.D) && selector.transform.position.x < 0.5f)
        //{
        //    selector.transform.position = new Vector3(selector.transform.position.x+1.0f, selector.transform.position.y, 0.1f);
        //}
        //
        //
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
