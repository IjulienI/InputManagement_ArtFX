using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    private EventSystem _eventSystem;
    [SerializeField] private GameObject firstSetting;

    [SerializeField] private GameObject QuestPanel;
    [SerializeField] private GameObject LetterPanel;
    [SerializeField] private GameObject SettingsPanel;

    private GameObject currentCategory;

    private void Awake()
    {
        _eventSystem = EventSystem.current;
    }

    private void ClearAll()
    {
        for(int i = 0; i < transform.childCount -1; i++)
        {
            if(i != 0) transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (UserInput.instance.returnInput)
        {
            _eventSystem.SetSelectedGameObject(currentCategory);
        }
    }

    public void SelectQuest()
    {
        ClearAll();
        Transform quest = transform.GetChild(1);
        quest.gameObject.SetActive(true);
        currentCategory = QuestPanel;
    }
    public void SelectLetter()
    {
        ClearAll();
        Transform quest = transform.GetChild(2);
        quest.gameObject.SetActive(true);
        currentCategory = LetterPanel;
    }
    public void SelectSettings()
    {
        ClearAll();
        Transform quest = transform.GetChild(3);
        quest.gameObject.SetActive(true);
        _eventSystem.SetSelectedGameObject(firstSetting);
        currentCategory = SettingsPanel;
    }
}