using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FourLeg : MonoBehaviour
{
    string petName = "#noName";
    string petSound = "#noName";
    int legCount = 4;
    int tailCount = 1;

    public abstract string GetName();
    public abstract string MakeSound();

    public virtual string IsHasFur()
    {
        return "Yes";
    }
}
