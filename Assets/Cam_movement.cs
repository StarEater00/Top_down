using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        var x_move = Input.GetAxisRaw("Horizontal")*.02f;
        var y_move = Input.GetAxisRaw("Vertical")*.02f;
        var Cam = gameObject.GetComponent<Camera>();
        Cam.transform.position = new UnityEngine.Vector3(Cam.transform.position.x +x_move, Cam.transform.position.y + y_move,-.5f);

    }

    // Update is called once per frame
    void Update()
    {


    }
}
