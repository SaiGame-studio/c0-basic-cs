using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : FourLeg
{
    public override string GetName()
    {
        return "Kitty";
    }

    public override string MakeSound()
    {
        string sound = "meow moew";
        return sound;
    }

    void CatchRat()
    {

    }
}
