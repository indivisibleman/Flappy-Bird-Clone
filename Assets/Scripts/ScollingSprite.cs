using UnityEngine;

public class ScollingSprite : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject repeatedSprite = new GameObject();
    }

    void Update()
    {
        if (GameController.Instance.IsRunning())
        {
            transform.Translate(-scrollSpeed * Time.deltaTime, 0, 0);

            if (transform.position.x < -spriteRenderer.size.x / 4)
            {
                transform.Translate(spriteRenderer.size.x / 2, 0, 0);
            }
        }
    }
}
