using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMinMax : MonoBehaviour
{
    [SerializeField] protected AnimalManager animalManager;
    [SerializeField] protected AnimalSorting animalSorting;
    [SerializeField] protected Animal animalMaxSorting;
    [SerializeField] protected Animal animalMinSorting;

    [SerializeField] protected Animal animalMax;
    [SerializeField] protected Animal animalMin;

    private void Start()
    {
        this.GetMinMaxFromManager();
        this.GetMinMaxFromSorting();
    }

    private void Reset()
    {
        this.LoadComponents();
    }

    protected void LoadComponents()
    {
        this.LoadAnimalManager();
        this.LoadAnimalSorting();
    }

    protected void LoadAnimalSorting()
    {
        this.animalSorting = GetComponent<AnimalSorting>();
    }

    protected void LoadAnimalManager()
    {
        this.animalManager = GetComponent<AnimalManager>();
    }

    protected void GetMinMaxFromSorting()
    {
        if (this.animalSorting.SortByWeight.Count == 0)
        {
            Debug.Log("Recursive: GetMinMaxFromSorting");
            Invoke(nameof(this.GetMinMaxFromSorting), 1);
            return;
        }

        this.GetAnimalMaxFromSorting();
        this.GetAnimalMinFromSorting();
    }

    protected void GetAnimalMaxFromSorting()
    {
        int animalCount = this.animalSorting.SortByWeight.Count;
        this.animalMaxSorting = this.animalSorting.SortByWeight[animalCount - 1];
    }

    protected void GetAnimalMinFromSorting()
    {
        this.animalMinSorting = this.animalSorting.SortByWeight[0];
    }

    protected void GetMinMaxFromManager()
    {
        long startTime = UnixTime.GetUnixTimeMicro();

        if (this.animalManager.Animals.Count == 0)
        {
            Debug.Log("Recursive: GetMinMaxFromManager");
            Invoke(nameof(this.GetMinMaxFromManager), 1);
            return;
        }

        foreach (Animal animal in this.animalManager.Animals)
        {
            this.CheckMaxAnimal(animal);
            this.CheckMinAnimal(animal);
        }

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("== GetMinMaxFromManager timeDiff: " + timeDiff);
    }

    protected void CheckMaxAnimal(Animal animal)
    {
        if (this.animalMax == null)
        {
            this.animalMax = animal;
            return;
        }

        if (this.animalMax.GetWeight() < animal.GetWeight())
        {
            this.animalMax = animal;
        }
    }

    protected void CheckMinAnimal(Animal animal)
    {
        if (this.animalMin == null)
        {
            this.animalMin = animal;
            return;
        }

        if (this.animalMin.GetWeight() > animal.GetWeight())
        {
            this.animalMin = animal;
        }
    }
}
