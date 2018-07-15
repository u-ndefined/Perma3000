using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : ISingleton<PlantManager> 
{
    protected PlantManager(){}

    public ScriptableSeed[] presetPlants;

    private List<Seed> seeds;

    private List<Plant> plants;


	private void Awake()
	{
        plants = new List<Plant>();
        seeds = new List<Seed>();
	}

	private void Start()
	{
        LoadPreset();
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
        Plant plant = SeedToPlant(seed);
        plant.parcel = parcel;
        plants.Add(plant);
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
}
