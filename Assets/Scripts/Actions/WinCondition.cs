using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class WinCondition : MonoBehaviour, IDropHandler
{
    public Canvas gameCanvas;
    public Canvas winOrLoseCanvas;
    public GameObject winText;

    public void OnDrop(PointerEventData eventData)
    {
        Pawn pawn = eventData.pointerDrag.GetComponent<Pawn>();

    //Check if the pawn's parent is not empty
        if (transform.childCount == 2)
        {
          //The new parent after the drag
            pawn.parentAfterDrag = transform;

            gameCanvas.gameObject.SetActive(false);
            winOrLoseCanvas.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
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
