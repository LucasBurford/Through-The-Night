using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpeaker : MonoBehaviour
{
    public Animator animator;

    public void OnInteract()
    {
        animator.SetBool("Open", true);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("Open", false);
    }
}
