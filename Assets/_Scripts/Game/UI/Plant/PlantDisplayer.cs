using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using Tacticsoft;

public class PlantDisplayer : UITable
{

    private List<KeyValuePair<Put,Put>> puts;


    private Dictionary<int, float> m_customRowHeights;


	void Awake()
    {
        puts = new List<KeyValuePair<Put, Put>>();
        m_customRowHeights = new Dictionary<int, float>();
    }

    public override void SetCellContent(UICell cell, int row)
    {
        PlantCell plantCell = cell.GetComponent<PlantCell>();
        if (plantCell != null)
        {
            plantCell.rowNumber = row;
            plantCell.SetContent(puts[row]);
        }
    }



    public override float GetHeightOfRow(int row)
    {
        if (m_customRowHeights.ContainsKey(row))
        {
            return m_customRowHeights[row];
        }
        else
        {
            return (m_cellPrefab.transform as RectTransform).rect.height;
        }
    }

    public override void ReloadData()
    {
        if (SelectionManager.Instance.selected == null || SelectionManager.Instance.selected.empty) return;

        Plant plant = SelectionManager.Instance.selected.plant;

        puts.Clear();
        m_customRowHeights.Clear();
        foreach (KeyValuePair<Put, Put> p in plant.puts)
        {
            m_customRowHeights.Add(puts.Count, 10 + Mathf.Max(p.Key.resources.Count, p.Value.resources.Count) * 15);
            puts.Add(p);

        }
        m_numRows = puts.Count;

        base.ReloadData();
    }
}
