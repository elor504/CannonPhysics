﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
 
  
    List<Vector3> forces = new List<Vector3>();
    Vector3 shakul;
    float gravityCounter = 0f;
    [SerializeField] Vector3 gravity;
    
    Rigidbody rb;


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
   
    public void AddForce(Vector3 _Force)
    {
    
        forces.Add(_Force);
    }
    //public void ShootDirection(int Power)
    //{
    //    rb.AddForce(Vector3.right * (Power / 2), ForceMode.Impulse);
    //}
    private void Update()
    {

    }
    private void FixedUpdate()
    {

        gravityCounter += Time.fixedDeltaTime;
        shakul = Vector3.zero;
        for (int i = 0; i < forces.Count; i++)
        {
            shakul += forces[i];
        }
        shakul += gravityCounter * gravity;


        rb.position = transform.position + shakul;
        //transform.Translate(shakul);
        //Vector3 pos = transform.position;
        //do chagnes
        //pos += shakul;
        // transform.position = pos;

        if(transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("hit");
            Destroy(this.gameObject);
        }
    }

}