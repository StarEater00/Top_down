using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using UnityEngine;

public class knock_back : MonoBehaviour
{
    //Movement parent;
    Movement movement ;
    Rigidbody2D player;
    [SerializeField] private GameObject enemy;
    // Start is called before the first frame update
    void Awake(){
        movement = GetComponentInParent<Movement>(); 
        player = GetComponentInParent<Rigidbody2D>();
    
    }
    
    void Start()
    {
        
    }
    // void OnCollisionEnter2D(Collision2D col_data)
    //         {
    //             if (col_data.gameObject.name == "Warrior_Yellow_0")
                
    //             {   
    //                 movement.knock_back = true; 
    //                 //print("collisioin");
    //                 //var rb = gameObject.GetComponent<Rigidbody2D>();
    //                 player.AddForce(new UnityEngine.Vector2(7f,0f),ForceMode2D.Impulse);
    //             }
                
    //         }
    void OnCollisionExit2D(Collision2D enemy_col)
    {
        movement.timer = true;

    }
    
    
    
    
    
    // void OnCollisionEnter2D(Collision2D col_data){
    //     parent.RegisterCollision(this,col_data);
    // }
    // Update is called once per frame
    void Update()
    {
        Collider2D col = gameObject.GetComponent<Collider2D>();
        //print(col);
        Collider2D enemy_col = enemy.GetComponent<Collider2D>();
        Rigidbody2D enemy_rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        if(col.IsTouching(enemy_col)&& movement.knock_back == false)
            {
                if (player.transform.position.x > enemy.transform.position.x)
            {
                player.AddForce(new UnityEngine.Vector2(14f,0f),ForceMode2D.Impulse);
                //enemy_rb.AddForce(new UnityEngine.Vector2(-7f,0f),ForceMode2D.Impulse);
                movement.knock_back = true; 
            }
                if(player.transform.position.x < enemy.transform.position.x)
            {
                player.AddForce(new UnityEngine.Vector2(-7f,0f),ForceMode2D.Impulse);
                movement.knock_back = true;
            }
        // else{
        //         enemy_rb.velocity = new Vector2(0f,0f);
        //     }
                    //print("collisioin");
                    //var rb = gameObject.GetComponent<Rigidbody2D>();
                   
            //print("head touching enemy");
        
        // if (!col.IsTouching(enemy_col)) {
            
            
        //     movement.timer = true;  
            

        //}
        }

    }
    // void OnCollisionEnter2D(Collision2D col_data)
    //         {
    //             if (col_data.gameObject.name == "Warrior_Yellow_0")
                
    //             {   
    //                 knock_back = true; 
    //                 //print("collisioin");
    //                 var rb = gameObject.GetComponent<Rigidbody2D>();
    //                 rb.AddForce(new UnityEngine.Vector2(7f,0f),ForceMode2D.Impulse);
    //             }
                
            
    //         }
    // void OnCollisionExit2D(Collision2D enemy_col)
    // {
    //     timer = true;

    // }
}
