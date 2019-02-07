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
	public List<GameObject> chipMatch;

    public GameObject[] switchingArray;
    public bool moved, moving;
    private Vector3 pos1, pos2;
    private int count;
	public int chipCount;

    public GameObject[,] chipGrid;

    // Use this for initialization
<<<<<<< HEAD
    void Start () {
		chipCount = 0;
		chipMatch = new List<GameObject> ();
=======
    void Start()
    {
>>>>>>> 1c37970fddf76c1a710f3858179f8d24e5942d38
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
		GameObject tempChip = null; 
        /*----------------------*/
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
                    blankChip.GetComponent<Chips>().SetChip(2, greenMat);

                // sets index in chips array
                blankChip.GetComponent<Chips>().index = indexSet;


                // instantiates Chip into scene
                chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 1 + heightChange, 0), Quaternion.identity));
				tempChip = blankChip;
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

<<<<<<< HEAD
		checkForMatch ();
=======

>>>>>>> 1c37970fddf76c1a710f3858179f8d24e5942d38
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
		Debug.Log (chipGrid);
        HandleSwitching();
        //Debug.Log(chipGrid[0, 2].GetComponent<Chips>().index);
        //Debug.Log(chipGrid[0, 2].transform.position);

        // This should make sure all the chips don't unfreeze in position and rotation after they move
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if(chipGrid[i,j] != null)
                    chipGrid[i, j].gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }
        }


    }

    void EndGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    //Updated Switching
    void HandleSwitching()
    {

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
                        score += 10;

                        // adds rigidbodies again 
                        for (int x = 0; x < chips.Count; x++)
                            chips[x].AddComponent<Rigidbody>();
                    }
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
<<<<<<< HEAD
				if (chipGrid [x, y] != null) {
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
				}
                
=======
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
>>>>>>> 1c37970fddf76c1a710f3858179f8d24e5942d38

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
		Debug.Log (x1 + " " + y1);
        chipGrid[x1, y1] = temp2;
        chipGrid[x2, y2] = temp1;
		checkForMatch ();
    }

<<<<<<< HEAD
    private void OnGUI()
    {

        string grid = null;
        for(int x = 7; x > -1; x--)
        {
            for(int y = 0; y < 8; y++)
            {
				if (chipGrid [y, x] != null) {
					if(chipGrid[y, x].GetComponent<Chips>().index < 10)
						grid += "|" + chipGrid[y, x].GetComponent<Chips>().index + " |";
					else
						grid += "|" + chipGrid[y, x].GetComponent<Chips>().index + "|";
				}
                
            }
            grid += "\n";
        }

        GUI.Box(new Rect(450, 10, 200, 150), grid);
    }

	public void spawnChip(){
		int x = Random.Range (0, 8);
		float placement = -6.5f * x;
		int col = Random.Range (0, 3);
		string colStr = "";
		switch (col) {
		case 1:
			blankChip.GetComponent<Chips> ().SetChip (col, redMat);
			break;
		case 2:
			blankChip.GetComponent<Chips> ().SetChip (col, greenMat);
			break;
		case 0:
			blankChip.GetComponent<Chips> ().SetChip (col,blueMat);
			break;
		}
		chipGrid[x,1] = Instantiate(blankChip, new Vector3(placement, 6, 0), Quaternion.identity);

	}

	public void checkForMatch(){
		List<GameObject> chip2 = new List<GameObject> ();
		bool match = false;
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				chipMatch.Add (chipGrid [i, j]);
				Debug.Log (chipGrid [i, j]);

			}
		}

		GameObject tempChip = null;
		int xc = 0;
		int yc = 0;
		List<GameObject> matches = new List<GameObject> ();
		foreach (GameObject chp in chipMatch) {
			if (tempChip == null||chp == null) {
				Debug.Log ("true");
			} else {
				Debug.Log (tempChip);
				if (chp.GetComponent<Chips> ().chipNumCode == tempChip.GetComponent<Chips> ().chipNumCode) {
					chipCount++;
					matches.Add (chp);
				} else {
					if (matches.Count>=3) {
						foreach (GameObject c in matches) {
							c.transform.position = new Vector3 (3000, 3000, 3000);
							yc = c.GetComponent<Chips> ().index % 8;
							xc = ((c.GetComponent<Chips>().index - (c.GetComponent<Chips> ().index % 8)) /8);
							chipGrid [xc, yc] = null;

						}
						foreach (GameObject c in matches) {
							xc = ((c.GetComponent<Chips>().index - (c.GetComponent<Chips> ().index % 8)) /8);
							List<GameObject> t = new List<GameObject> ();
							for (int i = 0; i <8; i++) {
								if (chipGrid[xc,i]==null) {
								} else {
									t.Add(chipGrid[xc,i]);
									chipGrid[xc,i] = null;
								}

							}
							for (int i = 0; i < t.Count; i++) {
								chipGrid [xc, i] = t [i];
								Debug.Log(chipGrid[xc,i]);

							}
						}
						matches.Clear ();
					} 
				}

			}
			tempChip = chp;
		}
		tempChip = null;
		chipMatch.Clear ();
		matches.Clear ();
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				chip2.Add (chipGrid [j, i]);
			}
		}
		foreach (GameObject chp in chip2) {
			if (tempChip == null||chp == null) {

			} else {
				if (chp.GetComponent<Chips> ().chipNumCode == tempChip.GetComponent<Chips> ().chipNumCode) {
					chipCount++;
					matches.Add (chp);
				} else {
					if (matches.Count >= 3) {
						foreach (GameObject c in matches) {
							c.transform.position = new Vector3 (3000, 3000, 3000);
							yc = c.GetComponent<Chips> ().index % 8;
							xc = ((c.GetComponent<Chips>().index - (c.GetComponent<Chips> ().index % 8)) /8);
							chipGrid [xc, yc] = null;

						}

						List<GameObject> t = new List<GameObject> ();
						int nullCnt = 0;
						for (int i = 0; i <8; i++) {
							if (chipGrid[xc,i] == null) {
								nullCnt++;
							} else {
								t.Add(chipGrid[xc,i]);
								chipGrid [xc, i] = null;

							}

						}
						for (int i = 0; i < t.Count; i++) {
							chipGrid [xc, i] = t [i];
							Debug.Log(chipGrid[xc,i]);
						}
						matches.Clear ();
					}
				}

			}
			tempChip = chp;
		}
		tempChip = null;
		chip2.Clear ();
	}
=======
    //private void OnGUI()
    //{

    //    string grid = null;
    //    for (int x = 7; x > -1; x--)
    //    {
    //        for (int y = 0; y < 8; y++)
    //        {
    //            if (chipGrid[y, x].GetComponent<Chips>().index < 10)
    //                grid += "|" + chipGrid[y, x].GetComponent<Chips>().index + " |";
    //            else
    //                grid += "|" + chipGrid[y, x].GetComponent<Chips>().index + "|";
    //        }
    //        grid += "\n";
    //    }

    //    GUI.Box(new Rect(450, 10, 200, 150), grid);
    //}
>>>>>>> 1c37970fddf76c1a710f3858179f8d24e5942d38
}

