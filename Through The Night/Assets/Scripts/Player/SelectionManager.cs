using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public GameObject cam;
    public LayerMask selectableLayer;
    public TextMeshProUGUI interactText;

    public float maxRayDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(cam.transform.position, cam.transform.forward * maxRayDistance);

        RaycastHit hit;

        // Cast out a ray over selectableLayer, for maxRayDistance
        if (Physics.Raycast(ray, out hit, maxRayDistance, selectableLayer))
        {
            interactText.gameObject.SetActive(true);
            interactText.text = "E Interact?";

            CheckInput(hit.collider.gameObject);

            print(hit.collider.gameObject.name);
        }
        else
        {
            interactText.gameObject.SetActive(false);
        }
    }

    private void CheckInput(GameObject go)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            go.SendMessageUpwards("OnInteract");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * maxRayDistance);
    }
}
