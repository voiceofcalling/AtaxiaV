using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using LeapInternal;


public class Coordinates : MonoBehaviour
{
    Controller controller;
    // Start is called before the first frame update
    void Start()
    {
            controller = new Leap.Controller();
        
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = controller.Frame();
        if (frame.Hands.Count > 0)
        {
            List<Hand> hands = frame.Hands;
            Hand firstHand = hands[0];
            for (int i = 0; i < hands.Count;i++)
            {
                Hand curhand = hands[i];
                //Debug.Log("Hand #" + i + "- x: " + curhand.PalmPosition.x + ", y: " + curhand.PalmPosition.y + ", z: " + curhand.PalmPosition.z);
            }
        }
        
    }
    /*Leap.Vector leapToWorld(Leap.Vector leapPoint, InteractionBox iBox)
    {
        leapPoint.z *= -1.0f; //right-hand to left-hand rule
        Leap.Vector normalized = iBox.NormalizePoint(leapPoint, false);
        normalized += new Leap.Vector(0.5f, 0f, 0.5f); //recenter origin
        return normalized * 100.0f; //scale

    }*/
}
