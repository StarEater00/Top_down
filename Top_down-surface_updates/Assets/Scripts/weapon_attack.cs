using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_attack : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        //move_torch();
    }

    // Update is called once per frame
    void Update()
    {
       move_torch();
    }


    void move_torch()
    {
        if(Input.GetKeyDown("x")) 
        {
            print("key");
           transform.Rotate(0,0,90);
        }
    }

}
