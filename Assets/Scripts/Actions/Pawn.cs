using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pawn : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
  //The item's image is visible in the Inspector
    [SerializeField] private Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public int PawnIndex;

  //These are also visible in the Inspector
    public PawnMovement tile;

  //This controls what happens when an item is dragged
    public void OnBeginDrag(PointerEventData eventData)
    {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

}
