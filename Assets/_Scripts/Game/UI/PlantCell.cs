using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tacticsoft;
using TMPro;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlantCell : TableViewCell 
{
    TextMeshProUGUI inputText;
    TextMeshProUGUI outputText;
    public Slider m_cellHeightSlider;

    public int rowNumber
    {
        get; set;
    }

    [System.Serializable]
    public class CellHeightChangedEvent : UnityEvent<int, float>
    {
    }
    public CellHeightChangedEvent onCellHeightChanged;

    public void SliderValueChanged(float value)
    {
        onCellHeightChanged.Invoke(rowNumber, value);
    }

    public float height
    {
        get
        {
            return m_cellHeightSlider.value;
        }
        set
        {
            m_cellHeightSlider.value = value;
        }
    }

    public void SetContent(KeyValuePair<Put,Put> puts)
    {
        inputText.text = PutToString(puts.Key);
        outputText.text = PutToString(puts.Value);
    }

    private string PutToString(Put put)
    {
        StringBuilder sb = new StringBuilder();

        foreach (KeyValuePair<GameData.Resource, float> r in put.resources)
        {
            sb.Append(r.Key.ToString());
            sb.Append(" ");
            sb.Append(r.Value.ToString());
            sb.AppendLine();
        }

        return sb.ToString();
    }
	
}
