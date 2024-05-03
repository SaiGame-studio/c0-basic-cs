using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] protected bool showLog = true;
    [SerializeField] protected List<Transform> defaultAnimals = new();
    [SerializeField] protected List<Animal> animals = new();
    public List<Animal> Animals => animals;

    private void Start()
    {
        //this.AnimalManaging();
        Invoke(nameof(this.AnimalManaging), 7);
        //InvokeRepeating(nameof(this.RepeateMe), 3, 2);
        //InvokeRepeating(nameof(this.RepeateMe2), 7, 1);
    }

    protected void RepeateMe()
    {
        Debug.Log("hello 1");
    }

    protected void RepeateMe2()
    {
        Debug.Log("hello 2");
    }

    protected void AnimalManaging()
    {
        long startTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("== startTime: " + startTime);

        this.LoadDefaultAnimals();
        this.CreateRandomAnimals();

        this.AddAnimalsToList();
        this.MakeAnimalsDoSomething();

        long nowTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("== nowTime: " + nowTime);

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("==  timeDiff: " + timeDiff);
    }

    protected void CreateRandomAnimals()
    {
        long startTime = UnixTime.GetUnixTimeMicro();

        int createCount = 20000;
        for (int i = 0; i< createCount;i++)
        {
            this.CreateRandomAnimal();
        }

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("== CreateRandomAnimals timeDiff: " + timeDiff);
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
        long startTime = UnixTime.GetUnixTimeMicro();

        foreach (Transform child in transform)
        {
            this.defaultAnimals.Add(child);
        }

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("== LoadDefaultAnimals timeDiff: " + timeDiff);
    }



    protected void AddAnimalsToList()
    {
        long startTime = UnixTime.GetUnixTimeMicro();

        foreach (Transform child in transform)
        {
            Animal animal = child.GetComponent<Animal>();
            this.animals.Add(animal);
        }

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("== AddAnimalsToList timeDiff: " + timeDiff);
    }

    protected void MakeAnimalsDoSomething()
    {
        long startTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("==== MakeAnimalsDoSomething ====================");

        foreach (Animal animal in this.animals)
        {
            this.MakeAnimalDoSomething(animal);
        }

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("== MakeAnimalsDoSomething timeDiff: " + timeDiff);
    }

    public void MakeAnimalDoSomething(Animal animal)
    {
        string info = animal.GetInfo();
        if(this.showLog == true) Debug.Log(animal.name + ": " + info);
    }
}
