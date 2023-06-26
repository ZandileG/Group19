using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TreasureMovement : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Treasure treasure = eventData.pointerDrag.GetComponent<Treasure>();

        //Check if the pawn's parent has one child
        if (transform.childCount == 0)
        {
            //The new parent after the drag
            treasure.parentAfterDrag = transform;
        }
    }
}
