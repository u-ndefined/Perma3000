using System.Collections;
using System.Collections.Generic;
using Tacticsoft;
using UnityEngine;

public class UITable : UIPanel, ITableViewDataSource
{
    public UICell m_cellPrefab;
    public TableView m_tableView;

    public int m_numRows = 0;
    private int m_numInstancesCreated = 0;

    private void Start()
    {
        m_tableView.dataSource = this;
    }

    public virtual void SetCellContent(UICell cell, int row)
    {
        cell.SetContent();
    }


    public TableViewCell GetCellForRowInTableView(TableView tableView, int row)
    {
        UICell cell = tableView.GetReusableCell(m_cellPrefab.reuseIdentifier) as UICell;
        if (cell == null)
        {
            cell = (UICell)GameObject.Instantiate(m_cellPrefab);
            cell.name = "RessourceCellInstance_" + (++m_numInstancesCreated).ToString();
        }
        SetCellContent(cell, row);
        return cell;
    }

    public float GetHeightForRowInTableView(TableView tableView, int row)
    {
        return GetHeightOfRow(row);
    }

    public int GetNumberOfRowsForTableView(TableView tableView)
    {
        return m_numRows;
    }

    public virtual float GetHeightOfRow(int row)
    {
        return (m_cellPrefab.transform as RectTransform).rect.height;
    }

	public override void Show()
	{
        base.Show();

        ReloadData();

	}

    public override void Hide()
    {
        base.Hide();
    }

    public virtual void ReloadData()
    {
        m_tableView.ReloadData(); 
    }

}
