using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : FourLeg
{
    public override string GetName()
    {
        return "Puppy";
    }

    public override string MakeSound()
    {
        string sound = "wo wo";
        return sound;
    }

    void GuardHouse()
    {

    }
}
