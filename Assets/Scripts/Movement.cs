using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Collections;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    UnityEngine.Vector2 movement;
    private bool knock_back; 
    private bool left_contact;
    [SerializeField] private float targetTime; 
    private bool timer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {

        move_character();
        
    }
    // Update is called once per frame
    void Update()
    {
        move();
        animate();
        print(targetTime);
        if (timer)
        {
            start_timer();
        }
        
        
    }

    void move_character()
    {
        if (!knock_back)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new UnityEngine.Vector2(movement.x*3f  ,movement.y*3f );
        }
    }
    void move()
    {
            float x_move = Input.GetAxisRaw("Horizontal");
            float y_move = Input.GetAxisRaw("Vertical");
            movement = new UnityEngine.Vector2(x_move,y_move).normalized;
    }
    void animate()
    {
        var animate = GetComponent<Animator>();
        //var player_idle = true;
        
        
        
        //up_left_right_down Movements

        if (movement.y == -1)
        {
            animate.CrossFade("walk",0f,0);
        }
        if (movement.x == 1)
        {
            animate.CrossFade("right",0f,0);
        }
        if (movement.x == -1)
        {
            animate.CrossFade("left",0f,0);
        }
        if(movement.y == 1)
        {
            animate.CrossFade("up",0f,0);
        }
        
        //Movements diagonally
        
        if(movement.x < 0 && movement.x > -1 && movement.y > 0 && movement.y <1)
        {
            animate.CrossFade("diagonal_l_up",0f,0);
        }
        if(movement.x > 0 && movement.x < 1 && movement.y > 0 && movement.y <1)
        {
            animate.CrossFade("diagonal_r_up",0f,0);
        }
        if(movement.x < 0 && movement.x > -1 && movement.y < 0 && movement.y > -1)
        {
            animate.CrossFade("diagonal_l_down",0f,0);
        }
        if(movement.x > 0 && movement.x < 1 && movement.y < 0 && movement.y > -1)
        {
            animate.CrossFade("diagonal_r_down",0f,0);
        }
        var current_animation = animate.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        //Idle_animations
        if (movement.x == 0 && movement.y == 0)
            {
                if (current_animation == "left")
                {
                    animate.CrossFade("left_idle",0f,0);
                }
                if (current_animation == "right")
                {
                    animate.CrossFade("right_idle",0f,0);
                }
                if (current_animation == "walk")
                {
                    animate.CrossFade("walk_idle",0f,0);
                }
                if (current_animation == "up")
                {  
                    animate.CrossFade("up_idle",0f,0);
                }
            
        
               // diagonal_Idle
                if (current_animation == "diagonal_l_down")
                {
                    animate.CrossFade("diagonal_l_down_idle",0f,0);
                }
                 if (current_animation == "diagonal_r_down")
                {
                    animate.CrossFade("diagonal_r_down_idle",0f,0);
                }
                if (current_animation == "diagonal_l_up")
                {
                    animate.CrossFade("diagonal_l_up_idle",0f,0);
                }
                 if (current_animation == "diagonal_r_up")
                {
                    animate.CrossFade("diagonal_r_up_idle",0f,0);
                }
            }
        
        
    }
    void OnCollisionEnter2D(Collision2D enemy_col)
            {
                if (enemy_col.gameObject.name == "Warrior_Yellow_0")
                {   
                    knock_back = true; 
                    print("collisioin");
                    var rb = gameObject.GetComponent<Rigidbody2D>();
                    rb.AddForce(new UnityEngine.Vector2(7f,0f),ForceMode2D.Impulse);
                }
                
            
            }
    void OnCollisionExit2D(Collision2D enemy_col)
    {
        timer = true;

    }

    void start_timer()
    {
        targetTime -= Time.deltaTime;
            if (targetTime <= 0)
                {
                    knock_back = false;
                    targetTime = .8f;
                    timer = false;
            }
    }

}
