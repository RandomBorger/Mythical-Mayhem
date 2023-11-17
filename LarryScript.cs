using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Timeline;

public class LarryScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpstrenght = 10;
    public float facedir = 0;
    public string direction1 = "Left";
  
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "LarryRagdoll";
    }

    // Update is called once per frame
    void Update()
    {
       string ogdirection = direction1;
       if ((Input.GetKeyDown(KeyCode.A)) == true)
       {
            direction1 = "right";
       } else if ((Input.GetKeyDown(KeyCode.D)) == true)
       {
            direction1 = "left";
       } else
       {
            facedir = 0;
            Debug.Log("Same Direction");
        }

       if (Input.GetKeyDown(KeyCode.Space) == true) 
       {
            Debug.Log("Jump");
            myRigidBody.velocity = Vector2.up * jumpstrenght;
       } 
       if (Input.GetKeyUp(KeyCode.E) == true)
       {
            Debug.Log("KeyBoard Detected");
       }
       if (ogdirection !!= direction1)
       {
            facedir = 180; 
       } 
        myRigidBody.transform.Rotate(0, facedir, 0);
        facedir = 0;
    }
}
