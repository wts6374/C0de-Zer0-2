using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chips : MonoBehaviour {

    public int chipNumCode;
    public int index;
    public int gridX;
    public int gridY;

    public void SetChip(int num, Material mat)
    {
        // sets num and mat given to the chip through this function
        // from the MySceneManager
        this.GetComponent<Renderer>().material = mat;
        chipNumCode = num;
    }

    private void OnMouseDown()
    {
        // grabs list that holds the two chips being switched from MySceneManager
        GameObject[] localSwitch = GameObject.Find("MySceneManager").GetComponent<MySceneManager>().switchingArray;

        // checks if switching array is full and mouse button has been pressed on it.
        if (Input.GetMouseButtonDown(0) && localSwitch[1] == null)
        {
            // if the first element is null, place this chip in the first slot
            if (localSwitch[0] == null)
                localSwitch[0] = this.gameObject;
            else // put in the second slot if the first slot is already filled
                localSwitch[1] = this.gameObject;
        }
    }
}
