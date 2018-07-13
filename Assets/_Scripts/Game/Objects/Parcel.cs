using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel : MonoBehaviour
{
    public Field field;
    public Dictionary<GameData.Resource, float> resources;
    public HexCoordinates coordinates;

    public Parcel(HexCoordinates _coordinates, Field _field)
    {
        field = _field;
        coordinates = _coordinates;

        resources = new Dictionary<GameData.Resource, float>();

        AddResource(GameData.Resource.Water, 4.5f);
        AddResource(GameData.Resource.Stuff, 4.5f);



    }

	private void Awake()
	{
        resources = new Dictionary<GameData.Resource, float>();

        AddResource(GameData.Resource.Water, 4.5f);
        AddResource(GameData.Resource.Stuff, 4.5f);

	}

	public void AddResource(GameData.Resource type, float quantity)
    {
        if(resources.ContainsKey(type))
        {
            resources[type] += quantity;
        }
        else
        {
            resources.Add(type, quantity);
        }
    }

    public float GetResource(KeyValuePair<GameData.Resource, float> resource)
    {
        if (resources.ContainsKey(resource.Key))
        {
            float quantity = resources[resource.Key];
            float completion = 0;

            if (quantity >= resource.Value)
            {
                completion = 1;
                quantity -= resource.Value;
            }
            else
            {
                completion = quantity / resource.Value;
                quantity = 0;
            }

            return completion;
        }
        else
        {
            return 0;
        }
    }

    public float GetResources(Put needs)
    {
        float completion = 0;
        foreach (KeyValuePair<GameData.Resource, float> resource in needs.resources)
        {
            completion += GetResource(resource);
        }

        completion /= needs.resources.Count;

        return completion;
    }


    
}
