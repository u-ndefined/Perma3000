using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ISingleton<UIManager>
{
    protected UIManager()
    {
    }

    private Dictionary<GameData.Panel, UIPanel> panels;
    public GameObject[] panelObjects;

    private void Awake()
    {
        panels = new Dictionary<GameData.Panel, UIPanel>();

    }

	private void Start()
	{
        SetPanels();
        HideAll();
        Show(GameData.Panel.Actions);
        Debug.Log("okok");
	}

	public void Show(GameData.Panel panel)
    {
        if (panels.ContainsKey(panel))
        {
            Debug.Log("okok");
            panels[panel].Show();
        }
    }

    public void Hide(GameData.Panel panel)
    {
        if (panels.ContainsKey(panel))
        {
            panels[panel].Hide();
        }
    }

    private void SetPanels()
    {
        int i = 0;
        foreach (GameData.Panel p in Enum.GetValues(typeof(GameData.Panel)))
        {
            Debug.Log(p.ToString() + "  " + panelObjects[i].name + "   " + panelObjects[i].GetComponent<UIPanel>().GetType().ToString());
            panels.Add(p, panelObjects[i].GetComponent<UIPanel>());
            i++;

        } 
    }

    public void HideAll()
    {
        foreach(KeyValuePair<GameData.Panel, UIPanel> panel in panels)
        {
            panel.Value.Hide();
        }
    }
}
