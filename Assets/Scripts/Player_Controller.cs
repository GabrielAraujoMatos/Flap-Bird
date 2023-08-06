using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool isPressingLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isPressingRight = Input.GetKey(KeyCode.RightArrow);

        if (isPressingLeft == isPressingRight)
        {
            return;
        }

        float movement = speed * Time.deltaTime;
        if (isPressingLeft)
        {
            movement *= -1f;
        }
        transform.position += new Vector3(movement, 0, 0);

        float movementLimit = GameManager.Instance.gameWidth / 2;
        if (transform.position.x < -movementLimit)
        {
            transform.position = new Vector3(movementLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > movementLimit)
        {
            transform.position = new Vector3(-movementLimit, transform.position.y, transform.position.z);
        }
    }
}
