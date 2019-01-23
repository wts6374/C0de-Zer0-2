using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chips : MonoBehaviour {

    public int chipNumCode;

    public void SetChip(int num, Material mat)
    {
        this.GetComponent<Renderer>().material = mat;
        chipNumCode = num;
    }
}
