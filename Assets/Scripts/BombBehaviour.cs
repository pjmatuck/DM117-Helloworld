using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public float bombLifeTime;

    void Start()
    {
        Invoke(nameof(DestroyIt), bombLifeTime);
    }

    void DestroyIt()
    {
        Destroy(this.gameObject);
    }
}
