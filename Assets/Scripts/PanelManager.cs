using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{

    private void ClearAll()
    {
        for(int i = 0; i < transform.childCount -1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void EnablePanel(int index)
    {
        ClearAll();
        Transform quest = transform.GetChild(index);
        quest.gameObject.SetActive(true);
        //Color color = quest.GetComponent<Image>().color;
        //quest.GetComponent<Image>().color = new Color(color.r,color.g,color.b,130);
    }
}
