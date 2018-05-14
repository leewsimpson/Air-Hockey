using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public Puck Puck;
    public Player Player1;
    public Player Player2;
   
    private void OnTriggerEnter(Collider other)
    {
      if(other.name == Puck.name)
        {
            Puck.Reset();
            if(this.name.Contains("1"))
            {
                Player2.Score();
                Player1.Lose();
                Puck.PlayGoalSound();
            }
            else
            {
                Player1.Score();
                Player2.Lose();
                Puck.PlayGoalSound();
            }
        }
    }
}
