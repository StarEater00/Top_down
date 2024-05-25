using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Cam_movement : MonoBehaviour
{
    [SerializeField] Transform player_trans;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void FixedUpdate()
    {
         var Cam = gameObject.GetComponent<Camera>();
        Cam.transform.position = new UnityEngine.Vector3(player_trans.position.x,player_trans.position.y,-1f);

    }

    // Update is called once per frame
    void Update()
    {


    }
}
