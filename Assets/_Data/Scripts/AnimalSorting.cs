using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSorting : MonoBehaviour
{
    [SerializeField] protected AnimalManager animalManager;
    [SerializeField] protected List<Animal> sortByWeight = new();

    void Start()
    {
        this.SoftAnimalsByWeight();
    }


    protected void SoftAnimalsByWeight()
    {
        if (this.animalManager.Animals.Count == 0)
        {
            Debug.Log("Recursive: SoftAnimalsByWeight");
            Invoke(nameof(this.SoftAnimalsByWeight), 1);
            return;
        }


        long startTime = UnixTime.GetUnixTimeMicro();

        Debug.Log("==== SoftAnimalsByWeight ====================");
        this.sortByWeight = new(this.animalManager.Animals); //Clone,Copy
        Animal animalX, animalY;
        for (int x = 0; x < this.sortByWeight.Count - 1; x++)
        {
            for (int y = x + 1; y < this.sortByWeight.Count; y++)
            {
                animalX = this.sortByWeight[x];
                animalY = this.sortByWeight[y];

                if (animalX.GetWeight() > animalY.GetWeight())
                {
                    this.SwapAnimal(x, y);
                }
            }
        }

        foreach (Animal animal in this.sortByWeight)
        {
            this.animalManager.MakeAnimalDoSomething(animal);
        }

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("== SoftAnimalsByWeight timeDiff: " + timeDiff);
    }


    protected void SwapAnimal(int x, int y)
    {
        Animal animalZ;
        animalZ = this.sortByWeight[y];
        this.sortByWeight[y] = this.sortByWeight[x];
        this.sortByWeight[x] = animalZ;
    }
}
