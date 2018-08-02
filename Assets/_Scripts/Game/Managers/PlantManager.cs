using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : ISingleton<PlantManager> 
{
    protected PlantManager(){}

    public ScriptableSeed[] presetPlants;

    private List<Seed> seeds;

    private List<Plant> plants;

    private Field[] fields;


	private void Awake()
	{
        plants = new List<Plant>();
        seeds = new List<Seed>();
	}

	private void Start()
	{
        LoadPreset();
        GetFields();
	}

    private void GetFields()
    {
        fields = GetComponentsInChildren<Field>();
    }

	private void LoadPreset()
    {
        foreach(ScriptableSeed s in presetPlants)
        {
            Seed seed = new Seed(s.type, s.icon, s.range, s.Puts());
            seeds.Add(seed);
        }
    }

    public void PlantSeed(Seed seed, Parcel parcel)
    {
        if(parcel.empty)
        {
            parcel.empty = false;
            Plant plant = SeedToPlant(seed);
            plant.parcel = parcel;
            parcel.plant = plant;
            plants.Add(plant);
        }
        else
        {
            Debug.Log("not empty");
        }
       
    }

    private Plant SeedToPlant(Seed seed)
    {
        return new Plant(seed.type, seed.range, seed.puts);
    }

    public Seed RandomSeed()
    {
        if (seeds.Count != 0)
        {
            return seeds[0];
        }
        else 
        {
            Debug.Log("There is no seed");
            return new Seed(GameData.plantType.Lentils, null, 1, null);
        }
    }

    private void UpdatePants()
	{
        for (int i = plants.Count-1; i >= 0; i--)
        {
            plants[i].GetInputs();
        }
	}

    private void ExecuteOrders()
    {
        foreach(Field field in fields)
        {
            field.ExecuteOrders();
        }
    }

    public void NextTurn()
    {
        UpdatePants();
        ExecuteOrders();
    }

    public Plant GetPlant(HexCoordinates coordinates)
    {
        foreach(Plant p in plants)
        {
            if (p.parcel.coordinates == coordinates) return p;
        }
        return null;
    }

}
