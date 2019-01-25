using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectMatch : MonoBehaviour {

    public GameObject motherLocation;
    public GameObject[] cells = new GameObject[8];
    public GameObject[,] grid = new GameObject[8,8];
    public int[,] gridNum = new int[8, 8];

    public bool begin;

    private List<GameObject> redMatch;
    private List<GameObject> blueMatch;

    // Use this for initialization
    void Start () {
        begin = false;

        //Meant to get each and every child
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                grid[i, j] = cells[i].gameObject.transform.GetChild(j).gameObject;
                gridNum[i, j] = gridNum[i, j].GetComponent<detectChip>().version;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Trying to access elements of the script but it doesn't like how I'm trying reach for script info
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                grid[i, j] = cells[i].gameObject.transform.GetChild(j).gameObject;
                gridNum[i, j] = gridNum[i, j].GetComponent<detectChip>().version;
            }

        }


        for (int k = 0; k < 8; k++)
        {
            for (int p = 0; p < 8; p++)
            {
                if(gridNum[k, p]==1)
                {
                    
                }
                else if (gridNum[k, p] == 0)
                {

                }
            }

        }



    }

    //Detects when a bchips hit the bottom, beginning the process
    private void OnCollisionEnter(Collision other)
    {

       if (other.gameObject.tag == "RCube"||other.gameObject.tag == "BCube")
        {
            begin = true; 
        }
    }

}
