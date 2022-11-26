using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public GameObject playerPrefab;

    List<Vector3> positions = new List<Vector3>();
    List<Transform> snakeBody = new List<Transform>();

    enum Directions
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    Directions direction;

    // Start is called before the first frame update
    void Start()
    {
        snakeBody.Add(playerPrefab.transform);
        InvokeRepeating(nameof(Move), 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Directions.DOWN;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Directions.UP;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Directions.LEFT;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Directions.RIGHT;
        }
    }

    void Move()
    {
        switch (direction)
        {
            case Directions.UP:
                UpdateBodyPosition(Vector3.forward);
                break;
            case Directions.DOWN:
                UpdateBodyPosition(Vector3.back);
                break;
            case Directions.LEFT:
                UpdateBodyPosition(Vector3.left);
                break;
            case Directions.RIGHT:
                UpdateBodyPosition(Vector3.right);
                break;
        }
    }

    void UpdateBodyPosition(Vector3 direction, int i = 0)
    {
        if (i == snakeBody.Count) return;

        var lastPosition = snakeBody[i].position;
        snakeBody[i].Translate(direction);
        UpdateBodyPosition(lastPosition, i++);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            var newBody = Instantiate(playerPrefab, 
                snakeBody[snakeBody.Count - 1].position, 
                Quaternion.identity);
            snakeBody.Add(newBody.transform);
        }
    }
}
