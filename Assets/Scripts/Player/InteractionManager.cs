using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [ReadOnly, SerializeField] bool lookingAtInteractable;
    public bool LookingAtInteractable => lookingAtInteractable;
    Vector3 centerOfScreen;
    Ray rayOrigin;
    RaycastHit hit;
    bool interact;

    LayerMask interactableMask;

    private void Awake()
    {
        interactableMask = LayerMask.GetMask("HidingSpot");
    }

    private void FixedUpdate()
    {
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        centerOfScreen = new Vector3((Screen.width / 2), (Screen.height / 2), 0);
        rayOrigin = Camera.main.ScreenPointToRay(centerOfScreen);

        if(Physics.Raycast(rayOrigin, out hit, Mathf.Infinity, interactableMask))
        {   
            lookingAtInteractable = true;

            if(interact)
            {
                hit.collider.GetComponentInParent<HidingSpot>().GetInHidingSpot();
                interact = false;
                lookingAtInteractable = false;
            }
        }
        else
        {
            lookingAtInteractable = false;
        }
    }

    public void OnInteractPressed()
    {
        if(lookingAtInteractable)
        {
            interact = true;
        }     
    }
}
