using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelCreator
{
    public GameObject hexObject;

    public static void CreateGrid(int radius)
    {
        GameObject fieldObject = new GameObject("Field");

        Field field = fieldObject.AddComponent<Field>();

        HexCoordinates[] hexInRange = HexInRange(new HexCoordinates(0,0), radius);

        foreach(HexCoordinates coordinates in hexInRange)
        {
            Transform parcelPos = CreateHex(coordinates, field);
            parcelPos.parent = fieldObject.transform;
        }


    }

    public static Transform CreateHex(HexCoordinates coordinates, Field field)
    {
        GameObject parcelObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        parcelObject.name = "Parcel " + coordinates.x + " " + coordinates.z;
        Parcel parcel = parcelObject.AddComponent<Parcel>();
        parcelObject.AddComponent<InputParcel>();
        parcel.coordinates = coordinates;
        parcel.field = field;
        parcelObject.transform.position = CoordinatesToPosition(coordinates);
        return parcelObject.transform;
    }

    public static Vector3 CoordinatesToPosition(HexCoordinates c)
    {
        return new Vector3((c.x + c.z * 0.5f) * (HexMetrics.innerRadius * 2f), 0, c.z * (HexMetrics.outerRadius * 1.5f));
    }




    public static HexCoordinates[] HexInRange(HexCoordinates center, int range)
    {
        HexCoordinates[] result = new HexCoordinates[TriangularNumber(range-1)*6 + range*6 + 1];
        int i = 0;
        for (int x = -range; x <= range; x++)
        {
            for (int y = Mathf.Max(-range, -x-range); y <= Mathf.Min(range, -x+range); y++)
            {
                int z = -x - y;
                result[i] = new HexCoordinates(x + center.x, z + center.z);
                i++;
            }
        }

        return result;
    }

    public static int TriangularNumber(int n)
    {
        if (n <= 0) return 0;
        else return (n * (n + 1)) / 2;
    }
}
