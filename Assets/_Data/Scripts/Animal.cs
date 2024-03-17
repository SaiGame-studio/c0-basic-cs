using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    int legCount = 2;

    public abstract string GetName();
    public abstract string MakeSound();

    public virtual int CountLeg()
    {
        return this.legCount;
    }

    public virtual string GetInfo()
    {
        return this.GetName() + "/" + this.MakeSound() + "/Leg:" + this.CountLeg();
            
    }
}
