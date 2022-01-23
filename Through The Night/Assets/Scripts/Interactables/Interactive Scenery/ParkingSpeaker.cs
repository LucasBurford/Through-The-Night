using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpeaker : MonoBehaviour
{
    public Animator animator;
    public GameObject go;

    public void OnInteract()
    {
        go.transform.position = new Vector3(-0.06f, 0.87f, 0.24f);
        go.transform.rotation = Quaternion.Euler(0, 0, -40);
    }
}
