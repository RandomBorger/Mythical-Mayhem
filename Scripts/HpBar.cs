using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] public GameObject owner;
    private Vector3 maxsize;
    // Start is called before the first frame update
    void Start()
    {
        maxsize = transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {
        if (owner != null && owner.GetComponent<Health>() != null)
        {
            Health hp = owner.GetComponent<Health>();
            transform.localScale = new Vector3(maxsize.x * (hp.chp/hp.mhp), maxsize.y, maxsize.z);
        }
    }
}
