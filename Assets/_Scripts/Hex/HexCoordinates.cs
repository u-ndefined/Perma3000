using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
    public int x, y, z;

    public HexCoordinates(int _x, int _z)
    {
        x = _x;
        z = _z;
        y = -x -z;
    }

    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    }

    public static Vector2 CoordinatesToGrid(int x, int z)
    {
        return new Vector2(x + Mathf.CeilToInt(z / 2), z);
    }



    public override string ToString()
    {
        return "(" + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ")";
    }

    public string ToStringOnSeparateLines()
    {
        return x.ToString() + "\n" + y.ToString() + "\n" + z.ToString();
    }

    public static bool operator ==(HexCoordinates a, HexCoordinates b)
    {
        // an item is always equal to itself
        if (object.ReferenceEquals(a, b))
            return true;

        // if both a and b were null, we would have already escaped so check if either is null
        if (object.ReferenceEquals(a, null))
            return false;
        if (object.ReferenceEquals(b, null))
            return false;
        // Now that we've made sure we are working with real objects:
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(HexCoordinates a, HexCoordinates b)
    {
        return !(a == b);
    }
}
