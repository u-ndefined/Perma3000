using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using Tacticsoft;

public class ResourcesDisplayer : MonoBehaviour , ITableViewDataSource
{
    
    public ResourceCell m_cellPrefab;
    public TableView m_tableView;

    public GameObject displayer;

    private List<KeyValuePair<GameData.Resource, float>> resources;

    public int m_numRows;
    private int m_numInstancesCreated = 0;

	private void Awake()
	{
        resources = new List<KeyValuePair<GameData.Resource, float>>();
	}

	//Register as the TableView's delegate (required) and data source (optional)
	//to receive the calls
	void Start()
    {
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
        return (m_cellPrefab.transform as RectTransform).rect.height;
    }

    //Will be called by the TableView when a cell needs to be created for display
    public TableViewCell GetCellForRowInTableView(TableView tableView, int row)
    {
        ResourceCell cell = tableView.GetReusableCell(m_cellPrefab.reuseIdentifier) as ResourceCell;
        if (cell == null)
        {
            cell = (ResourceCell)GameObject.Instantiate(m_cellPrefab);
            cell.name = "RessourceCellInstance_" + (++m_numInstancesCreated).ToString();
        }
        cell.SetContent(resources[row]);
        return cell;
    }

    #endregion


	public void ShowResources(Parcel parcel)
    {
        displayer.SetActive(true);
        LoadResources(parcel.resources);

        m_tableView.ReloadData();

    }

    public void HideResources()
    {
        displayer.SetActive(false);
    }


    private void LoadResources(Dictionary<GameData.Resource, float> newResources)
    {
        resources.Clear();
        foreach (KeyValuePair<GameData.Resource, float> r in newResources)
        {
            resources.Add(r);
        }
        m_numRows = resources.Count;
    }


}
