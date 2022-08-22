using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int radius;
    public UIManager manager;

    private float noise = 0;
    public float damageRate;
    public float healRate;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        manager.SetNoiseLevel(noise);
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemy();
        Controller();
    }

    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(new Vector3(transform.position.x, transform.position.y, 0),new Vector3(0,0,1), radius); 
    }

    private void CheckEnemy()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius,LayerMask.GetMask("Enemy"));
        if (hit)
        {
            noise = Mathf.Clamp(noise += Time.deltaTime * damageRate,0,100);
            manager.SetNoiseLevel(noise);
        }
        else
        {
            noise = Mathf.Clamp(noise -= Time.deltaTime * healRate,0,100);
            manager.SetNoiseLevel(noise);
        }
    }

    private void Controller()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up*Time.deltaTime*speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left*Time.deltaTime*speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right*Time.deltaTime*speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down*Time.deltaTime*speed;
        }
    }
    
}
