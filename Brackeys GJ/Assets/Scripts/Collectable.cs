using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject objectToCollect;
    public String objectType;
    private UIManager manager;
    
    private bool playerIn;

    private void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<UIManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && playerIn)
        {
            objectToCollect.SetActive(false);
            manager.SetCheckmark(objectType);
            playerIn = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerIn = true;
        }
    }
}
