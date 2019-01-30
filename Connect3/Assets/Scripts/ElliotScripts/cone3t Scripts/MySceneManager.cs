using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {

    public int numberOfMoves;
    public float score;
    public Material redMat;
    public Material blueMat;
    public GameObject blankChip;
    public List<GameObject> chips;
    public GameObject[] switchingArray;
    public bool moved, moving;
    private Vector3 Pos1, Pos2;
    private int count;

    private Vector3 screenPoint;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        chips = new List<GameObject>();
        numberOfMoves = 30;
        score = count = 0;
        moved = moving = false;
        Pos1 = Pos2 = Vector3.zero;
        switchingArray = new GameObject[2];
        
        // REMOVE LATER
        // value used to place chips next to each other for testing purposes
        float chipPlacement = -3.5f;

        //chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 1, 0), Quaternion.identity));

        // creates 5 chips by default 
        for (int x = 0; x < 5; x++)
        {
            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 2);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if(randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else // if 2; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);

            // sets index in chips array
            blankChip.GetComponent<Chips>().index = x;

            // instantiates Chip into scene
            chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 1, 0), Quaternion.identity));
            chipPlacement += 1.0f;
        }

        chipPlacement = -3.5f;

        // creates 5 chips by default 
        for (int x = 0; x < 5; x++)
        {
            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 2);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else // if 2; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);

            // sets index in chips array
            blankChip.GetComponent<Chips>().index = 5 + x;

            // instantiates Chip into scene
            chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 3, 0), Quaternion.identity));
            chipPlacement += 1.0f;
        }

        chipPlacement = -3.5f;

        // creates 5 chips by default 
        for (int x = 0; x < 5; x++)
        {
            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 2);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else // if 2; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);

            // sets index in chips array
            blankChip.GetComponent<Chips>().index = 10 + x;

            // instantiates Chip into scene
            chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 5, 0), Quaternion.identity));
            chipPlacement += 1.0f;
        }

        chipPlacement = -3.5f;

        // creates 5 chips by default 
        for (int x = 0; x < 5; x++)
        {
            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 2);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else // if 2; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);

            // sets index in chips array
            blankChip.GetComponent<Chips>().index = 15 + x;

            // instantiates Chip into scene
            chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 7, 0), Quaternion.identity));
            chipPlacement += 1.0f;
        }

        chipPlacement = -3.5f;

        // creates 5 chips by default 
        for (int x = 0; x < 5; x++)
        {
            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 2);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else // if 2; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);

            // sets index in chips array
            blankChip.GetComponent<Chips>().index = 20 + x;

            // instantiates Chip into scene
            chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 9, 0), Quaternion.identity));
            chipPlacement += 1.0f;
        }

        chipPlacement = -3.5f;

        // creates 5 chips by default 
        for (int x = 0; x < 5; x++)
        {
            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 2);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else // if 2; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);

            // sets index in chips array
            blankChip.GetComponent<Chips>().index = 25 + x;

            // instantiates Chip into scene
            chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 11, 0), Quaternion.identity));
            chipPlacement += 1.0f;
        }

        chipPlacement = -3.5f;

        // creates 5 chips by default 
        for (int x = 0; x < 5; x++)
        {
            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 2);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else // if 2; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);

            // sets index in chips array
            blankChip.GetComponent<Chips>().index = 30 + x;

            // instantiates Chip into scene
            chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 13, 0), Quaternion.identity));
            chipPlacement += 1.0f;
        }

        chipPlacement = -3.5f;

        // creates 5 chips by default 
        for (int x = 0; x < 5; x++)
        {
            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 2);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else // if 2; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);

            // sets index in chips array
            blankChip.GetComponent<Chips>().index = 35 + x;

            // instantiates Chip into scene
            chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 15, 0), Quaternion.identity));
            chipPlacement += 1.0f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            numberOfMoves--;
        if (numberOfMoves == 0)
            EndGame();

        HandleSwitching();
	}

    void EndGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    //Updated Switching
    void HandleSwitching()
    {
        //if tow elements are selected for switching 
        if(switchingArray[1] != null)
        {
            //And not in the process of switching, store the end positions
            if (!moving)
            {
                Pos1 = switchingArray[0].transform.position;
                Pos2 = switchingArray[1].transform.position;
                moving = true;
            }
            else
            {
                //only move a certain amount as not to get stuck
                if (count < 10)
                {
                    //Slowly move between the positions and add to count
                    switchingArray[0].transform.position += (Pos2 - switchingArray[0].transform.position) / 2f;
                    switchingArray[1].transform.position += (Pos1 - switchingArray[1].transform.position) / 2f;
                    count++;
                }
                else
                {
                    //reset the empty array and count while adding to score
                    moving = false;
                    switchingArray = new GameObject[2];
                    count = 0;
                    score += 10;
                }
            }
            
        }



        
    }
}
