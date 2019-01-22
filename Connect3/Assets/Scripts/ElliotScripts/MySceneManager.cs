using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {

    public int numberOfMoves;
    public float score;
	// Use this for initialization
	void Start () {
        numberOfMoves = 5;
        score = 0;
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

    }
}
