using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialPosition;

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
        isDragging = false;
    }
}

