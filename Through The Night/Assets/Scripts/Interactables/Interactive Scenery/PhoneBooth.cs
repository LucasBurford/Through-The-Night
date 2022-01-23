using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneBooth : MonoBehaviour
{
    public int interacts;

    public void OnInteract()
    {
        interacts++;

        if (interacts == 1)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            FindObjectOfType<AudioManager>().Play("PhoneBoothDialTone");
        }
        
        if (interacts == 10)
        {
            FindObjectOfType<AudioManager>().Play("EasterEgg");
        }
    }
}
