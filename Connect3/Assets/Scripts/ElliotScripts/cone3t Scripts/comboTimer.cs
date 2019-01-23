using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTimer : MonoBehaviour {

    public bool comboing;
    public float comboEndTime;

	// Use this for initialization
	void Start () {
        comboing = false;
        comboEndTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
       
        // checks if currently comboing
        if(comboing == true)
        {
            // detracts time from comboEndTime
            comboEndTime -= Time.deltaTime;

            // checks if comboEndTImer is finished
            if (comboEndTime <= 0.0f)
            {
                // if combo ends, make comboing false and set the time back to 0
                comboing = false;
                comboEndTime = 0.0f;
            }
        }

        if(false) // determines whether combo is occuring or not
        {
            // makes sure comboing is equal to true and adds time to the combo timer
            comboing = true;
            comboEndTime += 10.0f;
        }


    }
}
