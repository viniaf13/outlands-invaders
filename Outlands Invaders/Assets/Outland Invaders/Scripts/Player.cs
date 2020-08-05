using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 20f;
    [SerializeField] float xLimit = 9f;
    [SerializeField] float yLimit = 8f;

    [Header("Rotation")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float inputPitchFactor = -30f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float inputRollFactor = -20f;

    [Header("Guns")]
    [SerializeField] GameObject[] guns = default;

    [Header("FX")]
    [SerializeField] GameObject explosionFX = default;

    private float xInput;
    private float yInput;
    private bool isDead = false;

    void Update()
    {
        if (!isDead)
        {
            Translate();
            Rotate();
            Shoot();
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

    private void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            ActivateGuns(true);
        }
        else
        {
            ActivateGuns(false);
        }
    }

    private void ActivateGuns(bool state)
    {
        foreach (GameObject gun in guns)
        {
            var gunEmissionModule = gun.GetComponent<ParticleSystem>().emission;
            gunEmissionModule.enabled = state;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        explosionFX.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        Time.timeScale = 0.5f;
        FindObjectOfType<LevelLoader>().RestartLevel();
    }
}
