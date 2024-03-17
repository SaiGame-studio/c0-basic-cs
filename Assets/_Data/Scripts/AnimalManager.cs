using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] protected List<Animal> animals = new();

    private void Start()
    {
        this.AddAnimalsToList();
        this.MakeAnimalsDoSomething();
    }

    protected void AddAnimalsToList()
    {
        foreach (Transform child in transform)
        {
            Animal animal = child.GetComponent<Animal>();
            this.animals.Add(animal);
        }
    }

    protected void MakeAnimalsDoSomething()
    {
        foreach (Animal animal in this.animals)
        {
            this.MakeAnimalDoSomething(animal);
        }
    }

    protected void MakeAnimalDoSomething(Animal animal)
    {
        string info = animal.GetInfo();
        Debug.Log(animal.name + ": " + info);
    }

    protected void AddAnimalsToList2()
    {
        Dog dog = new();
        this.animals.Add(dog);

        Dog dog2 = new();
        this.animals.Add(dog2);

        Cat cat = new();
        this.animals.Add(cat);

        Pig pig = new();
        this.animals.Add(pig);

        Pig pig2 = new();
        this.animals.Add(pig2);

        Pig pig3 = new();
        this.animals.Add(pig3);
    }
}
