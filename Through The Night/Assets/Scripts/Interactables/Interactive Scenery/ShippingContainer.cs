using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingContainer : MonoBehaviour
{
    public void OnInteract()
    {
        FindObjectOfType<AudioManager>().Play("ShippingContainerBang");
    }
}
