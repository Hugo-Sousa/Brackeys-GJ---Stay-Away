using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketEvent : MonoBehaviour
{
    public GameObject objectToCheck;

    public Transform[] barriers;
    private bool paid;

    private void Update()
    {
        if (!objectToCheck.activeSelf && !paid)
        {
            foreach (var bar in barriers)
            {
                bar.gameObject.SetActive(true);
            }
        }

        if (paid)
        {
            foreach (var bar in barriers)
            {
                bar.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!objectToCheck.activeSelf)
        {
            paid = true;   
        }
        
    }
}
