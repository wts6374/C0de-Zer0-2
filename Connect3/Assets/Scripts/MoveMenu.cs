using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenu : MonoBehaviour {

    Vector3[] xPositions;
    GameObject c1, c2, o, n1, n2, e, t;
    GameObject[] letters;

	// Use this for initialization
	void Start () {
        xPositions = new Vector3[7];

        c1 = GameObject.Find("C1");
        c2 = GameObject.Find("C2");
        o = GameObject.Find("O");
        n1 = GameObject.Find("N1");
        n2 = GameObject.Find("N2");
        t = GameObject.Find("T");
        e = GameObject.Find("E");

        letters = new GameObject[7];
        letters[0] = c1;
        letters[1] = o;
        letters[2] = n1;
        letters[3] = n2;
        letters[4] = e;
        letters[5] = c2;
        letters[6] = t;


        xPositions[0] = new Vector3(405, 259, -74) + new Vector3(0, 0, 0);
        xPositions[1] = new Vector3(405, 259, -74) + new Vector3(35, 0, 0);
        xPositions[2]  = new Vector3(405, 259, -74) + new Vector3(67, 0, 0);
        xPositions[3]  = new Vector3(405, 259, -74) + new Vector3(112, 0, 0);
        xPositions[4] = new Vector3(405, 259, -74) + new Vector3(178, 0, 0);
        xPositions[5]  = new Vector3(405, 259, -74) + new Vector3(200, 0, 0);
        xPositions[6] = new Vector3(405, 259, -74) + new Vector3(240, -3, 0);
	}
	
	// Update is called once per frame
	void Update () {
        MoveMenuLetters();
	}

    void MoveMenuLetters()
    {
        for (int i =0; i< letters.Length; i++)
        {
            if (letters[i].transform.position != xPositions[i])
            {
                letters[i].transform.position = Vector3.MoveTowards(letters[i].transform.position, xPositions[i], 2);
            }
            else
            {
                if (i == 4)
                {
                    letters[i].transform.Rotate(3, 0, 0);
                }
            }
        }
    }
}
