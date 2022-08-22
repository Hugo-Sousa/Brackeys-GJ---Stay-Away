using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int radius;
    public UIManager manager;

    public Transform socialBubble;
    private Renderer bubbleMat;

    private float noise = 0;
    public float damageRate;
    public float healRate;
    public float speed;
    
    void Start()
    {
        manager.SetNoiseLevel(noise);
        socialBubble.localScale = new Vector3(radius * 2, radius * 2, 1);
        bubbleMat = socialBubble.gameObject.GetComponent<Renderer>();
    }
    
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
        
        bubbleMat.material.SetFloat("_Noise", noise*0.01f);
        SetRippleRate();
    }

    private void SetRippleRate()
    {
        if (noise <= 20)
        {
            bubbleMat.material.SetFloat("_Rate", 0.3f);
        }
        if (noise > 20 && noise <= 70)
        {
            bubbleMat.material.SetFloat("_Rate", 1f);
        }
        if (noise > 70)
        {
            bubbleMat.material.SetFloat("_Rate", 2f);
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
