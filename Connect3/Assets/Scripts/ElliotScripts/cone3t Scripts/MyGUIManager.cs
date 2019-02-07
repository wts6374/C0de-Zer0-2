using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGUIManager : MonoBehaviour {

    MySceneManager sceneManager;
    ComboTimer comboTimer;

    private void Start()
    {
        sceneManager = this.GetComponent<MySceneManager>();
        comboTimer = this.GetComponent<ComboTimer>();
    }

    private void OnGUI()
    {
        GUI.TextArea(new Rect(10, 100, 110, 50), "Score: " +
            sceneManager.score + "\n\nMoves: " +
            sceneManager.numberOfMoves + "\nCombo Timer: " +
            (int)comboTimer.comboEndTime
            );

        //GUI.TextArea(new Rect(10,10,110,50), "Score: " + sceneManager.score + "\nMoves: " + sceneManager.numberOfMoves + "\nCombo Timer: " +(int)comboTimer.comboEndTime);
    }
}
