using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Transform pos;
    public Transform cam;
    private float limbo;
    public float speed = 10f;
    public float jump = 10f;
    private Vector3 moving = Vector3.zero;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        pos = GetComponent<Transform>();
    }

    void Update()
    {
        limbo = moving.y;
        moving = Vector3.zero;
        if (Input.GetKey("w"))
            moving = Vector3.forward + moving;
        if (Input.GetKey("s"))
            moving = Vector3.back + moving;
        if (Input.GetKey("d"))
            moving = Vector3.right + moving;
        if (Input.GetKey("a"))
            moving = Vector3.left + moving;

        moving = ((cam.right * moving.x) + (cam.forward * moving.z)) * speed;
        if (controller.isGrounded)
        {
            Jump();
        }
        moving.y = limbo;
        moving.y = moving.y - (20 * Time.deltaTime);
        if (pos.position.y < -30.0f)
            moving = Vector3.zero;
        controller.Move(moving * Time.deltaTime);
        if (pos.position.y < -30.0f)
            pos.position = new Vector3(0, 10, 0);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            limbo = jump;
        else
            limbo = 0;
    }
}