using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using System.IO;
using LeapInternal;


public class Coordinates_LTRG : MonoBehaviour
{
    Controller controller;
    // Start is called before the first frame update
    StringBuilder xyz = new StringBuilder();
    void Start()
    {
        
        controller = new Leap.Controller();
        xyz.AppendLine(string.Format("{0},{1},{2}", "X", "Y", "Z"));
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
                //Suggestion made by KyleMit
                
                var newLine = string.Format("{0},{1},{2}", curhand.PalmPosition.x, curhand.PalmPosition.y, curhand.PalmPosition.z);
                xyz.AppendLine(newLine);  
                //Debug.Log("Hand #" + i + "- x: " + curhand.PalmPosition.x + ", y: " + curhand.PalmPosition.y + ", z: " + curhand.PalmPosition.z);
            }
        }
        
    }
    void OnApplicationQuit()
    {
DateTime localDate = DateTime.Now;
        String day = "";
        if(localDate.Day < 10) {
            day += "0" + localDate.Day;
        } else {
            day += localDate.Day;
        }
        String mon = "";
        if(localDate.Month < 10) {
            mon += "0" + localDate.Month;
        } else {
            mon += localDate.Month;
        }
        //Debug.Log(localDate.ToString());
        File.WriteAllText("C:/Users/leejy/OneDrive/Documents/GitHub/AtaxiaV/ver_3.2/AtaxiaV/RAW DATA/R" + localDate.Year + mon + day + localDate.Hour + localDate.Minute+ "_TR.csv", xyz.ToString());
        
    }
    /*Leap.Vector leapToWorld(Leap.Vector leapPoint, InteractionBox iBox)
    {
        leapPoint.z *= -1.0f; //right-hand to left-hand rule
        Leap.Vector normalized = iBox.NormalizePoint(leapPoint, false);
        normalized += new Leap.Vector(0.5f, 0f, 0.5f); //recenter origin
        return normalized * 100.0f; //scale

    }*/
}