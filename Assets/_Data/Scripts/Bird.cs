using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bird : Animal
{
    int windCount = 2;

    public virtual int CountWind()
    {
        return this.windCount;
    }
}
