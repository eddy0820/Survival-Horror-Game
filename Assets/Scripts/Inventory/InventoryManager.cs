using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject teleporterPrefab;
    [SerializeField] float teleporterCooldown;
    [ReadOnly, SerializeField] float currTeleporterCooldown = 0;
    [ReadOnly, SerializeField] InventorySlots currentlySelectedSlot;
    GameObject teleporterHolder = null;
    bool canThrow;
    
    private void Update()
    {
        if(teleporterHolder == null)
        {
            if(currTeleporterCooldown > 0)
            {
                currTeleporterCooldown -= Time.deltaTime;
            }
            else
            {
                canThrow = true;
            }
        }
    }

    public void SwitchSlot(InventorySlots slot)
    {
        currentlySelectedSlot = slot;
    }

    public void UseItem()
    {
        switch(currentlySelectedSlot)
        {
            case InventorySlots.Up:
                UseTeleporter();
                break;
            case InventorySlots.Right:
                Debug.Log("Right Slot Used.");
                break;
            case InventorySlots.Down:
                Debug.Log("Down Slot Used.");
                break;
            case InventorySlots.Left:
                Debug.Log("Left Slot Used.");
                break;
        }
    }

    private void UseTeleporter()
    {
        if(teleporterHolder != null)
        {
            transform.position = teleporterHolder.transform.position + transform.up * 1f;
            Destroy(teleporterHolder);
        }
        else
        {
            if(canThrow)
            {
                Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z);
                Vector3 forwardSpawnPos = spawnPos + transform.forward * 1f;

                var obj = Instantiate(teleporterPrefab, forwardSpawnPos, Quaternion.identity);
                teleporterHolder = obj;

                obj.GetComponent<Teleporter>().ThrowTeleporterPad(transform.forward);
                
                currTeleporterCooldown = teleporterCooldown;
                canThrow = false;
            }
           
        }
        
       
    }
}
