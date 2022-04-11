using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    Transform anchor;
    Transform exit;
    InputManager player;
    [ReadOnly] public bool inside;

    private void Awake()
    {
        anchor = transform.GetChild(0);
        exit = transform.GetChild(1);
        player = GameObject.FindObjectOfType<InputManager>();
    }

    public void GetInHidingSpot()
    {
        if(!inside)
        {
            player.transform.position = anchor.position;
            Vector3 lookPosition = new Vector3(exit.position.x, player.transform.position.y, exit.position.z);
            player.transform.LookAt(lookPosition);
            inside = true;
        }
        else
        {
            player.transform.position = exit.position;
            inside = false;
        }
        
    }
}
