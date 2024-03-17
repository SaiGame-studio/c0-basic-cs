using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : FourLeg
{
    public override string GetName()
    {
        return "Piggy";
    }

    public override string MakeSound()
    {
        return "ec ec";
    }

    public override string IsHasFur()
    {
        return "No";
    }
}
