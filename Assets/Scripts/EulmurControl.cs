﻿using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class EulmurControl : MonoBehaviour {

    public MoveSettings moveSettings;
    public InputSettings inputSettings;
    private float SidewaysInput, JumpInput;

    void Awake()
    {
        SidewaysInput = JumpInput = 0;
    }
    void Update ()
    {
        GetPlayerInput();
        Run();
        Jump();
    }
    
    void GetPlayerInput()
    {
        SidewaysInput = Input.GetAxis(inputSettings.PLAYER_SIDEWAYS_AXIS);
    }

    void Run()
    {
        gameObject.GetComponent<Transform>().position += transform.right * SidewaysInput * Time.deltaTime * moveSettings.RunVelocity;
    }

    void Jump()
    {
        if (JumpInput != 0 && Grounded())
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * moveSettings.JumpVelocity, ForceMode2D.Impulse);
        }
    }

    bool Grounded()
    {
        return Physics2D.Raycast(gameObject.transform.position, Vector2.down, moveSettings.DistanceToGround, moveSettings.Ground);

    }

    [System.Serializable]
public class MoveSettings
{
    public float RunVelocity = 8;
    public float JumpVelocity = 2f;
    public float DistanceToGround = 0.5f;
    public LayerMask Ground;
}

[System.Serializable]
public class InputSettings
{
    public string PLAYER_SIDEWAYS_AXIS = "Horizontal";
    public string PLAYER_JUMP_AXIS = "Jump";
}
}