using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        TreasureCardMovement treasureCardMovement = eventData.pointerDrag.GetComponent<TreasureCardMovement>();

        //Check if the pawn's parent is empty
        if (transform.childCount == 0)
        {
            //The new parent after the drag
            treasureCardMovement.parentAfterDrag = transform;
        }
    }
}
