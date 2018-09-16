using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant 
{
    public Parcel parcel;
    public PlantBase plantBase;


    public Dictionary<GameData.Resource, float> inputs;
    public Dictionary<GameData.Resource, float> outputs;
    public GameData.plantType type;
    public float HP;

    private int growthStep;

    public Plant(PlantBase _plantBase)
    {
        plantBase = _plantBase;
        type = plantBase.type;
        inputs = plantBase.ArrayToDictionary(plantBase.editorInputs);
        outputs = plantBase.ArrayToDictionary(plantBase.editorOutputs);
        HP = plantBase.HP;
    }

    private void CheckInputs()
    {
        foreach(KeyValuePair<GameData.Resource, float> resource in inputs)
        {
            if (!parcel.field.Contains(resource.Key)) HP--;
        }

    }

    private void Grow()
    {
        if(plantBase.harvestable && growthStep < plantBase.harvestTime)
        {
            growthStep++;
        }

        plantBase.Grow();
    }

    private void Harvest()
    {
        growthStep = 0;
        plantBase.Harvest();
    }

    public Dictionary<GameData.Resource, float> GetInputs()
    {
        return plantBase.GetInputs();
    }

    public Dictionary<GameData.Resource, float> GetOutputs()
    {
        return plantBase.GetOutputs();
    }


}


//public void GetInputs()
//{

//    foreach (KeyValuePair<Put, Put> put in puts)
//    {
//        float completion = parcel.GetResources(put.Key);

//        TagEffect(put.Key.tag, completion);

//        AddOrders(put.Value, completion);
//    }
//}

//private void AddOrders(Put put, float completion)
//{
//    foreach (KeyValuePair<GameData.Resource, float> resource in put.resources)
//    {
//        KeyValuePair<GameData.Resource, float> order = new KeyValuePair<GameData.Resource, float>(resource.Key, resource.Value * completion);

//        parcel.field.AddOrder(order, parcel.coordinates, range);
//    }
//}


//public virtual void TagEffect(GameData.Tag tag, float completion)
//{

//}