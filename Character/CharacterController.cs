﻿using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotateVel = 100;

    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;
    
    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }
	// Use this for initialization
	void Start () {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("Sorry, I need a RigidBody.");

        forwardInput = 0;
        turnInput = 0;
	}

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical"); //This will give a value between -1 to 1 and control our player forward and backwardsc
        Debug.Log(forwardInput);
        turnInput = Input.GetAxis("Horizontal");
    }
	
	// Update is called once per frame
	void Update () {
        GetInput();
        Turn();
	}
    void FixedUpdate()
    {
        Run();
    }
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        
            rBody.velocity = transform.forward * forwardInput * forwardVel;
        
        else
            rBody.velocity = Vector3.zero;



    }
    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }
}
