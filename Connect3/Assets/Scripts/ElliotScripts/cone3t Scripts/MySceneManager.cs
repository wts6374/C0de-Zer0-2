using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {

    public int numberOfMoves;
    public float score;

    public Material redMat;
    public Material blueMat;
    public Material greenMat;

    public GameObject blankChip;
    public List<GameObject> chips;

    public GameObject[] switchingArray;
    public bool moved, moving;
    private Vector3 pos1, pos2;
    private int count;

    public GameObject[,] chipGrid;
    public GameObject motherLocation;

    // Use this for initialization
    void Start () {
        chips = new List<GameObject>();
        numberOfMoves = 30;
        score = count = 0;
        moved = moving = false;
        pos1 = pos2 = Vector3.zero;
        chipGrid = new GameObject[8, 8];
        switchingArray = new GameObject[2];

        int heightChange = 0;
        float chipPlacement = -6.5f;
        int indexSet = 0;
        /*----------------------*/
        #region chipSetUp
        for (int x = 0; x < 8; x++)
        {
            heightChange = 0;
            for (int y = 0; y < 8; y++)
            {
                // randomly chooses either 1 or 2
                int randomNum = Random.Range(0, 3);

                // if 1; sets Chip identifier to 1 and gives it the red material
                if (randomNum == 1)
                    blankChip.GetComponent<Chips>().SetChip(1, redMat);
                else if (randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                    blankChip.GetComponent<Chips>().SetChip(0, blueMat);
                else
                    blankChip.GetComponent<Chips>().SetChip(2, greenMat);

                // sets index in chips array
                blankChip.GetComponent<Chips>().index = indexSet;
                

                // instantiates Chip into scene
                chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 1 + heightChange, 0), Quaternion.identity));

                heightChange += 2;
                chipGrid[x, y] = chips[indexSet];
                indexSet++;
            }

            chipPlacement += 1.0f;
        }

       
       
        #endregion
        /*----------------------*/

        //for(int x = 0; x < 8; x++)
        //{
        //    for(int y = 0; y < 8; y++)
        //    {
        //        Debug.Log(chipGrid[x, y].GetComponent<Chips>().index);
        //    }
        //    Debug.Log("----------------");
        //}

        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            numberOfMoves--;
        if (numberOfMoves == 0)
            EndGame();

        HandleSwitching();
        FindMatch();
        //Debug.Log(chipGrid[0, 2].GetComponent<Chips>().index);
        //Debug.Log(chipGrid[0, 2].transform.position);
    }

    void EndGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    //Updated Switching
    void HandleSwitching()
    {
        
        //if tow elements are selected for switching 
        if (switchingArray[1] != null)
        {
            

            //And not in the process of switching, store the end positions
            if (!moving)
            {
                pos1 = switchingArray[0].transform.position;
                pos2 = switchingArray[1].transform.position;
                if ((Mathf.Abs(pos1.x - pos2.x) < 1.5) && (Mathf.Abs(pos1.y - pos2.y) < 0.5) || (Mathf.Abs(pos1.x - pos2.x) < 0.5) && (Mathf.Abs(pos1.y - pos2.y) < 1.5))
                {
                    moving = true;
                }
                else
                {
                    switchingArray = new GameObject[2];
                    return;
                }
            }
            else
            {
                //only move a certain amount as not to get stuck
                if (count < 10)
                {
                    //Slowly move between the positions and add to count
                    //switchingArray[0].transform.position += (Pos2 - switchingArray[0].transform.position) / 2f;
                    //switchingArray[1].transform.position += (Pos1 - switchingArray[1].transform.position) / 2f;

                    Vector3 finalSwitch1 = (pos2 - switchingArray[0].transform.position) / 2f;
                    Vector3 finalSwitch2 = (pos1 - switchingArray[1].transform.position) / 2f;

                    // changes z value to 0 to prevent chips from falling off
                    // when the switching vectors are added to the switching chips
                    finalSwitch1.z = 0;
                    finalSwitch2.z = 0;

                    // adds values for switching objects
                    switchingArray[0].transform.position += finalSwitch1;
                    switchingArray[1].transform.position += finalSwitch2;

                    count++;

                    // removes rigidbodies to prevent switching from affecting the rest of the chips
                    // when they move
                    for(int x = 0; x < chips.Count; x++)
                        Destroy(chips[x].GetComponent<Rigidbody>());
                    
                }
                else
                {

                    //reset the empty array and count while adding to score
                    moving = false;
                    SwitchGridPos(switchingArray[0].GetComponent<Chips>().index, switchingArray[1].GetComponent<Chips>().index);
                    switchingArray = new GameObject[2];
                    count = 0;
                    score += 10;

                    // adds rigidbodies again 
                    for (int x = 0; x < chips.Count; x++)
                        chips[x].AddComponent<Rigidbody>();
                }
            }
            
        }



        
    }

    void SwitchGridPos(int index1, int index2)
    {
        GameObject temp1 = null;
        GameObject temp2 = null;

        int x1 = -100;
        int y1 = -100;

        int x2 = -100;
        int y2 = -100;

        for(int x = 0; x < 8; x++)
        {
            for(int y = 0; y < 8; y++)
            {
                if(temp1 == null && chipGrid[x,y].GetComponent<Chips>().index == index1)
                {
                    x1 = x;
                    y1 = y;
                    temp1 = chipGrid[x, y];
                }
                else if( temp2 == null && chipGrid[x, y].GetComponent<Chips>().index == index2)
                {
                    
                    x2 = x;
                    y2 = y;
                    temp2 = chipGrid[x, y];
                }

                //int c = chipGrid[x, y].GetComponent<Chips>().index;
                //Debug.Log(c);
                //else
                //{
                //    break;
                //}
            }
            if(temp1 != null && temp2 != null)
            {
                break;
            }
        }
        chipGrid[x1, y1] = temp2;
        chipGrid[x2, y2] = temp1;

    }


    //This will look through the grid and find a potential match up
    void FindMatch()
    {
        //For each element of the chipGrid, the grid will look for a matching set in either the horizontal or vertical direction
        for(int k=0; k<8; k++)
        {
            for (int p = 0; p < 8; p++)
            {
                //Searches for a matching set of 3 in either the left or right direction

                if (k > 0 && k < 8)
                {
                    if (chipGrid[k - 1, p].GetComponent<Chips>().chipNumCode == chipGrid[k, p].GetComponent<Chips>().chipNumCode)
                    {
                        //2 matching chips to the left
                        if (k >= 2 && chipGrid[k - 2, p] == chipGrid[k, p])
                        {
                            chipGrid[k, p].transform.position = motherLocation.transform.position;
                            chipGrid[k - 1, p].transform.position = motherLocation.transform.position;
                            chipGrid[k - 2, p].transform.position = motherLocation.transform.position;
                            break;
                        }

                        //Matching set with one to the left and one to the right
                        else if (k <= 7 && chipGrid[k + 1, p].GetComponent<Chips>().chipNumCode == chipGrid[k, p].GetComponent<Chips>().chipNumCode)
                        {
                            chipGrid[k, p].transform.position = motherLocation.transform.position;
                            chipGrid[k - 1, p].transform.position = motherLocation.transform.position;
                            chipGrid[k + 1, p].transform.position = motherLocation.transform.position;
                            break;
                        }
                    }
                    //2 matching chips to the right
                    else if (k <= 6 && (chipGrid[k + 2, p].GetComponent<Chips>().chipNumCode == chipGrid[k, p].GetComponent<Chips>().chipNumCode && chipGrid[k + 1, p].GetComponent<Chips>().chipNumCode == chipGrid[k, p].GetComponent<Chips>().chipNumCode))
                    {
                        chipGrid[k, p].transform.position = motherLocation.transform.position;
                        chipGrid[k + 1, p].transform.position = motherLocation.transform.position;
                        chipGrid[k + 2, p].transform.position = motherLocation.transform.position;
                        break;
                    }
                }

                else if (p > 0 && p < 8)
                {
                    if (chipGrid[k, p - 1].GetComponent<Chips>().chipNumCode == chipGrid[k, p].GetComponent<Chips>().chipNumCode)
                    {
                        //2 matching chips upwards
                        if (p >= 2 && chipGrid[k, p - 2].GetComponent<Chips>().chipNumCode == chipGrid[k, p].GetComponent<Chips>().chipNumCode)
                        {
                            chipGrid[k, p].transform.position = motherLocation.transform.position;
                            chipGrid[k, p - 1].transform.position = motherLocation.transform.position;
                            chipGrid[k, p - 2].transform.position = motherLocation.transform.position;
                            break;
                        }

                        //Matching set with one upwards and one downwards
                        else if (p <= 7 && chipGrid[k, p + 1].GetComponent<Chips>().chipNumCode == chipGrid[k, p].GetComponent<Chips>().chipNumCode)
                        {
                            chipGrid[k, p].transform.position = motherLocation.transform.position;
                            chipGrid[k, p - 1].transform.position = motherLocation.transform.position;
                            chipGrid[k, p + 1].transform.position = motherLocation.transform.position;
                            break;
                        }
                    }
                    //2 matching chips downwards
                    else if (p <= 6 && (chipGrid[k, p + 2].GetComponent<Chips>().chipNumCode == chipGrid[k, p].GetComponent<Chips>().chipNumCode && chipGrid[k, p + 1].GetComponent<Chips>().chipNumCode == chipGrid[k, p].GetComponent<Chips>().chipNumCode))
                    {
                        chipGrid[k, p].transform.position = motherLocation.transform.position;
                        chipGrid[k, p + 1].transform.position = motherLocation.transform.position;
                        chipGrid[k, p + 2].transform.position = motherLocation.transform.position;
                        break;
                    }
                }


            }
        }
    }

    private void OnGUI()
    {

        string grid = null;
        for(int x = 7; x > -1; x--)
        {
            for(int y = 0; y < 8; y++)
            {
                if(chipGrid[y, x].GetComponent<Chips>().index < 10)
                    grid += "|" + chipGrid[y, x].GetComponent<Chips>().index + " |";
                else
                    grid += "|" + chipGrid[y, x].GetComponent<Chips>().index + "|";
            }
            grid += "\n";
        }

        GUI.Box(new Rect(450, 10, 200, 150), grid);
    }
}
