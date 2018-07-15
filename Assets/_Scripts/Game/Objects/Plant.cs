using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant 
{
    public Parcel parcel;
    public Dictionary<Put, Put> puts;
    public int range;
    public GameData.plantType type;

    public Plant(GameData.plantType _type, int _range, Dictionary<Put, Put> _puts)
    {
        type = _type;
        range = _range;
        puts = _puts;
    }


    public void GetInputs()
    {
        foreach(KeyValuePair<Put, Put> put in puts)
        {
            float completion = parcel.GetResources(put.Key);

            TagEffect(put.Key.tag, completion);

            AddOrders(put.Value, completion);
        }
    }

    private void AddOrders(Put put, float completion)
    {
        foreach(KeyValuePair<GameData.Resource, float> resource in put.resources)
        {
            KeyValuePair<GameData.Resource, float> order = new KeyValuePair<GameData.Resource, float>(resource.Key, resource.Value * completion);

            parcel.field.AddOrder(order, parcel.coordinates, range);
        }
    }


    public virtual void TagEffect(GameData.Tag tag, float completion)
    {
        
    }
}
