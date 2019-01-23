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

	// Use this for initialization
	void Start () {
        chips = new List<GameObject>();
        numberOfMoves = 5;
        score = 0;

        // REMOVE LATER
        // value used to place chips next to each other for testing purposes
        int chipPlacement = 0;

        // creates 5 chips by default 
        for(int x = 0; x < 5; x++)
        {
            // randomly chooses either 1 or 2
            int randomNum = Random.Range(0, 2);

            // if 1; sets Chip identifier to 1 and gives it the red material
            if(randomNum == 1)
                blankChip.GetComponent<Chips>().SetChip(1, redMat);
            else // if 2; sets Chip identifier to 0 and gives it the blue material
                blankChip.GetComponent<Chips>().SetChip(0, blueMat);

            // instantiates Chip into scene
            chips.Add(Instantiate(blankChip, new Vector3(chipPlacement, 1, 1), Quaternion.identity));
            chipPlacement += 1;
        }
            

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            numberOfMoves--;
        if (numberOfMoves == 0)
            EndGame();
	}

    void EndGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
