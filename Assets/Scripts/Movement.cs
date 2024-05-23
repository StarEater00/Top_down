using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    UnityEngine.Vector2 movement;
    

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
        
    }

    void move_character()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new UnityEngine.Vector2(movement.x*3f  ,movement.y*3f );
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
}
