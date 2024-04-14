using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] protected bool showLog = true;
    [SerializeField] protected List<Transform> defaultAnimals = new();
    [SerializeField] protected List<Animal> animals = new();
    [SerializeField] protected List<Animal> sortByWeight = new();

    private void Start()
    {
        long startTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("============ startTime: " + startTime);

        this.LoadDefaultAnimals();
        this.CreateRandomAnimals();

        this.AddAnimalsToList();
        this.MakeAnimalsDoSomething();
        this.SoftAnimalsByWeight();

        long nowTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("============ nowTime: " + nowTime);

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("============  timeDiff: " + timeDiff);
    }

    protected void CreateRandomAnimals()
    {
        int createCount = 20000;
        for (int i = 0; i< createCount;i++)
        {
            this.CreateRandomAnimal();
        }
    }

    protected void CreateRandomAnimal()
    {
        Transform randomChild = this.GetRandomFromDefaultAnimals();
        Transform newChild = GameObject.Instantiate(randomChild);
        newChild.parent = transform;
    }

    protected Transform GetRandomFromDefaultAnimals()
    {
        int randIndex = Random.Range(0, this.defaultAnimals.Count);
        return this.defaultAnimals[randIndex];
    }

    protected void LoadDefaultAnimals()
    {
        foreach (Transform child in transform)
        {
            this.defaultAnimals.Add(child);
        }
    }

    protected void SoftAnimalsByWeight()
    {
        Debug.Log("==== SoftAnimalsByWeight ====================");
        this.sortByWeight = new(this.animals); //Clone,Copy
        Animal animalX, animalY;
        for (int x = 0; x < this.sortByWeight.Count - 1; x++)
        {
            for (int y = x + 1; y < this.sortByWeight.Count; y++)
            {
                animalX = this.sortByWeight[x];
                animalY = this.sortByWeight[y];

                if (animalX.GetWeight() > animalY.GetWeight())
                {
                    this.SwapAnimal(x,y);
                }
            }
        }

        foreach (Animal animal in this.sortByWeight)
        {
            this.MakeAnimalDoSomething(animal);
        }
    }

    protected void SwapAnimal(int x, int y)
    {
        Animal animalZ;
        animalZ = this.sortByWeight[y];
        this.sortByWeight[y] = this.sortByWeight[x];
        this.sortByWeight[x] = animalZ;
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
        if(this.showLog == true) Debug.Log(animal.name + ": " + info);
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
