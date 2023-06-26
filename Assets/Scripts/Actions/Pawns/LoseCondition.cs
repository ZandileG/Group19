using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class LoseCondition : MonoBehaviour, IDropHandler
{
    public Canvas gameCanvas;
    public Canvas winOrLoseCanvas;
    public GameObject loseText;
    public GameObject islandTile;
    public GameObject floodedTile;

    public void OnDrop(PointerEventData eventData)
    {
        Pawn pawn = eventData.pointerDrag.GetComponent<Pawn>();

       //Check if the pawn's parent is empty
        if (transform.childCount == 0)
        {
            if (!islandTile.activeSelf && !floodedTile.activeSelf)
            {
                //The new parent after the drag
                pawn.parentAfterDrag = transform;

                gameCanvas.gameObject.SetActive(false);
                winOrLoseCanvas.gameObject.SetActive(true);
                loseText.gameObject.SetActive(true);
            }
        }
    }
}
