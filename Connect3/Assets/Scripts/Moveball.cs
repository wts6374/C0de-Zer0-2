using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveball : MonoBehaviour {

    public bool up;
    public bool left;
    public bool right;
    public bool down;
    public GameObject player;
   

    private GameObject bu;
    private GameObject bl;
    private GameObject br;
    private GameObject bd;
    // Use this for initialization
    void Start () {
        up = false;
        left = false;
        right = false;
        down = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.W) && up == true)
        {
            Vector3 temp = player.transform.position;
            player.transform.position = bu.transform.position;
            bu.transform.position = temp;
            up = false;
            left = false;
            right = false;
            down = false;
        }
       else if (Input.GetKeyUp(KeyCode.S) && down == true)
        {
            Vector3 temp = player.transform.position;
            player.transform.position = bd.transform.position;
            bd.transform.position = temp;
            up = false;
            left = false;
            right = false;
            down = false;
        }

       else if (Input.GetKeyUp(KeyCode.A) && left == true)
        {
            Vector3 temp = player.transform.position;
            player.transform.position = bl.transform.position;
            bl.transform.position = temp;
            up = false;
            left = false;
            right = false;
            down = false;
        }
       else if (Input.GetKeyUp(KeyCode.D) && right == true)
        {
            Vector3 temp = player.transform.position;
            player.transform.position = br.transform.position;
            br.transform.position = temp;
            up = false;
            left = false;
            right = false;
            down = false;
        }


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BChip")
        {
           if(col.gameObject.transform.position.x>player.transform.position.x)
            {
                right = true;
                br = col.gameObject;
            }

            if (col.gameObject.transform.position.x < player.transform.position.x)
            {
                left= true;
                bl = col.gameObject;
            }
            if (col.gameObject.transform.position.y > player.transform.position.y)
            {
                up = true;
                bu = col.gameObject;
            }
            if (col.gameObject.transform.position.y < player.transform.position.y)
            {
                down = true;
                bd = col.gameObject;
            }
        }
    }
}
