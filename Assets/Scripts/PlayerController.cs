using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;
    public Button restartButton;

    Rigidbody rigidBody;

    private int collectableCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Debug.Log($"Horizontal: {x}, Vertical: {y}");

        Vector3 position = new Vector3(x, 0, z);

        //transform.Translate(position * Time.deltaTime * speed);

        var force = position * Time.deltaTime * speed;

        rigidBody.AddForce(force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.LogWarning("Colidiu!");
        }

        if (collision.gameObject.CompareTag("Bomb"))
        {
            Debug.LogError("Game over!");
            this.gameObject.SetActive(false);
            loseText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            collectableCount++;
            pointsText.text = collectableCount.ToString();
        }

        if(collectableCount >= 10)
        {
            winText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
