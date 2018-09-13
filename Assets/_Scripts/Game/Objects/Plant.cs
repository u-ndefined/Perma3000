using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant 
{
    public Parcel parcel;
    public Dictionary<GameData.Resource, float> inputs;
    public Dictionary<GameData.Resource, float> outputs;
    public GameData.plantType type;
    public float HP;

    public Plant(GameData.plantType _type, int _range, Dictionary<GameData.Resource, float> _inputs, Dictionary<GameData.Resource, float> _outputs)
    {
        type = _type;
        inputs = _inputs;
        outputs = _outputs;
    }

    private void CheckInputs()
    {
        foreach(KeyValuePair<GameData.Resource, float> resource in inputs)
        {
            if (!parcel.field.Contains(resource.Key)) HP--;
        }

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