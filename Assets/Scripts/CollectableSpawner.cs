using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject collectable;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, 1f);
    }

    void SpawnObject()
    {
        Vector3 position = new Vector3(
            (Random.value * 9) - 4.5f,
            collectable.transform.position.y,
            (Random.value * 9) - 4.5f);

        Instantiate(collectable, position, Quaternion.identity, this.transform);
    }
}
