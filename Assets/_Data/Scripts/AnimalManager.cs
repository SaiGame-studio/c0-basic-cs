using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] protected List<Animal> fourLegs = new();

    private void Start()
    {
        this.AddAnimalsToList();
        this.MakeAnimalsDoSomething();
    }

    protected void AddAnimalsToList()
    {
        foreach (Transform child in transform)
        {
            Animal fourLeg = child.GetComponent<Animal>();
            this.fourLegs.Add(fourLeg);
        }
    }

    protected void MakeAnimalsDoSomething()
    {
        foreach (Animal fourLeg in this.fourLegs)
        {
            this.MakeAnimalDoSomething(fourLeg);
        }
    }

    protected void MakeAnimalDoSomething(Animal fourLeg)
    {
        string info = fourLeg.GetInfo();
        Debug.Log(fourLeg.name + ": " + info);
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
