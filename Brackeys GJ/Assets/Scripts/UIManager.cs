using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private Dictionary<String, bool> checklist;
    public bool warning;
    public GameObject warningLabel;

    private void Start()
    {
        checklist = new Dictionary<string, bool>();
        checklist.Add("C",false);
        checklist.Add("N",false);
        checklist.Add("BP",false);
    }

    public void SetNoiseLevel(float level)
    {
        //GetComponentInChildren<TextMeshProUGUI>().text = "Noise Lvl: " + (int)level + "%";
    }

    public void SetCheckmark(String type)
    {
        GameObject.Find(type + "-Checkmark").GetComponent<Image>().enabled = true;
        checklist[type] = true;
    }

    private void ShowWarning()
    {
        warningLabel.SetActive(true);
    }

    private void Update()
    {
        if (checklist.Values.Distinct().Count() == 1 && checklist["C"] && !warning)
        {
            ShowWarning();
            warning = true;
        }
    }
}
