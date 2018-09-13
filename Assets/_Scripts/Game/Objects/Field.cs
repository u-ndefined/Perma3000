using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field : MonoBehaviour
{

    private Dictionary<HexCoordinates, Parcel> parcels;
    private Dictionary<GameData.Resource, float> resources;
    private Dictionary<GameData.Resource, float> trends;
    private Dictionary<HexCoordinates, Plant> plants;
   
    private void Awake()
    {
        parcels = new Dictionary<HexCoordinates, Parcel>();
        plants = new Dictionary<HexCoordinates, Plant>();
        resources = new Dictionary<GameData.Resource, float>();
        trends = new Dictionary<GameData.Resource, float>();
    }

    Dictionary<GameData.Resource, float> GetTrend()
    {
        trends.Clear();

        foreach(KeyValuePair<HexCoordinates, Plant> plant in plants)
        {
            AddToDictionary(trends, plant.Value.inputs);
            AddToDictionary(trends, plant.Value.outputs);
        }

        return trends;
    }

    private void AddToDictionary(Dictionary<GameData.Resource, float> receiver, Dictionary<GameData.Resource, float> sender)
    {
        foreach(KeyValuePair<GameData.Resource, float> resource in sender)
        {
            if(receiver.ContainsKey(resource.Key))
            {
                receiver[resource.Key] += resource.Value;
            }
            else
            {
                receiver.Add(resource.Key, resource.Value);
            }
        }
    }

    private void ApplyTrend()
    {
        AddToDictionary(resources, trends);
    }


    public void AddParcel(Parcel parcel)
    {
        if (!parcels.ContainsKey(parcel.coordinates))
        {
            parcels.Add(parcel.coordinates, parcel);
        }

    }

    private void ClearResources()
    {
        resources = resources.Where(x => x.Value > 0).ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    public bool Contains(GameData.Resource resource)
    {
        return resources.ContainsKey(resource);
    }

}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Field : MonoBehaviour
//{

//    private Dictionary<HexCoordinates, Parcel> parcels;
//    private List<OutputOrder> orders;

//    private void Awake()
//    {
//        parcels = new Dictionary<HexCoordinates, Parcel>();
//        orders = new List<OutputOrder>();
//    }

//    public void AddOrder(KeyValuePair<GameData.Resource, float> order, HexCoordinates coordinates, int range)
//    {
//        orders.Add(new OutputOrder(order, coordinates, range));
//    }

//    public void ExecuteOrders()
//    {
//        foreach(OutputOrder order in orders)
//        {
//            if(parcels.ContainsKey(order.coordinates))
//            {                
//                parcels[order.coordinates].AddResource(order.order.Key, order.order.Value);
//            }
//            else
//            {
//                Debug.Log("bizare");
//            }

//        }
//        orders.Clear();
//    }

//    public void AddParcel(Parcel parcel)
//    {
//        if(!parcels.ContainsKey(parcel.coordinates))
//        {
//            parcels.Add(parcel.coordinates, parcel);
//        }

//    }

//}
