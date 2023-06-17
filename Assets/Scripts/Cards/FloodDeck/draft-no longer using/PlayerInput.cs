/*using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Deck deck;
    public GameObject cardPrefab;
    public Transform cardPosition;

void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject == deck.gameObject)
            {
                Debug.Log("Deck: " + deck);
                Debug.Log("Card prefab: " + cardPrefab);
                Debug.Log("Card position: " + cardPosition);
                deck.Shuffle();
                Card drawnCard = deck.DrawCard();
                Debug.Log("Drawn card: " + drawnCard);
                Debug.Log("Drawn card image: " + drawnCard.image);
                GameObject cardObject = Instantiate(cardPrefab, cardPosition.position, Quaternion.identity);
                Debug.Log("Card object: " + cardObject);
                SpriteRenderer spriteRenderer = cardObject.GetComponent<SpriteRenderer>();
                Debug.Log("Sprite renderer: " + spriteRenderer);
                spriteRenderer.sprite = drawnCard.image;
            }
        }
    }
}


}
*/