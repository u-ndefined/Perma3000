using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tacticsoft;
using TMPro;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlantCell : UICell 
{
    public TextMeshProUGUI inputText;
    public TextMeshProUGUI outputText;
    public float height;

    public int rowNumber
    {
        get; set;
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
