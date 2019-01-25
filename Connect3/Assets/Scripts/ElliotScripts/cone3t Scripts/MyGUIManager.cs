using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGUIManager : MonoBehaviour {

    MySceneManager sceneManager;
    ComboTimer comboTimer;
    GUIStyle style;

    private void Start()
    {
        sceneManager = GetComponent<MySceneManager>();
        comboTimer = GetComponent<ComboTimer>();
    }

    private void OnGUI()
    {
        if (sceneManager != null && comboTimer != null)
        {
            GUI.TextArea(new Rect(10, 10, 110, 200), "Score: " + sceneManager.score + "\nMoves: " + sceneManager.numberOfMoves + "\nCombo Timer: " + (int)comboTimer.comboEndTime);
        }
       
    }
}
