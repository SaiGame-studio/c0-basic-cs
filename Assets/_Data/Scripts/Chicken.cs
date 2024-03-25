using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Bird
{
    public override string GetName()
    {
        return "Ga";
    }

    public override string MakeSound()
    {
        return "Cuc cuc";
    }
}
