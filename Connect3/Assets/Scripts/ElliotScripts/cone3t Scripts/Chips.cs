using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chips : MonoBehaviour {

    public int chipNumCode;
    public int index;

    public void SetChip(int num, Material mat)
    {
        this.GetComponent<Renderer>().material = mat;
        chipNumCode = num;
    }

    private void OnMouseDown()
    {
        GameObject[] localSwitch = GameObject.Find("MySceneManager").GetComponent<MySceneManager>().switchingArray;

        if (Input.GetMouseButtonDown(0) && localSwitch[1] == null)
        {
            if (localSwitch[0] == null)
                localSwitch[0] = this.gameObject;
            else
                localSwitch[1] = this.gameObject;
        }
    }
}
