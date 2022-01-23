using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Flashlight flashlight;
    public Rigidbody rb;
    public BoxCollider col;
    public Transform player;
    public Transform flaslightContainer;
    public Transform fpsCam;

    public float pickUpRange;
    public float dropForwardForce;
    public float dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        if (!equipped)
        {
            flashlight.enabled = false;
            rb.isKinematic = false;
            col.isTrigger = false;
        }
        if (equipped)
        {
            flashlight.enabled = true;
            rb.isKinematic = true;
            col.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        // Check if player is in range and presses E
        Vector3 distanceToPlayer = player.position - transform.position;

        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            Pickup();
        }

        // Drop is pressed Q
        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }

    private void Pickup()
    {
        equipped = true;
        slotFull = true;

        transform.SetParent(flaslightContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(90, 0, 0);
        transform.localScale = new Vector3(5, 5, 5);

        rb.isKinematic = true;
        col.isTrigger = true;

        flashlight.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        col.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.forward * dropUpwardForce, ForceMode.Impulse);

        flashlight.enabled = false;
    }
}
