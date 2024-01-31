using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Unity.Burst.Intrinsics.X86.Avx;

public class CampaignLarry : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpstrenght = 20; //jump strenght
    private string direction1 = "Right"; //what dircetion you are facing
    public float horizantal = 0.5f; //horizontal speed
    private float dirtoint = 0; //for turning
    private int mjump = 1; //jumps taken
    public int maxjumps = 2; //maximum jumps
    public float dmg; //tamage taken
    private float facedir = 0; //turning 
    public float atk = 0.04f;
    private float startx;
    private float starty;
    private float percent;
    public float mHP = 1;
    private float chp = 1;
    private float alldmg = 0;
    private bool regen = false;
    private Transform cam; 
    [SerializeField] private Transform hpbar; //your hp bar
    [SerializeField] private Transform groundCheck; //your feet
    [SerializeField] private LayerMask groundLayer; //what is the ground

    // Start is called before the first frame update
    void Start()
    {
        percent = hpbar.transform.localScale.y/100;
        startx = myRigidBody.transform.localPosition.x;
        starty = myRigidBody.transform.localPosition.y;
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

            myRigidBody.velocity = new Vector2(math.max(myRigidBody.velocity.x, -0.4f) - horizantal, myRigidBody.velocity.y);


        }
        else if ((Input.GetKey(KeyCode.D) == true))
        {
            direction1 = "right";
            

            if (ogdirection != direction1)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x / 1.7f, myRigidBody.velocity.y);
            }
            myRigidBody.velocity = new Vector2(math.min(myRigidBody.velocity.x, 0.5f) + horizantal, myRigidBody.velocity.y);

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
            }
            else
            {
                dirtoint = 0;
            }

            myRigidBody.transform.position = new Vector2(startx, starty);
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x / 10, myRigidBody.velocity.y / 10);
        }
        //Turning & resetting multi jumps
        if (ogdirection! != direction1)
        {
            facedir = 180;
        }
        if (IsGrounded())
        {
            mjump = 0;
        }
        //self harm
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            dmg = atk;
        }
        //Attack 
        //if (Input.GetKeyDown(KeyCode.Mouse2)
        //{
        //    Instantiate()
        //}

        FixedUpdate();
    }

    private void FixedUpdate()
    {
        myRigidBody.transform.SetLocalPositionAndRotation(new Vector2(0, 0), new Quaternion(0, 0, 0, dirtoint - 90));
        if (hpbar.localScale.x <= 0)
        {
            myRigidBody.transform.Rotate(0, facedir, 0);
            dmg = 0;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x / 10, myRigidBody.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space) || myRigidBody.velocity.y < 0)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x * 0.99f, myRigidBody.velocity.y);
        }
        else
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x * 0.99f, myRigidBody.velocity.y * 0.95f);
        }

        Health();

    }
    private void Health()
    {
        alldmg += dmg;
        chp -= alldmg;
        dmg = 0;
        //hp update
        hpbar.localScale = new Vector2(hpbar.localScale.x * chp, hpbar.localScale.y);
        if (regen)
        {
            chp = mHP;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }

}
