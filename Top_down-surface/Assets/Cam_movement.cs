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

    void LateUpdate()
    {
         var Tile_pos = gameObject.GetComponent<Transform>();
        Tile_pos.transform.position = new UnityEngine.Vector3(player_trans.position.x *.5f,player_trans.position.y,-1f *.5f);

    }

    // Update is called once per frame
    void Update()
    {


    }
}
