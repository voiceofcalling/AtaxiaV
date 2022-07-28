using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    int threw = 0;
    int grabs = 0;
    // Start is called before the first frame update
    public void endGrasped() {
        threw += 1;
        Debug.Log("Throws: " + threw);
    }
    public void startGrasped() {
        grabs += 1;
        Debug.Log("Grabs: " + grabs);
    }
}
