using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    private PlayerControllerX playerControllerScript;
    private float leftBound = -15.0f;
    private float moveLeft = -10.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveLeft);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && gameObject.CompareTag("Bomb"))
        {
            Destroy(gameObject);
        }else if (transform.position.x < leftBound && gameObject.CompareTag("Money"))
        {
            Destroy(gameObject);
        }


    }
}
