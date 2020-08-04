using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float xLimit = 9f;
    [SerializeField] float yLimit = 8f;

    [Header("Rotation")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float inputPitchFactor = -30f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float inputRollFactor = -20f;

    private float xInput;
    private float yInput;
    private bool isDead = false;

    void Update()
    {
        if (!isDead)
        {
            Translate();
            Rotate();
        }
    }

    private void Translate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        float xOffset = xInput * speed * Time.deltaTime;
        float yOffset = yInput * speed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.localPosition.x + xOffset, -xLimit, xLimit);
        float clampedY = Mathf.Clamp(transform.localPosition.y + yOffset, -yLimit, yLimit);

        transform.localPosition = new Vector3 (clampedX, clampedY, transform.localPosition.z);
    }
    private void Rotate()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToInput = yInput * inputPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToInput;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xInput * inputRollFactor; 

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided: " + other.name);
        isDead = true;
    }

}
