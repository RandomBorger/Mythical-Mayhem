using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Timeline;

public class LarryScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpstrenght = 500;
    private float facedir = 0;
    private string direction1 = "Left";
    private float horizantal = 5;
    private float dirtoint = 0;
    private int mjump = 1;
    public int maxjumps = 2;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "LarryRagdoll";
    }

    // Update is called once per frame
    void Update()
    {
        string ogdirection = direction1;
        // Directional Mouvment
        if ((Input.GetKey(KeyCode.A) == true))
        {
            direction1 = "left";

            if (ogdirection != direction1)
            {

                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x / 1.7f, myRigidBody.velocity.y);
            }
            if (!IsGrounded())
            {
                myRigidBody.velocity = new Vector2(math.max(myRigidBody.velocity.x / 1.2f, -10) - horizantal, myRigidBody.velocity.y);
            }
            else
            {
                myRigidBody.velocity = new Vector2(math.max(myRigidBody.velocity.x, -20) - horizantal, myRigidBody.velocity.y);
            }

        } else if ((Input.GetKey(KeyCode.D) == true))
        {
            direction1 = "right";
           
            if (ogdirection != direction1)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x / 1.7f, myRigidBody.velocity.y);
            }
            if (!IsGrounded())
            {
                myRigidBody.velocity = new Vector2(math.min(myRigidBody.velocity.x/ 1.2f, 10) + horizantal, myRigidBody.velocity.y);
            } else
            {
                myRigidBody.velocity = new Vector2(math.min(myRigidBody.velocity.x, 20) + horizantal, myRigidBody.velocity.y);
            }
            
        } else
        {
            facedir = 0;
        }
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && mjump < maxjumps)
       {
            mjump += 1;
            Debug.Log("Jump");
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpstrenght);

       }
       //Resetting
       if (Input.GetKeyDown(KeyCode.R))
       {
            if (ogdirection! != "left")
            {
                dirtoint = 180;
            } else
            {
                dirtoint = 0;
            }
        
            myRigidBody.transform.SetLocalPositionAndRotation( new Vector2(0,0), new Quaternion(
                0, 
                dirtoint, 
                0,
                0
            )) ;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x/10, myRigidBody.velocity.y/10);
       }
       //Turning
       if (ogdirection !!= direction1)
       {
            facedir = 180; 
       }
       if (IsGrounded())
       {
            mjump = 0;
       }

       
       myRigidBody.transform.Rotate(0, facedir, 0);
       facedir = 0;
    }
    private void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x * 0.95f, myRigidBody.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }

}
