using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    private Dictionary<HexCoordinates, Parcel> parcels;
    private List<OutputOrder> orders;

    private void Awake()
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
        Debug.Log(parcels.Count);
        foreach(OutputOrder order in orders)
        {
            if(parcels.ContainsKey(order.coordinates))
            {
                Debug.Log("erzrzerz");
                parcels[order.coordinates].AddResource(order.order.Key, order.order.Value);
            }
            else
            {
                Debug.Log("bizare");
            }

        }
        orders.Clear();
    }

    public void AddParcel(Parcel parcel)
    {
        if(!parcels.ContainsKey(parcel.coordinates))
        {
            parcels.Add(parcel.coordinates, parcel);
        }

    }

}
