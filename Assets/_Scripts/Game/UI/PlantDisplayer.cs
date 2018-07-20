using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using Tacticsoft;

public class PlantDisplayer : MonoBehaviour, ITableViewDataSource
{

    private List<KeyValuePair<Put,Put>> puts;

    public PlantCell m_cellPrefab;
    public TableView m_tableView;

    public GameObject displayer;

    public int m_numRows;
    private int m_numInstancesCreated = 0;

    private Dictionary<int, float> m_customRowHeights;

    //Register as the TableView's delegate (required) and data source (optional)
    //to receive the calls
    void Start()
    {
        puts = new List<KeyValuePair<Put, Put>>();
        m_customRowHeights = new Dictionary<int, float>();
        m_tableView.dataSource = this;
    }

    #region ITableViewDataSource

    //Will be called by the TableView to know how many rows are in this table
    public int GetNumberOfRowsForTableView(TableView tableView)
    {
        return m_numRows;
    }

    //Will be called by the TableView to know what is the height of each row
    public float GetHeightForRowInTableView(TableView tableView, int row)
    {
        return GetHeightOfRow(row);
    }

    //Will be called by the TableView when a cell needs to be created for display
    public TableViewCell GetCellForRowInTableView(TableView tableView, int row)
    {
        PlantCell cell = tableView.GetReusableCell(m_cellPrefab.reuseIdentifier) as PlantCell;
        if (cell == null)
        {
            cell = (PlantCell)GameObject.Instantiate(m_cellPrefab);
            cell.name = "PlantCellInstance_" + (++m_numInstancesCreated).ToString();
            //cell.onCellHeightChanged.AddListener(OnCellHeightChanged);
        }
        cell.rowNumber = row;
        cell.SetContent(puts[row]);
        return cell;
    }

    #endregion

    private float GetHeightOfRow(int row)
    {
        if (m_customRowHeights.ContainsKey(row))
        {
            return m_customRowHeights[row];
        }
        else
        {
            return m_cellPrefab.height;
        }
    }





    public void ShowPlant(Plant plant)
    {
        displayer.SetActive(true);
        LoadPlant(plant.puts);

        m_tableView.ReloadData();

    }

    public void HidePlant()
    {
        displayer.SetActive(false);
    }

    private void LoadPlant(Dictionary<Put,Put> newPuts)
    {
        puts.Clear();
        m_customRowHeights.Clear();
        foreach (KeyValuePair<Put, Put> p in newPuts)
        {
            m_customRowHeights.Add(puts.Count, 10 + Mathf.Max(p.Key.resources.Count, p.Value.resources.Count) * 15);
            puts.Add(p);
           
        }
        m_numRows = puts.Count;
    }

}
