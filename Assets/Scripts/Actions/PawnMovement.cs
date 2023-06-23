using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PawnMovement : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Pawn pawn = eventData.pointerDrag.GetComponent<Pawn>();

      //Check if the pawn's parent is empty
        if (transform.childCount == 0)
        {
          //The new parent after the drag
            pawn.parentAfterDrag = transform;
        }

        else 
        {
          //Remove the pawn from the tile
            StartCoroutine(RemovePawnFromTile(eventData.pointerDrag, 1f));
        }
    }

    private IEnumerator RemovePawnFromTile(GameObject pawn, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(pawn);
    }
}

