using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : Agent
{
    RayPerception rayPer;
    Player player;

    public override void InitializeAgent()
    {
        rayPer = GetComponent<RayPerception>();
        player = GetComponent<Player>();
    }

    public override void CollectObservations()
    {
        float rayDistance = 20f;
        float[] rayAngles = { 0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f };
        string[] detectableObjects;

        //if (side == Side.Player1)
        //{
        //    detectableObjects = new string[] { "Puck", "Player2Goal", "Player1Goal", "Side", "Player2Agent", "Player1Agent" };
        //}
        //else
        //{
            detectableObjects = new string[] { "Puck", "Player1Goal", "Player2Goal", "Side", "Player1", "Player2" };
        //}

        AddVectorObs(rayPer.Perceive(rayDistance, rayAngles, detectableObjects, 0f, 0f));
        //AddVectorObs(rayPer.Perceive(rayDistance, rayAngles, detectableObjects, 1f, 0f));
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        int action = Mathf.FloorToInt(vectorAction[0]);
        Vector3 direction = Vector3.zero;

        switch (action)
        {
            case 0:
                direction = transform.right * 0.5f * player.Speed;
                break;
            case 1:
                direction = transform.right * -0.5f * player.Speed;
                break;
            case 2:
                direction = transform.up * 0.5f * player.Speed;
                break;
            case 3:
                direction = transform.up * -0.5f * player.Speed;
                break;
        }

        GetComponent<Rigidbody>().velocity = direction;
    }

}
