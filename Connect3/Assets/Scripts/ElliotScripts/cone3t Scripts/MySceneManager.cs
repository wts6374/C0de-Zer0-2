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
    int chip1Index;
    int chip2Index;
    Vector3 chip1Switch;
    Vector3 chip2Switch;
    bool switchUp;
    bool switchDown;
    bool switchLeft;
    bool switchRight;
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
        if (switchingArray[1] != null)
        {
            //Debug.Log("INSIDE");
            //if(switchingArray[0].transform.position.x - switchingArray[1].transform.position.x < 0)
            //{

            //}


            chip1Index = switchingArray[0].GetComponent<Chips>().index;
            chip2Index = switchingArray[1].GetComponent<Chips>().index;

            switching = true;

            chip1Switch = switchingArray[0].GetComponent<Transform>().position;
            chip2Switch = switchingArray[1].GetComponent<Transform>().position;

            // switchingArray[0].GetComponent<SphereCollider>().enabled = false;
            // switchingArray[1].GetComponent<SphereCollider>().enabled = false;

            // switchingArray[0].GetComponent<BoxCollider>().enabled = false;
            // switchingArray[1].GetComponent<BoxCollider>().enabled = false;

            for(int x = 0; x < chips.Count; x++)
            {
                // chips[x].GetComponent<BoxCollider>().enabled = false;
                // chips[x].GetComponent<SphereCollider>().enabled = false;
                Destroy(chips[x].GetComponent<Rigidbody>());
            }

            for (int x = 0; x < 2; x++)
                switchingArray[x] = null;

            //if (chips[chip1Index].transform.position.y < chip2Switch.y)
            //    switchUp = true;
            //else if (chips[chip1Index].transform.position.y > chip2Switch.y)
            //    switchDown = true;
            //else if (chips[chip1Index].transform.position.x < chip2Switch.x)
            //    switchRight = true;
            //else
            //    switchLeft = true;

            if (Mathf.Abs(chips[chip1Index].transform.position.y - chip2Switch.y) > .5f && chip2Switch.y > chips[chip1Index].transform.position.y)
                switchUp = true;
            else if (Mathf.Abs(chips[chip1Index].transform.position.y - chip2Switch.y) > .5f)
                switchDown = true;
            else if (Mathf.Abs(chips[chip1Index].transform.position.x - chip2Switch.x) > .5f && chip2Switch.x > chips[chip1Index].transform.position.x)
                switchRight = true;
            else
                switchLeft = true;
            

        }
        
        if(switching)
        {
            // Vector3 pos1 = switchingArray[0].transform.position;
            // Vector3 pos2 = switchingArray[1].transform.position;
            // switching = false;
          
            if (switchUp)
            {
                float newYValue1 = chips[chip1Index].GetComponent<Transform>().position.y + .05f;
                float newYValue2 = chips[chip2Index].GetComponent<Transform>().position.y - .05f;

                Vector3 newChip1Pos = new Vector3(chip1Switch.x, newYValue1, chip1Switch.z);
                Vector3 newChip2Pos = new Vector3(chip2Switch.x, newYValue2, chip2Switch.z);

                chips[chip1Index].transform.position = newChip1Pos;
                chips[chip2Index].transform.position = newChip2Pos;
                
                if(Mathf.Abs(chips[chip1Index].transform.position.y - chip2Switch.y) < .2f)
                {
                    switchUp = false;
                }
            }
            else if(switchDown)
            {
                float newYValue1 = chips[chip1Index].GetComponent<Transform>().position.y - .05f;
                float newYValue2 = chips[chip2Index].GetComponent<Transform>().position.y + .05f;

                Vector3 newChip1Pos = new Vector3(chip1Switch.x, newYValue1, chip1Switch.z);
                Vector3 newChip2Pos = new Vector3(chip2Switch.x, newYValue2, chip2Switch.z);

                chips[chip1Index].transform.position = newChip1Pos;
                chips[chip2Index].transform.position = newChip2Pos;

                if (Mathf.Abs(chips[chip1Index].transform.position.y - chip2Switch.y) < .2f)
                {
                    switchDown = false;
                }
            }
            else if (switchLeft)
            {
                float newXValue1 = chips[chip1Index].GetComponent<Transform>().position.x - .05f;
                float newXValue2 = chips[chip2Index].GetComponent<Transform>().position.x + .05f;

                Vector3 newChip1Pos = new Vector3(newXValue1, chip1Switch.y, chip1Switch.z);
                Vector3 newChip2Pos = new Vector3(newXValue2, chip2Switch.y, chip2Switch.z);

                chips[chip1Index].transform.position = newChip1Pos;
                chips[chip2Index].transform.position = newChip2Pos;

                if (Mathf.Abs(chips[chip1Index].transform.position.x - chip2Switch.x) < .2f)
                {
                    switchLeft = false;
                }
            }
            else if (switchRight)
            {
                float newXValue1 = chips[chip1Index].GetComponent<Transform>().position.x + .05f;
                float newXValue2 = chips[chip2Index].GetComponent<Transform>().position.x - .05f;

                Vector3 newChip1Pos = new Vector3(newXValue1, chip1Switch.y, chip1Switch.z);
                Vector3 newChip2Pos = new Vector3(newXValue2, chip2Switch.y, chip2Switch.z);

                chips[chip1Index].transform.position = newChip1Pos;
                chips[chip2Index].transform.position = newChip2Pos;

                if (Mathf.Abs(chips[chip1Index].transform.position.x - chip2Switch.x) < .2f)
                {
                    switchRight = false;
                }
            }
            else
            {
                switching = false;
                for (int x = 0; x < chips.Count; x++)
                    chips[x].AddComponent<Rigidbody>();
                Debug.Log("Switching over");
                return;
            }
        }
        


        // switchingArray[0].transform.position = pos2;
        // switchingArray[1].transform.position = pos1;

        // score += 10;

        
        



        
    }
}
