using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public AudioSource walkAudio;

    public Vector3 velocity;

    public float speed;
    public float jumpHeight;
    public float gravity;
    public float groundDistance;
    public bool isPlayerMoving;
    public bool isWalkAudioPlaying;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        if (move.magnitude != 0)
        {
            isPlayerMoving = true;
        }
        else
        {
            isPlayerMoving = false;
        }

        if (isPlayerMoving)
        {
            if (!walkAudio.isPlaying && isGrounded)
            {
                walkAudio.Play();
            }
        }
        else
        {
            walkAudio.Stop();
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
