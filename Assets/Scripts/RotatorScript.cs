using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public const int MIN_ROTATION_SPEED = 50;
    public const int MAX_ROTATION_SPEED = 600;

    const float SPEED_INCREASE_INTERVAL = 1f; // how often do you want the speed to change
    const float SPEED_CHANGE = 30; // how much do you want the speed to change 
    float intervalTimer = SPEED_INCREASE_INTERVAL;

    [Range(MIN_ROTATION_SPEED, MAX_ROTATION_SPEED)]
    public float rotationSpeed = 100.0f;

    public bool x;
    public bool y;
    public bool z;

    // Update is called once per frame
    void FixedUpdate()
    {

        float rotateX = x ? rotationSpeed * Time.deltaTime : 0f;
        float rotateY = y ? rotationSpeed * Time.deltaTime : 0f;
        float rotateZ = z ? rotationSpeed * Time.deltaTime : 0f;

        transform.Rotate(rotateX, rotateY, rotateZ);


        intervalTimer -= Time.deltaTime;
        if (intervalTimer < 0 && rotationSpeed > MIN_ROTATION_SPEED)
        {
            rotationSpeed -= SPEED_CHANGE;
            intervalTimer = SPEED_INCREASE_INTERVAL;
        }

    }

}

