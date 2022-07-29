using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using System.IO;
using LeapInternal;
public class TouchBall : MonoBehaviour
{ 
    StringBuilder real = new StringBuilder();
    int numoftouch = 0;
   // int time = 0;
   ArrayList times = new ArrayList();
    bool timerActive = true;
    float timeStart = 0;
   // float temptime = 0;
   void Start() {
    real.AppendLine(string.Format("{0},{1},{2},{3},{4}", "Recent Time", "Number of Touches", "Minimum Time", "Maximum Time", "Average Time"));

   }
    public void PerControllerContactBegin(){
        
        timerActive = !timerActive;
        //temptime = timeStart-temptime;
        //Debug.Log("Time Taken: " + (temptime).ToString("F2"));
        if(timeStart <= 0.25) return;
        numoftouch+=1;
        times.Add(float.Parse((timeStart).ToString("F2")));
        float min = (float)times[0];
        float avg = 0;
        float max = (float)times[0];
        int cnt = 0;
        foreach (float i in times) {
            if(min > i) {
                min = i;
            }
            if(max < i) {
                max = i;
            }
            avg+=i;
            cnt++;
        }
        avg /=cnt;
        var newLine = string.Format("{0},{1},{2},{3},{4}", (timeStart).ToString("F2"), numoftouch, min, max, avg);
        timeStart = 0;
        real.AppendLine(newLine);  
        
    }
    void Update (){
        if(timerActive){
            timeStart += Time.deltaTime;
            //Debug.Log("Time Taken: " + (timeStart).ToString("F2"));
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
        File.WriteAllText("C:/Users/leejy/OneDrive/Documents/GitHub/AtaxiaV/ver_3.2/AtaxiaV/FINAL DATA/F" + localDate.Year + mon + day + localDate.Hour + localDate.Minute+ "_TR.csv", real.ToString());
    }
}
