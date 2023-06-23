using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*public class PawnMovement : MonoBehaviour, IDropHandler
{
    public MovePawn pawn;

    public void OnDrop(PointerEventData eventData)
    {
        Item_Image item_Image = eventData.pointerDrag.GetComponent<Item_Image>();

        //Check if the item's price is less than the available money
        if (item_Image != null && item_Image.price <= budget.money)
        {
            //Check if the item's parent is empty
            if (transform.childCount == 0)
            {
                //The new parent will be the backpack slot after dragging
                item_Image.parentAfterDrag = transform;
            }
        }

        else
        {
            //Check if the item is not coming from the Chest
            if (eventData.pointerDrag.GetComponentInParent<MoveChestItem>() == null)
            {
                //Remove the item from the backpack
                StartCoroutine(RemoveItemFromBag(eventData.pointerDrag, 1f));
            }
        }
    }

    private IEnumerator RemoveItemFromBag(GameObject item_Image, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(item_Image);
    }
}*/
