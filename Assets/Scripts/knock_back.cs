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
    [SerializeField] private GameObject sword;
    // Start is called before the first frame update
     Collider2D col;
     Collider2D enemy_col;
     Rigidbody2D enemy_rb;
     Collider2D sword_coll;

    void Awake(){
        movement = GetComponentInParent<Movement>(); 
        player = GetComponentInParent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        //print(col);
        enemy_col = enemy.GetComponent<Collider2D>();
        enemy_rb = enemy.gameObject.GetComponent<Rigidbody2D>();
        sword_coll = sword.gameObject.GetComponent<Collider2D>();
    
    }
    
    void Start()
    {
        
    }
   
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
        
        if(col.IsTouching(enemy_col) && movement.knock_back == false)
            {
               // print("touching player");
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
            }
       
            
            // if(sword_coll != null)= 
            // {
        if (sword_coll.isActiveAndEnabled)

        {   print("isEnabled");
            if(col.IsTouching(sword_coll) && movement.knock_back ==false)
                {
                   
                    player.AddForce(new UnityEngine.Vector2(14f,0f),ForceMode2D.Impulse);
                    movement.knock_back=true;
                    
                
                }
         }   
    }
}
