using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConEvent : MonoBehaviour
{
    public GameObject objectToCheck;

    public Transform[] barriers;
    
    void Update()
    {
        if (!objectToCheck.activeSelf)
        {
            foreach (var bar in barriers)
            {
                bar.gameObject.SetActive(true);
            }
        }

    }
}
