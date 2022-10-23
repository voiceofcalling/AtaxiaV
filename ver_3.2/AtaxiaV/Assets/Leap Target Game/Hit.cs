using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    int hit = 0;
    void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "Throw"){
            hit++;
            Debug.Log("Hits: " + hit);
        }
    }
}
