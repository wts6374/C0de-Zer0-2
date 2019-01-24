using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBall : MonoBehaviour {

    public GameObject ball;
    public bool selected;
    public GameObject[] blueSpheres;

    private bool up;
    private bool left;
    private bool right;
    private bool down;

    // Use this for initialization
    void Start () {
        up = false;
        left = false;
        right = false;
        down = false;

        if(blueSpheres==null)
        {
            blueSpheres = GameObject.FindGameObjectsWithTag("BChip");
        }
	}
	
	// Update is called once per frame
	void Update () {
       
       for(int i=0; i<blueSpheres.Length;i++)
        {
            if(blueSpheres[i].transform.position.x==ball.transform.position.x+1.0f)
            {
                right = true;
            }
            else if (blueSpheres[i].transform.position.x == ball.transform.position.x - 1.0f)
            {
                left = true;
            }
            else if (blueSpheres[i].transform.position.y == ball.transform.position.y - 1.0f)
            {
                down = true;
            }
            else if (blueSpheres[i].transform.position.x == ball.transform.position.y + 1.0f)
            {
                up= true;
            }
        }


        if (Input.GetKeyDown(KeyCode.W) && up==true)
        {
            ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + 1.0f, 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.S) && down == true)
        {
            ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y - 1.0f, 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.A) && left == true)
        {
            ball.transform.position = new Vector3(ball.transform.position.x - 1.0f, ball.transform.position.y, 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.D) && right == true)
        {
            ball.transform.position = new Vector3(ball.transform.position.x + 1.0f, ball.transform.position.y, 0.1f);
        }
    }
}
