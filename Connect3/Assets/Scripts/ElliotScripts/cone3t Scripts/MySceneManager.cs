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
    public bool switching;
    float switchValue;
    //int secondSwitchValue;

    private Vector3 screenPoint;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        switching = false;
        chips = new List<GameObject>();
        numberOfMoves = 30;
        score = 0;
        switchValue = .05f;

        switchingArray = new GameObject[2];
        
        // REMOVE LATER
        // value used to place chips next to each other for testing purposes
        float chipPlacement = -3.5f;

        // creates 5 chips by default 
        for(int x = 0; x < 5; x++)
        {
            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 3);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if(randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else if(randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);
            else
                blankChip.GetComponent<Chips>().SetChip(2, greenMat);

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
            int randomNum = Random.Range(0, 3);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else if (randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);
            else
                blankChip.GetComponent<Chips>().SetChip(2, greenMat);

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
            int randomNum = Random.Range(0, 3);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else if (randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);
            else
                blankChip.GetComponent<Chips>().SetChip(2, greenMat);

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
            int randomNum = Random.Range(0, 3);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else if (randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);
            else
                blankChip.GetComponent<Chips>().SetChip(2, greenMat);

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
            int randomNum = Random.Range(0, 3);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else if (randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);
            else
                blankChip.GetComponent<Chips>().SetChip(2, greenMat);

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
            int randomNum = Random.Range(0, 3);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else if (randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);
            else
                blankChip.GetComponent<Chips>().SetChip(2, greenMat);

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
            int randomNum = Random.Range(0, 3);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else if (randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);
            else
                blankChip.GetComponent<Chips>().SetChip(2, greenMat);

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
            int randomNum = Random.Range(0, 3);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if (randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else if (randomNum == 0)// if 0; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);
            else
                blankChip.GetComponent<Chips>().SetChip(2, greenMat);

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

    void HandleSwitching()
    {
        if(switchingArray[1] != null)
        {
            //Debug.Log("INSIDE");
            //if(switchingArray[0].transform.position.x - switchingArray[1].transform.position.x < 0)
            //{

            //}
            switching = true;

            Vector3 pos1 = switchingArray[0].transform.position;
            Vector3 pos2 = switchingArray[1].transform.position;

            int switchIndex = 0;

            if (switching == true)
            {
                if (switchingArray[0].transform.position.x == switchingArray[1].transform.position.x)
                    if (switchingArray[0].transform.position.y > switchingArray[1].transform.position.y)
                        switchIndex = 1;
                    else
                        switchIndex = 2;
                else if (switchingArray[0].transform.position.y == switchingArray[1].transform.position.y)
                    if (switchingArray[0].transform.position.x < switchingArray[1].transform.position.x)
                        switchIndex = 3;
                    else
                        switchIndex = 4;


            }

            if(switching)
            {
                if (switchIndex == 1)
                {
                    if (switchValue <= 1)
                    {
                        pos1.x -= .05f;
                        pos2.x += .05f;
                        switchValue += .05f;
                    }
                    else
                    {
                        switching = false;
                        switchValue = .05f;
                    }
                        
                }

            }


            switchingArray[0].transform.position = pos2;
            switchingArray[1].transform.position = pos1;

            // score += 10;

            for (int x = 0; x < 2; x++)
                switchingArray[x] = null;
        }



        
    }
}
