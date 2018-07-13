using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class ResourcesDisplayer : MonoBehaviour 
{

    TextMeshProUGUI text;

	private void Awake()
	{
        text = GetComponentInChildren<TextMeshProUGUI>();
	}


	public void ShowResources(Parcel parcel)
    {
        text.SetText(ResourcesToString(parcel.resources));
        gameObject.SetActive(true);
    }

    public void HideResources()
    {
        gameObject.SetActive(false);
    }

    private string ResourcesToString(Dictionary<GameData.Resource, float> resources)
    {
        StringBuilder sb = new StringBuilder();

        foreach(KeyValuePair<GameData.Resource, float> r in resources)
        {
            sb.Append(r.Key.ToString());
            sb.Append(" ");
            sb.Append(r.Value.ToString());
            sb.AppendLine();
        }

        return sb.ToString();
    }
}
