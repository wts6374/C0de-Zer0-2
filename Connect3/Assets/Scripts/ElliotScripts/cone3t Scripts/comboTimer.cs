using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboTimer : MonoBehaviour {

    bool comboing;
    float comboEndTime;

	// Use this for initialization
	void Start () {
        comboing = false;
        comboEndTime = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
       

        if(comboing == true)
        {
            comboEndTime -= Time.deltaTime;
            //if() // determines whether combo is occuring or not
            {
                //comboEndTime += added time from continuous combo
            }
            if (comboEndTime <= 0.0f)
            {
                comboing = false;
                comboEndTime = 20.0f;
            }
        }
        //else if() // determines whether combo is occuring or not
        {
            comboing = true;
        }


    }
}
