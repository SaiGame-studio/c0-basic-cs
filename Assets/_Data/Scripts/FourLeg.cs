using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FourLeg : Animal
{
    public virtual string IsHasFur()
    {
        return "Yes";
    }

    public override int CountLeg()
    {
        return 4;
    }
}
