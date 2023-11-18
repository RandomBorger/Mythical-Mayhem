using JetBrains.Annotations;
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
    public double gravity = 0.0;
  
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "LarryRagdoll";
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.gravityScale = 1;
       string ogdirection = direction1;
       if ((Input.GetKeyDown(KeyCode.A)) == true)
       {
            myRigidBody.velocity = Vector2.left * jumpstrenght;
            direction1 = "right";
       } else if ((Input.GetKeyDown(KeyCode.D)) == true)
       {
            direction1 = "left";
            myRigidBody.velocity = Vector2.right * jumpstrenght;
        } else
       {
            facedir = 0;
            Debug.Log("Same Direction");
        }

       if (Input.GetKeyDown(KeyCode.Space) == true) 
       {
            myRigidBody.gravityScale = 2;
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
