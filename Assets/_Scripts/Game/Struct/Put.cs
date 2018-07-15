using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Put 
{
    public Dictionary<GameData.Resource, float> resources;

    public GameData.Tag tag;

    public Put(Dictionary<GameData.Resource, float> _resources , GameData.Tag _tag = GameData.Tag.None)
    {
        resources = _resources;
        tag = _tag;
    }
    
}
