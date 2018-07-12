﻿using UnityEditor;
using UnityEngine;

public class HexCreator : EditorWindow
{
    private int width = 1;
    private int height = 1;
    //private Object hexCell;
    private float scale = 1.0f;
    //private HexMetrics hexMetrics;

    //private Vector3 cellPos;
    //private Vector3 rawPos;

    [MenuItem("GameObject/HexGrid", false, 0)]
    static void CreateGrid()
    {
        //create window
        HexCreator window = ScriptableObject.CreateInstance<HexCreator>();
        window.position = new Rect(200, 250 , 250, 150);
        window.ShowPopup();
    }

    protected void OnEnable()
    {
        width = EditorPrefs.GetInt("Width", width);
        height = EditorPrefs.GetInt("Height", height);
        scale = EditorPrefs.GetFloat("HexScale", scale);
    }

    protected void OnDisable()
    {
        EditorPrefs.SetFloat("HexScale", scale);
        EditorPrefs.SetInt("Width", width);
        EditorPrefs.SetInt("Height", height);
    }

	private void OnGUI()
	{

        //Get infos in the box
        width = EditorGUILayout.IntField("Width", width);
        height = EditorGUILayout.IntField("Height", height);
        //type = (HexType) EditorGUILayout.EnumPopup("Type", type);
        scale = EditorGUILayout.Slider(scale, 0.1f, 10.0f);


        if(GUILayout.Button("Create (enter)") || Event.current.keyCode == KeyCode.Return) //when create button is pressed
        {

            ParcelCreator.CreateGrid(width);

            //hexCell = AssetDatabase.LoadAssetAtPath("Assets/_Prefabs/Hex/HexCell.prefab", typeof(GameObject));  //get the prefab in the hierarchy
            /*
            GameObject hexGrid = new GameObject("HexGrid"); //create the grid parent

            HexGrid grid = hexGrid.AddComponent<HexGrid>(); // add hexGrid script + intialize it
            grid.width = width;
            grid.height = height;


            for (int y = 0; y < width; y++)
            {
                GameObject hexRaw = new GameObject("HexRaw: " + y);     //create the raw parent
                hexRaw.transform.parent = hexGrid.transform;

                for (int x = 0; x < height; x++)
                {
                    GameObject cell = (UnityEngine.GameObject) PrefabUtility.InstantiatePrefab(hexCell);    //create the cell
                    cell.name = "HexCell: " + x;
                    cell.transform.parent = hexRaw.transform;

                    Vector3 cellPos = new Vector3((x + y * 0.5f - y / 2) * (HexMetrics.innerRadius * 2f) ,0,0); //Set cell pos
                    cell.transform.position = cellPos;

                    HexCell hexCellScript = cell.GetComponent<HexCell>();

                    hexCellScript.type = type;
                    hexCellScript.coordinates = HexCoordinates.FromOffsetCoordinates(x, y);
                    hexCellScript.hexGrid = grid;
                } 


                Vector3 rawPos = new Vector3(0, 0, y * (HexMetrics.outerRadius * 1.5f));        //Set raw pos
                hexRaw.transform.position = rawPos;
            }


            hexGrid.transform.localScale = new Vector3(scale, scale, scale);
            */



            Close();
        }

        if (GUILayout.Button("Close (esc)") || Event.current.keyCode == KeyCode.Escape) //when create button is pressed
        {
            Close();
        }

	}
}