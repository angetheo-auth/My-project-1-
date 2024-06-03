using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15;
    private PlayerController playerControllerScript;
    private float leftBound;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
        leftBound = playerControllerScript.transform.position.x - GetComponent<BoxCollider>().size.x * 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound){
           Destroy(gameObject);
        }

    }
}
