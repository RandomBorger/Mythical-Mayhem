using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Health : MonoBehaviour
{
    [SerializeField] public float chp = 100;
    public float mhp = 100;
    public float dmg;
    public int toughness = 1;
    public bool isplayer;
    private float dir;
    private bool isinvun;
    private float timer;
    private float invuntime = 0.24f;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public GameObject go;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (isplayer && isinvun)
        {
            timer += Time.deltaTime;

            if (timer >= invuntime) 
            {
                isinvun = false;
                timer = 0;
            } else
            {
                dmg = 0;
            }
        }

        if (dmg != 0)
        {
            //takes dmg
            this.chp = chp - dmg;
            this.dmg = 0;
        }

        if (this.chp <= 0)
        {
            Destroy(this.go);
        }
    }
    
    public void Damage(int amount, Rigidbody2D rb)
    {
        if (dmg < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage :p");
        }
        else
        {
            this.dmg = amount;
        }

        if (rb != null)
        {
            dir = math.sign(this.rb.position.x - rb.position.x);
        }

        if (dmg != 0)
        {
            this.rb.velocity = new Vector2((dir * amount) / (this.toughness), amount / (this.toughness));
            isinvun = true;
        }
    }

    public void Regen(int amount)
    {
        if (dmg > 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative heal :p");
        }
        else if (chp + amount > 100) //would be over max hp
        {
            this.chp = 100;
        } else
        {
            this.dmg = -amount;
        }
    }

    
}
