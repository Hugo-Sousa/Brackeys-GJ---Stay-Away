using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private GameSceneManager manager;
    private UIManager managerUI;
    public bool enter;
    public int place;

    private bool playerIn;

    private void Start()
    {
        GameObject canvas = GameObject.Find("Manager");
        manager = canvas.GetComponent<GameSceneManager>();
        managerUI = canvas.GetComponent<UIManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && playerIn)
        {
            if (managerUI.warning)
            {
                SceneManager.LoadScene("VictoryScreen");
            }
            else
            {
                manager.Spawn(enter,place);
                playerIn = false;   
            }
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
