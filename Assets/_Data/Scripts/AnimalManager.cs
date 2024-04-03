using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] protected List<Animal> animals = new();
    [SerializeField] protected List<Animal> softByWeight = new();

    private void Start()
    {
        this.AddAnimalsToList();
        this.MakeAnimalsDoSomething();
        this.SoftAnimalsByWeight();
    }

    protected void SoftAnimalsByWeight()
    {
        Debug.Log("==== SoftAnimalsByWeight ====================");
        this.softByWeight = new(this.animals); //Clone,Copy
        Animal animalX, animalY;
        for (int x = 0; x < this.softByWeight.Count - 1; x++)
        {
            for (int y = x + 1; y < this.softByWeight.Count; y++)
            {
                animalX = this.softByWeight[x];
                animalY = this.softByWeight[y];

                if (animalX.GetWeight() > animalY.GetWeight())
                {
                    this.SwapAnimal(x,y);
                }
            }
        }

        foreach (Animal animal in this.softByWeight)
        {
            this.MakeAnimalDoSomething(animal);
        }
    }

    protected void SwapAnimal(int x, int y)
    {
        Animal animalZ;
        animalZ = this.softByWeight[y];
        this.softByWeight[y] = this.softByWeight[x];
        this.softByWeight[x] = animalZ;
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
        Debug.Log("==== MakeAnimalsDoSomething ====================");
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
