using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EditorInputOutput
{
    public GameData.Tag tag;
    public EditorResource[] inputs;
    public EditorResource[] outputs;

    public Put Input()
    {
        return new Put(ArrayToDictionary(inputs), tag);
    }
    public Put Output()
    {
        return new Put(ArrayToDictionary(outputs), tag);
    }

    private Dictionary<GameData.Resource, float> ArrayToDictionary(EditorResource[] resources)
    {
        Dictionary<GameData.Resource, float> result = new Dictionary<GameData.Resource, float>();
        foreach (EditorResource r in resources)
        {
            result.Add(r.type, r.quantity);
        }
        return result;
    }
}

[System.Serializable]
public struct EditorResource
{
    public GameData.Resource type;
    public float quantity;
}