using UnityEngine;

public class Column : MonoBehaviour
{
    Vector3 translation = new Vector3(-1.5f, 0, 0);

    void FixedUpdate()
    {
        if (GameController.Instance.IsRunning())
        {
            transform.Translate(translation * Time.fixedDeltaTime);
        }
    }
}
