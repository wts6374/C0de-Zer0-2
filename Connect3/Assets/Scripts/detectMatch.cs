using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectMatch : MonoBehaviour {

    public GameObject motherLocation;
    public GameObject scoreManager;


    public GameObject[] cells = new GameObject[8];
    public GameObject[,] grid = new GameObject[8,8];
    public int[,] gridNum = new int[8, 8];

    public bool begin;

    private List<GameObject> redMatch;
    private List<GameObject> blueMatch;

    private int connected;
    private List<GameObject> match;

    // Use this for initialization
    void Start () {
        begin = false;

        //Meant to get each and every child
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                grid[i, j] = cells[i].gameObject.transform.GetChild(j).gameObject;
                gridNum[i, j] = grid[i, j].GetComponent<detectChip>().version;
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
                gridNum[i, j] = grid[i, j].GetComponent<detectChip>().version;
            }

        }


        for (int k = 0; k < 8; k++)
        {
            for (int p = 0; p < 8; p++)
            {
                if(gridNum[k, p]==1)
                {
                    redMatch.Add(grid[k, p]);
                }
                else if (gridNum[k, p] == 0)
                {
                    blueMatch.Add(grid[k, p]);
                }
            }

        }


        //Right now it will only look at the grid for three matching pieces
        //It's sloppy but worth testing
        for (int k = 0; k < 8; k++)
        {
            for (int p = 0; p < 8; p++)
            {

                //up and down
                if(p>0&&p<8)
                {
                    if(gridNum[k,p-1]==gridNum[k,p])
                    {
                        //2 ups
                            if (p>=2 && gridNum[k, p - 2] == gridNum[k, p])
                            {
                                grid[k, p].transform.position = motherLocation.transform.position;
                                grid[k, p-1].transform.position = motherLocation.transform.position;
                                grid[k, p-2].transform.position = motherLocation.transform.position;
                            scoreManager.GetComponent<MySceneManager>().numberOfMoves += 1;
                            scoreManager.GetComponent<MySceneManager>().score += 300;
                            break;
                            }

                            //up and down
                        else if (p <=7  && gridNum[k, p +1] == gridNum[k, p])
                        {
                            grid[k, p].transform.position = motherLocation.transform.position;
                            grid[k, p - 1].transform.position = motherLocation.transform.position;
                            grid[k, p +1].transform.position = motherLocation.transform.position;
                            scoreManager.GetComponent<MySceneManager>().numberOfMoves += 1;
                            scoreManager.GetComponent<MySceneManager>().score += 300;
                            break;
                        }
                    }
                    //2 Down
                    else if (p<= 6 && (gridNum[k, p + 2] == gridNum[k, p]&& gridNum[k, p+1] == gridNum[k, p]))
                    {
                        grid[k, p].transform.position = motherLocation.transform.position;
                        grid[k, p + 1].transform.position = motherLocation.transform.position;
                        grid[k, p + 2].transform.position = motherLocation.transform.position;
                        scoreManager.GetComponent<MySceneManager>().numberOfMoves += 1;
                        scoreManager.GetComponent<MySceneManager>().score += 300;
                        break;
                    }
                }
                else  //left and right
                if (k > 0 && k < 8)
                {
                    if (gridNum[k-1, p] == gridNum[k, p])
                    {
                        //2 left
                        if (k >= 2 && gridNum[k-2, p] == gridNum[k, p])
                        {
                            grid[k, p].transform.position = motherLocation.transform.position;
                            grid[k-1, p].transform.position = motherLocation.transform.position;
                            grid[k-2, p].transform.position = motherLocation.transform.position;
                            scoreManager.GetComponent<MySceneManager>().numberOfMoves += 1;
                            scoreManager.GetComponent<MySceneManager>().score += 300;
                            break;
                        }

                        //left and right
                        else if (k <= 7 && gridNum[k+1, p] == gridNum[k, p])
                        {
                            grid[k, p].transform.position = motherLocation.transform.position;
                            grid[k-1, p].transform.position = motherLocation.transform.position;
                            grid[k+1, p].transform.position = motherLocation.transform.position;
                            scoreManager.GetComponent<MySceneManager>().numberOfMoves += 1;
                            scoreManager.GetComponent<MySceneManager>().score += 300;
                            break;
                        }
                    }
                    //2 right
                    else if (k <= 6 && (gridNum[k+2, p] == gridNum[k, p] && gridNum[k+1, p] == gridNum[k, p]))
                    {
                        grid[k, p].transform.position = motherLocation.transform.position;
                        grid[k+1, p].transform.position = motherLocation.transform.position;
                        grid[k+2, p].transform.position = motherLocation.transform.position;
                        scoreManager.GetComponent<MySceneManager>().numberOfMoves += 1;
                        scoreManager.GetComponent<MySceneManager>().score += 300;
                        break;
                    }
                }


            }

        }

        //Basic way to try and update the value of each array, need to come back later
        for (int k = 0; k < 8; k++)
        {
            for (int p = 0; p < 8; p++)
            {
                grid[k, p] = null;
                gridNum[k, p]=3;
            }
        }
        begin = false;

                //This will use derivates to match more than 3
                /* for (int a = 0; a < redMatch.Count; a++)
                 {
                     match.Add(redMatch[a]);
                     connected += 1;

                 }*/


            }

    //Detects when a bchips hit the bottom, beginning the process
    private void OnCollisionEnter(Collision other)
    {

       if (other.gameObject.tag == "RCube"||other.gameObject.tag == "BCube")
        {
            begin = true; 
        }
    }

    //These will be used later for longer matches
    void FindUpOrDown(GameObject origin)
    {

    }

    void FindLeftOrRight(GameObject origin)
    {

    }




}
