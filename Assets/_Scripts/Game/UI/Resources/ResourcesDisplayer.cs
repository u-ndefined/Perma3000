using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesDisplayer : UITable 
{

    private List<KeyValuePair<GameData.Resource, float>> resources;

	private void Awake()
	{
        resources = new List<KeyValuePair<GameData.Resource, float>>();
	}

    public override void SetCellContent(UICell cell, int row)
	{
        ResourceCell resourceCell = cell.GetComponent<ResourceCell>();
        if (resourceCell != null) resourceCell.SetContent(resources[row]);
	}

	public override void ReloadData()
	{
        if (SelectionManager.Instance.selected == null) return;

        Parcel parcel = SelectionManager.Instance.selected;

        resources.Clear();

        //foreach (KeyValuePair<GameData.Resource, float> r in parcel.resources)
        //{
        //    resources.Add(r);
        //}
        m_numRows = resources.Count;
        
        base.ReloadData();
	}
}
