using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDoors : MonoBehaviour
{
    public void OnInteract()
    {
        transform.rotation = Quaternion.Euler(-90, 160, 0);
        FindObjectOfType<AudioManager>().Play("MetalDoorOpening");
    }
}
