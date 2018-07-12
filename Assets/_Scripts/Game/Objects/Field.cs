using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field 
{

    private Dictionary<HexCoordinates, Parcel> parcels;
    private List<OutputOrder> orders;

    public Field()
    {
        parcels = new Dictionary<HexCoordinates, Parcel>();
        orders = new List<OutputOrder>();
    }

    public void AddOrder(KeyValuePair<GameData.Resource, float> order, HexCoordinates coordinates, int range)
    {
        orders.Add(new OutputOrder(order, coordinates, range));
    }

    public void ExecuteOrders()
    {
        foreach(OutputOrder order in orders)
        {
            //do order
        }
    }

    public void AddParcel(Parcel parcel)
    {
        if(!parcels.ContainsKey(parcel.coordinates))
        {
            parcels.Add(parcel.coordinates, parcel);
        }

    }
    
}
