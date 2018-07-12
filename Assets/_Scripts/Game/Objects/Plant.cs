using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant 
{
    private Parcel parcel;
    private Dictionary<Put, Put> puts;
    private int range;

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
