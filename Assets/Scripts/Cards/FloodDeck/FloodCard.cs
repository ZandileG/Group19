using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodCard : MonoBehaviour
{
     private SpriteRenderer spriteRenderer; // SpriteRenderer component
    public bool isDeactivated = false;

    void Awake()
    {       Debug.Log("FloodCard: Awake");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetCardSprite(Sprite sprite)
    {
        // Set the sprite of the SpriteRenderer component
        spriteRenderer.sprite = sprite;
         Debug.Log("FloodCard: SetCardSprite");
    }
}
