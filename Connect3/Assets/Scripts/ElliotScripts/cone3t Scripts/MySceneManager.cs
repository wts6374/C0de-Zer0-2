using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{

    public int numberOfMoves;
    public float score;

    public Material redMat;
    public Material blueMat;
    public Material greenMat;
    public Material yellowMat;
    public Material tealMat;
    public Material purpleMat;

    public GameObject blankChip;
    public List<GameObject> chips;

    public GameObject[] switchingArray;
    public bool moved, moving;
    private Vector3 pos1, pos2;
    private int count;

    public GameObject[,] chipGrid;
    public List<int> matchChipGridValues;
    public List<int> matchChipGridValues2;
    public List<GameObject> storedChips;
    int indexSet;
    bool organizeGrid;

    // Use this for initialization
    void Start()
    {
        organizeGrid = true;
        matchChipGridValues = new List<int>();
        storedChips = new List<GameObject>();
        chips = new List<GameObject>();
        numberOfMoves = 10;
        score = count = 0;
        moved = moving = false;
        pos1 = pos2 = Vector3.zero;
        chipGrid = new GameObject[8, 8];
        switchingArray = new GameObject[2];
        blankChip = blankChip.transform.GetChild(0).gameObject;
        int heightChange = 0;
        float chipPlacement = -6.5f;
        indexSet = 0;
        /*----------------------*/
        for(int x = 0; x < 8; x++)
        {
            for(int y = 0; y < 8; y++)
            {
                chipGrid[x, y] = null;
            }
        }
        #region chipSetUp
        for (int x = 0; x < 8; x++)
        {
            heightChange = 0;
            for (int y = 0; y < 3; y++)
            {
                // randomly chooses either 1 or 2
                int randomNum = Random.Range(0, 6);

                // if 1; sets Chip identifier to 1 and gives it the red material
                if (randomNum == 1)
                    blankChip.GetComponent<Chips>().SetChip(1, redMat);
                else if (randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                    blankChip.GetComponent<Chips>().SetChip(0, blueMat);
                else if (randomNum == 2)
                    blankChip.GetComponent<Chips>().SetChip(2, yellowMat);
                else if (randomNum == 3)
                    blankChip.GetComponent<Chips>().SetChip(3, tealMat);
                else if (randomNum == 4)
                    blankChip.GetComponent<Chips>().SetChip(4, purpleMat);
                else
                    blankChip.GetComponent<Chips>().SetChip(5, greenMat);

                // sets index in chips array
                blankChip.GetComponent<Chips>().index = indexSet;
                // blankChip.GetComponent<Anim>

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
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //    numberOfMoves--;
        if (Input.GetMouseButtonDown(1))
            switchingArray = new GameObject[2];
        if (numberOfMoves == 0)
            EndGame();

        HandleSwitching();
        //Debug.Log(chipGrid[0, 2].GetComponent<Chips>().index);
        //Debug.Log(chipGrid[0, 2].transform.position);

        // This should make sure all the chips don't unfreeze in position and rotation after they move
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if(gameObject.GetComponent<Rigidbody>() != null && chipGrid[i,j] != null)
                    chipGrid[i, j].gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }
        }

        //for (int x = 0; x < chips.Count; x++)
        //    if (chips[x] != null)
        //        chips[x].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        //    else
        //        chips.Remove(chips[x]);





        for (int x = 0; x < chips.Count; x++)
            if (chips[x] == null)
            {
                chips.Remove(chips[x]);
                organizeGrid = true;
            }

        

        for (int x = 0; x < chips.Count; x++)
            chips[x].GetComponent<Chips>().index = x;

        for (int x = 0; x < chips.Count; x++)
            if (chips[x].GetComponent<Rigidbody>() != null)
                chips[x].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;



        if (organizeGrid)
        {
            SpawnNewChips();
            //MatchingCheck();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (y - 1 > -1 && chipGrid[x, y] != null)
                    {
                        int index = chipGrid[x, y].GetComponent<Chips>().index;
                        for (int z = 0; z < y+1; z++)
                        {
                            if (chipGrid[x, y - z] == null)
                            {
                                chipGrid[x,y - z + 1] = null;
                                chipGrid[x, y - z] = chips[index];
                                
                                
                                
                            }
                        }

                       
                        

                    }
                }
            }
            organizeGrid = false;
        }


    }

    void EndGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    //Updated Switching
    void HandleSwitching()
    {
        GameObject temp1;
        GameObject temp2;

        //if two elements are selected for switching 
        if (switchingArray[1] != null)
        {
            //Unselects a position if they are at the same point
            if (switchingArray[0] == switchingArray[1])
            {
                switchingArray[0] = null;
                switchingArray[1] = null;
            }
            else
            {
                //And not in the process of switching, store the end positions
                if (!moving)
                {
                    
                    numberOfMoves--;
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
                        temp1 = switchingArray[0];
                        temp2 = switchingArray[0];
                        //switchingArray[0].GetComponent<Animator>().enabled = true;
                        switchingArray[0].GetComponent<Animator>().Play("Take 001");
                        //switchingArray[1].GetComponent<Animator>().Play("Take 001");


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
                        for (int x = 0; x < chips.Count; x++)
                            Destroy(chips[x].GetComponent<Rigidbody>());

                    }
                    else
                    {

                        //reset the empty array and count while adding to score
                        moving = false;
                        SwitchGridPos(switchingArray[0].GetComponent<Chips>().index, switchingArray[1].GetComponent<Chips>().index);
                        switchingArray = new GameObject[2];
                        count = 0;
                        //score += 10;
                        for (int x = 0; x < chips.Count; x++)
                            chips[x].AddComponent<Rigidbody>();

                        MatchingCheck();
                        
                        //SpawnNewChips();
                        
                        
                        // adds rigidbodies again 

                        


                    }
                }
            }

        }




    }

    void MatchingCheck()
    {
        for (int x = 0; x < 8; x++)
        {
            GameObject previousChip = null;
            int counter = 0;
            for (int y = 0; y < 8; y++)
            {
                GameObject currentChip = chipGrid[x, y];

                if (currentChip == null)
                {
                    if (counter >= 2)
                    {
                        if (counter == 2)
                        {
                            score += 30 / 2;
                        }
                        if (counter > 2)
                        {
                            score += ((1 + counter) * 10) / 2;
                            numberOfMoves += counter - 2;
                        }

                        for (int z = 0; z < matchChipGridValues.Count; z += 2)
                        {
                            Destroy(chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]]);
                            chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]] = null;

                        }
                        matchChipGridValues = new List<int>();
                        //SpawnNewChips(counter);
                    }
                    else
                    {
                        counter = 0;
                        matchChipGridValues = new List<int>();
                    }
                    break;
                }

                if (previousChip != null)
                {

                    if (currentChip.GetComponent<Chips>().chipNumCode == previousChip.GetComponent<Chips>().chipNumCode)
                    {
                        //Debug.Log("Column: " + x);
                        //Debug.Log(currentChip.GetComponent<Chips>().index);
                        //Debug.Log(previousChip.GetComponent<Chips>().index);
                        counter++;
                        matchChipGridValues.Add(x);
                        matchChipGridValues.Add(y);
                    }
                    else
                    {
                        if (counter >= 2)
                        {
                            if (counter == 2)
                            {
                                score += 30 / 2;
                            }
                            if (counter > 2)
                            {
                                score += ((1 + counter) * 10) / 2;
                                numberOfMoves += counter - 2;
                            }

                            for (int z = 0; z < matchChipGridValues.Count; z += 2)
                            {
                                Debug.Log("X: " + matchChipGridValues[z] + " Y: " + matchChipGridValues[z + 1]);
                                Destroy(chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]]);
                                chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]] = null;


                            }
                            matchChipGridValues = new List<int>();
                            //SpawnNewChips(counter);
                        }
                        else
                        {
                            counter = 0;
                            matchChipGridValues = new List<int>();
                            previousChip = currentChip;
                            matchChipGridValues.Add(x);
                            matchChipGridValues.Add(y);
                        }

                    }


                }
                else
                {
                    previousChip = currentChip;
                    matchChipGridValues.Add(x);
                    matchChipGridValues.Add(y);
                }
            }


        }
        matchChipGridValues = new List<int>();
        for(int y = 0; y < 8; y++)
        {
            int counter = 0;
            for(int x = 0; x < 7; x++)
            {
                if (chipGrid[x, y] != null && chipGrid[x + 1, y] != null)
                {
                    if (chipGrid[x, y].GetComponent<Chips>().chipNumCode == chipGrid[x + 1, y].GetComponent<Chips>().chipNumCode)
                    {
                        if (counter == 0)
                        {
                            matchChipGridValues.Add(x);
                            matchChipGridValues.Add(y);
                        }
                        counter++;
                        matchChipGridValues.Add(x + 1);
                        matchChipGridValues.Add(y);
                    }
                    else
                    {
                        if (counter >= 2)
                        {
                            if (counter == 2)
                            {
                                score += 30 / 2;
                            }
                            if (counter > 2)
                            {
                                score += ((1 + counter) * 10) / 2;
                                numberOfMoves += counter - 2;
                            }

                            for (int z = 0; z < matchChipGridValues.Count; z += 2)
                            {
                                Debug.Log("X: " + matchChipGridValues[z] + " Y: " + matchChipGridValues[z + 1]);
                                Destroy(chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]]);
                                chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]] = null;


                            }
                            matchChipGridValues = new List<int>();
                            //SpawnNewChips(counter);
                        }
                        else
                            counter = 0;
                    }

                }
                //else
                {
                    if (counter >= 2)
                    {
                        if(counter >= 2)
                        {
                            if (counter == 2)
                            {
                                score += 30 / 2;
                            }
                            if (counter > 2)
                            {
                                score += ((1 + counter) * 10) / 2;
                                numberOfMoves += counter - 2;
                            }

                            for (int z = 0; z < matchChipGridValues.Count; z += 2)
                            {
                                Debug.Log("X: " + matchChipGridValues[z] + " Y: " + matchChipGridValues[z + 1]);
                                Destroy(chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]]);
                                chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]] = null;


                            }
                            matchChipGridValues = new List<int>();
                            //SpawnNewChips(counter);
                        }
                    }
                }
            }
            matchChipGridValues = new List<int>();
        }
        //for (int y = 0; y < 8; y++)
        //{
        //    GameObject previousChip = null;
        //    int counter = 0;
        //    for (int x = 0; x < 8; x++)
        //    {

        //        GameObject currentChip = chipGrid[x, y];

        //        if (currentChip == null)
        //        {
        //            if (counter >= 2)
        //            {
        //                if (counter == 2)
        //                {
        //                    score += 30 / 2;
        //                }
        //                if (counter > 2)
        //                {
        //                    score += ((1 + counter) * 10) / 2;
        //                    numberOfMoves += counter - 2;
        //                }

        //                for (int z = 0; z < matchChipGridValues.Count; z += 2)
        //                {
        //                    Destroy(chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]]);
        //                    chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]] = null;

        //                }
        //                matchChipGridValues = new List<int>();
        //                //SpawnNewChips(counter);
        //            }
        //            else
        //            {
        //                counter = 0;
        //                matchChipGridValues = new List<int>();
        //            }
        //            break;
        //        }

        //        if (previousChip != null)
        //        {

        //            if (currentChip.GetComponent<Chips>().chipNumCode == previousChip.GetComponent<Chips>().chipNumCode)
        //            {
        //                //Debug.Log("Column: " + x);
        //                //Debug.Log(currentChip.GetComponent<Chips>().index);
        //                //Debug.Log(previousChip.GetComponent<Chips>().index);
        //                counter++;
        //                matchChipGridValues.Add(x);
        //                matchChipGridValues.Add(y);
        //            }
        //            else
        //            {
        //                if (counter >= 2)
        //                {
        //                    if (counter == 2)
        //                    {
        //                        score += 30 / 2;
        //                    }
        //                    if (counter > 2)
        //                    {
        //                        score += ((1 + counter) * 10) / 2;
        //                        numberOfMoves += counter - 2;
        //                    }

        //                    for (int z = 0; z < matchChipGridValues.Count; z += 2)
        //                    {
        //                        Debug.Log("X: " + matchChipGridValues[z] + " Y: " + matchChipGridValues[z + 1]);
        //                        Destroy(chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]]);
        //                        chipGrid[matchChipGridValues[z], matchChipGridValues[z + 1]] = null;


        //                    }
        //                    matchChipGridValues = new List<int>();
        //                    //SpawnNewChips(counter);
        //                }
        //                else
        //                {
        //                    counter = 0;
        //                    matchChipGridValues = new List<int>();
        //                    previousChip = currentChip;
        //                    matchChipGridValues.Add(x);
        //                    matchChipGridValues.Add(y);
        //                }

        //            }


        //        }
        //        else
        //        {
        //            previousChip = currentChip;
        //            matchChipGridValues.Add(x);
        //            matchChipGridValues.Add(y);
        //        }
        //    }
        //}


        return;
    }
    void SpawnNewChips()
    {
        

        int amount = Random.Range(1, 3);

        for(int x = 0; x < amount; x++)
        {
            int random = Random.Range(0, 8);
            float xValueColumn = 0;

            if (random == 7)
                xValueColumn = .5f;
            else if (random == 6)
                xValueColumn = -.5f;
            else if (random == 5)
                xValueColumn = -1.5f;
            else if (random == 4)
                xValueColumn = -2.5f;
            else if (random == 3)
                xValueColumn = -3.5f;
            else if (random == 2)
                xValueColumn = -4.5f;
            else if (random == 1)
                xValueColumn = -5.5f;
            else if (random == 0)
                xValueColumn = -6.5f;

            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 6);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else if (randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);
            else if (randomNum == 2)
                blankChip.GetComponent<Chips>().SetChip(2, yellowMat);
            else if (randomNum == 3)
                blankChip.GetComponent<Chips>().SetChip(3, tealMat);
            else if (randomNum == 4)
                blankChip.GetComponent<Chips>().SetChip(4, purpleMat);
            else
                blankChip.GetComponent<Chips>().SetChip(5, greenMat);

            // sets index in chips array
            blankChip.GetComponent<Chips>().index = chips.Count - 1;
            // blankChip.GetComponent<Anim>

            // instantiates Chip into scene

            chips.Add(Instantiate(blankChip, new Vector3(xValueColumn, 5, 0), Quaternion.identity));

            for (int y = 0; y < 8; y++)
            {
                if (chipGrid[random, y] == null)
                {
                    chipGrid[random, y] = chips[chips.Count - 1];
                    break;
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

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (chipGrid[x, y] == null)
                    break;

                if (temp1 == null && chipGrid[x, y].GetComponent<Chips>().index == index1)
                {
                    x1 = x;
                    y1 = y;
                    temp1 = chipGrid[x, y];
                }
                else if (temp2 == null && chipGrid[x, y].GetComponent<Chips>().index == index2)
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
            if (temp1 != null && temp2 != null)
            {
                break;
            }
        }
        chipGrid[x1, y1] = temp2;
        chipGrid[x2, y2] = temp1;

    }

    //private void OnGUI()
    //{

    //    string grid = null;
    //    for (int x = 7; x > -1; x--)
    //    {
    //        for (int y = 0; y < 8; y++)
    //        {
    //            if (chipGrid[y, x] != null)
    //            {
    //                if (chipGrid[y, x].GetComponent<Chips>().index < 10)
    //                    grid += "|" + chipGrid[y, x].GetComponent<Chips>().index + " |";
    //                else
    //                    grid += "|" + chipGrid[y, x].GetComponent<Chips>().index + "|";
    //            }
    //            else
    //                grid += "|01|";
    //        }
    //        grid += "\n";
    //    }

    //    GUI.Box(new Rect(550, 10, 200, 150), grid);
    //}
}
