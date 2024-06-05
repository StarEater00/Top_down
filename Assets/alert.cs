using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class alert : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb_enemy;
    [SerializeField] private Transform enemy; 
    [SerializeField] private Transform player; 
    [SerializeField] private movement Movement; 
    private bool in_zone;
    private Vector2 calc_knockback_pos;
    
    // Start is called before the first frame update
    void Start()
    {
    

        
    }

    // Update is called once per frame
    void Update()
    {
        
        No_Flip();
        Flip();
        Follow_player();
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
             
        if (col.gameObject.name == "Player")    
            {
                in_zone=true;
            
            }


    }

    void OnCollisionEnter2D(Collision2D col_enemy)
    {
        print("enemy_col");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            in_zone = false;
            
        }

    }
    
    void No_Flip()
    {
        if (enemy.transform.position.x < player.transform.position.x  && in_zone)
        {
            enemy.localScale = new UnityEngine.Vector3(1,enemy.localScale.y,0);
        }
    }

    void Flip()
    {
        if(enemy.transform.position.x > player.transform.position.x && in_zone)
        {
            enemy.localScale = new UnityEngine.Vector3(-1,enemy.localScale.y,0);
        }
    }

    void repel_player()
    {
        var calc_knockback_pos = (enemy.position.x+20,enemy.position.y+30);


        
    }
    void Follow_player()
    {
        if(in_zone && !Movement.knock_back )
        {
            if (enemy.position.x < player.position.x)
            {
                //print(player.position.x - enemy.position.x);
                if (player.position.x - enemy.position.x < 2f )
                {
                    enemy.position = Vector2.MoveTowards(enemy.position,player.position,.1f);
                    
                }
            
            }
            if (enemy.position.x > player.position.x)
            {
                //print(player.position.x - enemy.position.x);
                if (enemy.position.x - player.position.x < 2f )
                {
                    enemy.position = Vector2.MoveTowards(enemy.position,player.position,.1f);
                }
            }   
        }

        else
        {
            rb_enemy.velocity = new Vector2(0f,0f);
        }
    }

}
