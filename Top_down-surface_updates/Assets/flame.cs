using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class flame : MonoBehaviour
{
    private Collider2D fire; 
    [SerializeField] private Collider2D soldier;
    private int fire_count=0;
    // Start is called before the first frame update
    void Awake()
    {
        fire = gameObject.GetComponent<PolygonCollider2D>();
        //var sold_collider = soldier.GetComponent<PolygonCollider2D>(); 
        
    }
    
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // print(fire_count);
        // if (fire_count < 1)
        //     {
        //         if(fire.IsTouching(soldier))
        //             {
        //                 Instantiate(gameObject,gameObject.transform);
        //                 fire_count = 1; 
        //                 print("on fire");
        //             }
        //     }
    }
    
    void OnTriggerEnter2D(Collider2D col)

    {
         if (col.gameObject.name == "Warrior_Yellow_0")
         {
            fire_count += 1;
            print(fire_count);
            //print("entered");
         }
    }
    

}
