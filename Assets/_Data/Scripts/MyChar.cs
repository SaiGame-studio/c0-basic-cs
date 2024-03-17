using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyChar : MonoBehaviour
{
    string charName = "No Name";
    int hp = 7;
    float weight = 7.4f;
    float runSpeed = 15f;

    void Start()
    {
        Debug.Log("Start");
        this.charName = this.GetMyCharName();
        Debug.Log(this.charName);
    }

    void Update()
    {
        Debug.Log("Update");
        //this.GetMyCharName();
    }

    string GetMyCharName()
    {
        string newName = "Simon";
        Debug.Log("GetMyCharName");
        return newName;
    }

    void Running()
    {

    }

    void Jump()
    {

    }
}
