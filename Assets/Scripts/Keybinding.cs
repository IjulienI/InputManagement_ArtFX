using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybinding : MonoBehaviour
{
    private void ClearAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i != 0) transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void EnablePanel(int index)
    {
        ClearAll();
        Transform quest = transform.GetChild(index);
        quest.gameObject.SetActive(true);
    }
}
