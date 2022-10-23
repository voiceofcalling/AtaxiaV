using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public InputField iField; 
    public int val;
    
    void OnEnable()
    {
    StartCoroutine(CountdownToStart());
    }
   IEnumerator CountdownToStart()
   {
    while(countdownTime>0)
    {
        countdownDisplay.text = countdownTime.ToString();
        
        yield return new WaitForSeconds(1f);

        countdownTime--;
    }
    
    countdownDisplay.text = "GO!";

    TimeController.instance.BeginTimer();
    
    yield return new WaitForSeconds(1f);

    countdownDisplay.gameObject.SetActive(false);
   }
   void PauseGame()
   {
    Time.timeScale=0;
   }
   void ResumeGame()
   {
    Time.timeScale=1;
   }
}
