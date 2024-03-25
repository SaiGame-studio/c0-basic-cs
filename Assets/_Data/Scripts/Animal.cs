using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    int legCount = 2;
    float weight = 0f;

    private void Start()
    {
        this.RandomWeight();
    }

    public abstract string GetName();
    public abstract string MakeSound();

    protected virtual void RandomWeight()
    {
        this.weight = Random.Range(1f, 3f);
    }

    public virtual float GetWeight()
    {
        return this.weight;
    }

    public virtual int CountLeg()
    {
        return this.legCount;
    }

    public virtual string GetInfo()
    {
        return this.GetName() + "/"
            + this.MakeSound()
            + "/Leg:"
            + this.CountLeg()
            + "/Weight:"
            + this.GetWeight();

    }
}
