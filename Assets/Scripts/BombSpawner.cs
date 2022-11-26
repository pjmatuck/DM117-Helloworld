using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnBomb), 0, 3);
    }

    void SpawnBomb()
    {
        Vector2 randomCirclePosition = new Vector2();
        randomCirclePosition = Random.insideUnitCircle * 4.5f;

        Vector3 position = new Vector3(
            randomCirclePosition.x,
            this.transform.position.y,
            randomCirclePosition.y);

        Instantiate(bombPrefab, position, Quaternion.identity, this.transform);
    }
}
