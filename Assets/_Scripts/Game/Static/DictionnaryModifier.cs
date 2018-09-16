using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DictionnaryModifier 
{
    public static void AddToDictionary(Dictionary<GameData.Resource, float> receiver, Dictionary<GameData.Resource, float> sender)
    {
        foreach (KeyValuePair<GameData.Resource, float> resource in sender)
        {
            if (receiver.ContainsKey(resource.Key))
            {
                receiver[resource.Key] += resource.Value;
            }
            else
            {
                receiver.Add(resource.Key, resource.Value);
            }
        }
    }
}
