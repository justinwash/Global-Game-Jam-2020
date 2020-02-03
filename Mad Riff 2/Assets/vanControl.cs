using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanControl : MonoBehaviour
{
    public float turnSpeed = 50f;

    public float _Velocity = 0.0f;      // Current Travelling Velocity
    public float _MaxVelocity = 10000.0f;   // Maxima Velocity
    public float _Acc = 0.0f;           // Current Acceleration
    public float _AccSpeed = 5f;      // Amount to increase Acceleration with.
    public float _MaxAcc = 100.0f;        // Max Acceleration
    public float _MinAcc = -100.0f;       // Min Acceleration


    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");


        if (yAxis > 0)
            _Acc += _AccSpeed;

        if (yAxis < 0)
            _Acc -= _AccSpeed;

        if (xAxis < 0)
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (xAxis > 0)
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);


        if (_Acc > _MaxAcc)
            _Acc = _MaxAcc;
        else if (_Acc < _MinAcc)
            _Acc = _MinAcc;

        _Velocity += _Acc;

        if (_Velocity > _MaxVelocity)
            _Velocity = _MaxVelocity;
        else if (_Velocity < -_MaxVelocity)
            _Velocity = -_MaxVelocity;

        transform.Translate(transform.right * _Velocity * Time.deltaTime);
    }
}
