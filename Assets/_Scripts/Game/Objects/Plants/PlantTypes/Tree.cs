using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : PlantBase 
{
    public EditorResource[] inputModifier;
    public EditorResource[] outputModifier;

    public override Dictionary<GameData.Resource, float> GetInputs()
	{
        Dictionary<GameData.Resource, float> result = new Dictionary<GameData.Resource, float>();
        DictionnaryModifier.AddToDictionary(result, base.GetInputs());

        //modifier

        return result;
	}

}
