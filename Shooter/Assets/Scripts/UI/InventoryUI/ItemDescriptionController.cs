using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDescriptionController : MonoBehaviour
{
    public GameObject Container;
    private ItemDescriptionProperty _line;
    private List<ItemDescriptionProperty> lines = new List<ItemDescriptionProperty>();

    void Awake()
    {
        _line = Container.transform.GetChild(0).GetComponent<ItemDescriptionProperty>();
    }

    public void ShowDescription(Item item)
    {
        if (item.Type == ItemTypes.Weapon)
        {
            Firearms info = (Firearms)item.Description;
            if (lines.Count == 0)
            {
                foreach (var element in info.GetAllStats())
                {
                    DrowLine(element.Value.Name, element.Value.Value.ToString());
                }
            }
            else
            {
                var stats = info.GetAllStats();
                for (int i = 0; i < lines.Count; i++)
                {
                    lines[i].Name.SetText(stats[i].Name);
                    lines[i].Value.SetText(stats[i].Value.ToString());
                }
            }

        }
    }
    public void DrowLine(string statName, string value)
    {
        var instance = Instantiate(_line, Vector3.zero, Quaternion.identity);
        lines.Add(instance);
        instance.gameObject.SetActive(true);
        instance.Name.SetText(statName);
        instance.Value.SetText(value);
        instance.transform.SetParent(Container.transform);
    }
}
