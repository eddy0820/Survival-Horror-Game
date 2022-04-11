using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Image slot1;
    [SerializeField] Image slot2;
    [SerializeField] Image slot3;
    [SerializeField] Image slot4;
    [SerializeField] Sprite unselectedSlotImage;
    [SerializeField] Sprite selectedSlotImage;

    public void SwitchSlot(InventorySlots slot)
    {
        switch(slot)
        {
            case InventorySlots.Up:
                slot1.sprite = selectedSlotImage;
                slot2.sprite = unselectedSlotImage;
                slot3.sprite = unselectedSlotImage;
                slot4.sprite = unselectedSlotImage;
                break;
            case InventorySlots.Right:
                slot1.sprite = unselectedSlotImage;
                slot2.sprite = selectedSlotImage;
                slot3.sprite = unselectedSlotImage;
                slot4.sprite = unselectedSlotImage;
                break;
            case InventorySlots.Down:
                slot1.sprite = unselectedSlotImage;
                slot2.sprite = unselectedSlotImage;
                slot3.sprite = selectedSlotImage;
                slot4.sprite = unselectedSlotImage;
                break;
            case InventorySlots.Left:
                slot1.sprite = unselectedSlotImage;
                slot2.sprite = unselectedSlotImage;
                slot3.sprite = unselectedSlotImage;
                slot4.sprite = selectedSlotImage;
                break;
        }
    }




}
