using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject columnPrefab;
    private float timer = 0;
    private float spawnInterval = 3.0f;
    private float spawnPosition = 4.1f;
    private float upperLimit = 2.8f;
    private float lowerLimit = -1.0f;
    private List<GameObject> columns = new List<GameObject>();

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer > spawnInterval)
        {
            timer -= spawnInterval;

            if (GameController.Instance.IsRunning())
            {
                columns.Add(Instantiate(columnPrefab, new Vector3(spawnPosition, Random.Range(lowerLimit, upperLimit), 0), Quaternion.identity));
            }
        }

        for (int index = 0; index < columns.Count; index++)
        {
            GameObject column = columns[index];

            if (column.transform.position.x < -spawnPosition)
            {
                columns.RemoveAt(index);
                Destroy(column);
            }
        }
    }

    public void ClearColumns()
    {
        for (int index = 0; index < columns.Count; index++)
        {
            Destroy(columns[index]);
        }

        columns.Clear();
    }
}
