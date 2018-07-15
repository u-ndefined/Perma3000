using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parcel : MonoBehaviour
{
    public Field field;
    public Dictionary<GameData.Resource, float> resources;
    public HexCoordinates coordinates;

	private void Awake()
	{
        resources = new Dictionary<GameData.Resource, float>();

        AddResource(GameData.Resource.Water, (float)Math.Round(UnityEngine.Random.Range(0, 5.0f), 2));
        AddResource(GameData.Resource.Stuff, (float)Math.Round(UnityEngine.Random.Range(0,5.0f), 2));

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
