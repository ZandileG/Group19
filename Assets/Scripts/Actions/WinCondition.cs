using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class WinCondition : MonoBehaviour, IDropHandler
{
    public Canvas gameCanvas;
    public Canvas winOrLoseCanvas;
    public GameObject winText;
    public GameObject islandTile;
    public GameObject halfTile;


    public void OnDrop(PointerEventData eventData)
    {
        Pawn pawn = eventData.pointerDrag.GetComponent<Pawn>();

       //Check if the pawn's parent is empty
        if (transform.childCount == 0 && halfTile.transform.childCount == 1)
        {
            if (islandTile.activeSelf)
            {
                //The new parent after the drag
                pawn.parentAfterDrag = transform;

                gameCanvas.gameObject.SetActive(false);
                winOrLoseCanvas.gameObject.SetActive(true);
                winText.gameObject.SetActive(true);
            }
        }
    }
}
