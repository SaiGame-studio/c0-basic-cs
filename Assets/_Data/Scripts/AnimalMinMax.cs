using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMinMax : MonoBehaviour
{
    [SerializeField] protected AnimalSorting animalSorting;
    [SerializeField] protected Animal animalMax;
    [SerializeField] protected Animal animalMin;

    private void Start()
    {
        this.GetAnimals();
    }

    private void Reset()
    {
        this.LoadComponents();
    }

    protected void LoadComponents()
    {
        this.LoadAnimalManager();
    }

    protected void LoadAnimalManager()
    {
        this.animalSorting = GetComponent<AnimalSorting>();
    }

    protected void GetAnimals()
    {
        if (this.animalSorting.SortByWeight.Count == 0)
        {
            Debug.Log("Recursive: GetAnimals");
            Invoke(nameof(this.GetAnimals), 1);
            return;
        }

        this.GetAnimalMax();
        this.GetAnimalMin();
    }

    protected void GetAnimalMax()
    {
        int animalCount = this.animalSorting.SortByWeight.Count;
        this.animalMax = this.animalSorting.SortByWeight[animalCount - 1];
    }

    protected void GetAnimalMin()
    {
        this.animalMin = this.animalSorting.SortByWeight[0];
    }
}
