using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    [SerializeField] private enemy_movement enemy_movement; 
    // Collider2D enemy_collider;
    //private bool knock_back;
    private bool in_zone;
    private Vector2 calc_knockback_pos;
    Animator animator;

    
    // Start is called before the first frame update
    void Awake()
    {
        animator = gameObject.GetComponentInParent<Animator>();    

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
             
        if (col.gameObject.name == "Head_Collider")    
            {
                in_zone=true;
            }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Head_Collider")
        {
            in_zone = false;
            //knock_back = false;
            
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

    void animate(string action)
    {
        animator.CrossFade(action,0f,0);   
    
    }
    

    void Follow_player()
    {
        if(in_zone && !enemy_movement.player_contact)
        {   
            
            if (enemy.position.x < player.position.x)
            {
                
                if (player.position.x - enemy.position.x < 6f)
                {

                    enemy.position = Vector2.MoveTowards(enemy.position,player.position,.1f);
                    if (player.position.x -enemy.position.x < 2f)
                        {
                            print("circle_player");
                            circle_player();
                        }

                    
                    if (player.position.x -enemy.position.x >3f)
                        {
                            animate("running");
                            
                        }
                    

                }
                if (player.position.x - enemy.position.x < 3f)
                    {
                        animator.CrossFade("hitting",0f,0);
                    }
            
            }
            if (enemy.position.x > player.position.x)
            {
                
                if (enemy.position.x - player.position.x < 4f )
                {
                    enemy.position = Vector2.MoveTowards(enemy.position,player.position,.1f);
                    animate("running");
                }
            }   
        }

        else
        {
            rb_enemy.velocity = new Vector2(0f,0f);
            animate("idle");
        }
    }
    void circle_player()
    {

        rb_enemy.velocity = new Vector2(UnityEngine.Random.Range(-5f,0f),UnityEngine.Random.Range(-5f,0f));
    }

}
