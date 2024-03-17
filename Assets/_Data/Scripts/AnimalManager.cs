using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    protected List<FourLeg> fourLegs = new();

    private void Start()
    {
        this.AddAnimalsToList();
        this.MakeAnimalsDoSomething();
    }

    protected void AddAnimalsToList()
    {
        foreach (Transform child in transform)
        {
            FourLeg fourLeg = child.GetComponent<FourLeg>();
            this.fourLegs.Add(fourLeg);
        }
    }

    protected void MakeAnimalsDoSomething()
    {
        foreach (FourLeg fourLeg in this.fourLegs)
        {
            this.MakeAnimalDoSomething(fourLeg);
        }
    }

    protected void MakeAnimalDoSomething(FourLeg fourLeg)
    {
        string name = fourLeg.GetName();
        string sound = fourLeg.MakeSound();
        Debug.Log(name + ": " + sound);

        Debug.Log("IsHasFur: " + fourLeg.IsHasFur());
    }

    protected void AddAnimalsToList2()
    {
        Dog dog = new();
        this.fourLegs.Add(dog);

        Dog dog2 = new();
        this.fourLegs.Add(dog2);

        Cat cat = new();
        this.fourLegs.Add(cat);

        Pig pig = new();
        this.fourLegs.Add(pig);

        Pig pig2 = new();
        this.fourLegs.Add(pig2);

        Pig pig3 = new();
        this.fourLegs.Add(pig3);
    }
}
