using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShoreUpTile : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        // Update the position of the shovel game object as it's being dragged
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("ShoreUpTile: OnEndDrag: drag ended");

        // Check if the shovel game object is dropped onto a flooded tile
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.tag == "FloodedTile")
        {
            Debug.Log("ShoreUpTile: OnEndDrag: collision with flooded tile detected");

            // Change the state of the tile from flooded to normal
            // You can do this by activating the normal island tile and deactivating the flooded island tile
            Transform normalIslandTile = hit.collider.transform.parent.parent.Find("IslandTiles").GetChild(hit.collider.transform.GetSiblingIndex());
            normalIslandTile.gameObject.SetActive(true);
            hit.collider.gameObject.SetActive(false);
        }
    }
}
