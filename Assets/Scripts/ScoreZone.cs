using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            GameController.Instance.Score();
        }
    }
}
