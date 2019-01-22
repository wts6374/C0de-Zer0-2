using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGUIManager : MonoBehaviour {

    MySceneManager sceneManager;

    private void Start()
    {
        sceneManager = this.GetComponent<MySceneManager>();
    }

    private void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 100, 40), "Score: " + sceneManager.score + "\nMoves: " + sceneManager.numberOfMoves);
    }
}
