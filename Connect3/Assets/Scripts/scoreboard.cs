using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreboard : MonoBehaviour {

    MySceneManager sceneManager;
    //ComboTimer comboTimer;
    public Text scoreText;

    // Use this for initialization
    void Start () {
        sceneManager = this.GetComponent<MySceneManager>();
        //comboTimer = this.GetComponent<ComboTimer>();
        scoreText.text = "Score: " +
            sceneManager.score + "\nMoves: " 
            //sceneManager.numberOfMoves + "\nCombo Timer: " 
            //(int)comboTimer.comboEndTime
            ;
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " +
            sceneManager.score + "\nMoves: " +
            sceneManager.numberOfMoves + "\nCombo Timer: " 
            //(int)comboTimer.comboEndTime
            ;
    }
}
