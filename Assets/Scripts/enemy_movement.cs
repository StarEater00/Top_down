using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Tilemaps;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    [SerializeField] private GameObject Head_collider; 
    Collider2D enemy_collider;
    Collider2D player_collider;
    Rigidbody2D enemy_rb;
    

    public bool player_contact; 
    
    
    // Start is called before the first frame update
    void Awake()
    {
        enemy_collider = gameObject.GetComponent<Collider2D>();
        enemy_rb = gameObject.GetComponent<Rigidbody2D>();
        player_collider = Head_collider.gameObject.GetComponent<Collider2D>();
        //print(enemy_collider);
    }


    // Update is called once per frame
    void Update()
    {
        Player_contact();
    }
    void FixedUpdate()
    {
        apply_movement();
    }

    void Player_contact()
    {
        if (enemy_collider.IsTouching(player_collider) && player_contact == false) 
        {
            player_contact = true; 
        }
        else
        {
            player_contact = false;
        }
    }

    void apply_movement()
    {
        if (player_contact)
        {
            if(transform.position.x < player_collider.transform.position.x)
            {
                enemy_rb.AddForce(new UnityEngine.Vector2(-24f,0f),ForceMode2D.Impulse);
            }
            if (transform.position.x > player_collider.transform.position.x)
            {
                enemy_rb.AddForce(new UnityEngine.Vector2(24f,0f),ForceMode2D.Impulse);
            }
        }
    }
}

    