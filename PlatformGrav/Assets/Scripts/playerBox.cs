using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerBox : MonoBehaviour {

    // Use this for initialization
    public bool jump = false;
   public bool stop = false;
    public Camera cam;
   public Rigidbody rb;
  public int score;

    public Text scoreText;
    public Text winText;


    void Start () {
        score = 0;

        stop = false;
        jump = false;

        winText.text = "";
    }
	
	// Update is called once per frame
	void Update () {

        scoreText.text = "Score: " + score.ToString();


        if (stop == false)
        {
           transform.Translate(Vector3.right*5*Time.deltaTime);
            cam.transform.position = new Vector3(rb.transform.position.x + 1.0f, cam.transform.position.y, cam.transform.position.z);

            if (Input.GetMouseButtonUp(0)&&jump==true)
            {
                rb.AddForce(new Vector3(0.0f, 3.0f, 0.0f) * 2.5f, ForceMode.Impulse);
                jump = false;
            }

        }
        else
        {
            winText.text = "You Win!!!!";
        }


	}

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Ground")
        {
            jump = true;
        }

        if (other.gameObject.tag == "End")
        {
            stop = true;
        }

        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            score += 100;
        }
    }


}
