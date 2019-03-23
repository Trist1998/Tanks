using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float acceleration;
    public float rotationSpeed;
    public float maxSpeed;
    public float coFriction;
    public int playerNumber;
    private float boostTimer;
    public float boostVelocity;
    public float boostTime;
    private ParticleSystem dirt;

    public void boost(float boostVelocity)
    {
        this.boostVelocity = boostVelocity;
        boostTimer = boostTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        dirt = gameObject.GetComponent<ParticleSystem>();
    }

    private float getForwardAxis()
    {
        if (playerNumber == 1)
            return Input.GetAxis("Vertical");
        return Input.GetAxis("Player2_Forward");
    }

    private float getTurnAxis()
    {
        if (playerNumber == 1)
            return Input.GetAxis("Horizontal");
        return Input.GetAxis("Player2_Turn");
    }

    void FixedUpdate()
    {
         
        rigidBody.AddRelativeForce(new Vector2(1, 0) * acceleration * getForwardAxis());

        transform.Rotate(new Vector3(0, 0, -1) * rotationSpeed * getTurnAxis());

        rigidBody.AddForce(rigidBody.velocity.normalized * -1 * getCoFriction() * Mathf.Abs(Mathf.Sin(Vector3.Angle(rigidBody.velocity.normalized,transform.forward.normalized))));

        controlSpeed();

    }

    private void controlSpeed()
    {
        if(boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            rigidBody.AddRelativeForce(new Vector2(1, 0) * boostVelocity);
        }
        else if (rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }
    }

    private float getCoFriction()
    {
        return coFriction;
    }
}
