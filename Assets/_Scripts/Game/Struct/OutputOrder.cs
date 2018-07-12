using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OutputOrder 
{
    public HexCoordinates coordinates;
    public int range;
    public KeyValuePair<GameData.Resource, float> order;

    public OutputOrder(KeyValuePair<GameData.Resource, float> _order, HexCoordinates _coordinates, int _range)
    {
        order = _order;
        coordinates = _coordinates;
        range = _range;
    }
}
