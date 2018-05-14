using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float Speed = 10f;
    public int Points = 0;
    public TextMesh text;

    PlayerBrain playerBrain;

    public void Start()
    {
        playerBrain = GetComponent<PlayerBrain>();
    }

    void Update ()
    {
        //if (name == "Player1")
        //{
        //    GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis("Vertical") * Speed, 0, -Input.GetAxis("Horizontal") * Speed);
        //}
        //else if(name == "Player2")
        //{
        //    GetComponent<Rigidbody>().velocity = new Vector3(-Input.GetAxis("Vertical2") * Speed, 0, Input.GetAxis("Horizontal2") * Speed);
        //}
	}

    public void Score()
    {
        Points++;
        text.text = "SCORE " + Points;

        playerBrain.AddReward(-0.1f);
        playerBrain.Done();
    }

    public void Lose()
    {
        if (playerBrain != null)
        {
            playerBrain.AddReward(-0.1f);
            playerBrain.Done();
        }
    }
}
