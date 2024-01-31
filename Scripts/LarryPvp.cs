using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class LarryPvp : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck; //your feet
    [SerializeField] private LayerMask groundLayer; //what is the groun
    [SerializeField] public GameObject rhp; 
    public GameObject slash;
    private GameObject attackarea2;
    private bool attacking = false;
    private float timetoatk = 0.24f;
    private float atimer = 0f;
    public float jumpstrenght = 20f; //movment strenght
    public float horizontal;
    private bool isleftb; //turning
    public bool isLeft = true; //turning
    public int mjumps = 1; //jumping
    private int jumps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isleftb = isLeft;
        if (Input.GetKeyDown(KeyCode.Mouse0) && !attacking)
        {
            attackarea2 = Instantiate(slash, transform);
            Attack();
        }

        if (attacking)
        {

            atimer += Time.deltaTime;

            if (atimer >= timetoatk)
            {
                atimer = 0f;
                attacking = false;
                Destroy(attackarea2);
            }
        }
        Move();
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Attack()
    {
        attacking = true;
        attackarea2.SetActive(attacking);
    }

    private void Move()
    {
        if ((Input.GetKey(KeyCode.A) == true))
        {
            isLeft = true;
            if (isleftb != isLeft)
            {
                rb.velocity = new Vector2(rb.velocity.x / 1.7f, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(math.max(rb.velocity.x, -5) - horizontal / 10, rb.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isLeft = false;
            if (isleftb != isLeft)
            {
                rb.velocity = new Vector2(rb.velocity.x / 1.7f, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(math.min(rb.velocity.x, 5) + horizontal / 10, rb.velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumps < mjumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpstrenght);
            jumps += 1;
        }
        if (isleftb != isLeft)
        {

            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
        //resetting jumps
        if (IsGrounded())
        {
            jumps = 0;
        }
        //Pressure sensitve jump & Slowing
        if (Input.GetKey(KeyCode.Space) || rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.95f, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.95f, rb.velocity.y * 0.95f);
        }
    }
}
