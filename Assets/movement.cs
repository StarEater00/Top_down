using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Tilemaps;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private Transform player; 
    

    public bool knock_back; 
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

         
    }

    void OnCollisionEnter2D(Collision2D enemy_col)
    {
        UnityEngine.Vector2 enemy_knockback = new UnityEngine.Vector2(transform.position.x +20,transform.position.y); 
        var rb = gameObject.GetComponent<Rigidbody2D>();
         if(enemy_col.gameObject.name == "Player")
         {
            knock_back= true;
            
            if(transform.position.x > player.position.x)
                {    
                
                rb.AddForce(enemy_knockback,ForceMode2D.Impulse);
                }
            else{
                rb.AddForce(-enemy_knockback,ForceMode2D.Impulse);
                
            }
         }
         else
         {
            knock_back = false;
         }
    }
}

    