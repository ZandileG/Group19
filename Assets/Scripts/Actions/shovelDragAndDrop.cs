using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shovelDragAndDrop : MonoBehaviour
{
   private bool isDragging = false;
    private Vector3 initialPosition;
    public TurnManager turnManager;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            initialPosition = transform.position;
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;
            transform.position = currentPosition;
        }
    }

    private void OnMouseUp()
{
    Debug.Log("DragAndDrop: OnMouseUp: mouse button released");
    isDragging = false;

    // Check if the shovel game object is dropped onto a flooded tile
    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    if (hit.collider != null && hit.collider.gameObject.tag == "FloodedTile")
    {
        Debug.Log("DragAndDrop: OnMouseUp: collision with flooded tile detected");

        // Change the state of the tile from flooded to normal
        // You can do this by activating the normal island tile and deactivating the flooded island tile
        Transform normalIslandTile = hit.collider.transform.parent.parent.Find("IslandTiles").GetChild(hit.collider.transform.GetSiblingIndex());
        normalIslandTile.gameObject.SetActive(true);
        hit.collider.gameObject.SetActive(false);
        turnManager.IncreaseCounter();
    }
}
}
