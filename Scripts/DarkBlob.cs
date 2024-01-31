using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;

public class DarkBlob : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer; //what is the ground
    [SerializeField] private LayerMask enemy;
    [SerializeField] private LayerMask attack;
    [SerializeField] private GameObject darkblob;
    Rigidbody rb;
    GameObject obj;
    private double chp = 1;
    private double dmg;
    private double atk = 0.06;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // obj = GameObject.FindGameObjectWithTag("Regatk");
    }
}
