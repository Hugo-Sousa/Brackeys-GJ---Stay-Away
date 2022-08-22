using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void SetNoiseLevel(float level)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = "Noise Lvl: " + (int)level + "%";
    }
}
