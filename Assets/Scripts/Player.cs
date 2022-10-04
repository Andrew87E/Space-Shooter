using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // pub or private ref (public = global | {{{private}}} = class scoped)
    // data type (int, float, bool, str)
    [SerializeField]
    private float _speed = 3.5f; //f for Float

    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        // transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        // transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(direction * _speed * Time.deltaTime);

        // if player pos on Y axis is > 0 y pos = 0
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
            //else if pos on the y is less than -3.8 y pos = -3.8f
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        // if player hits left of screen wrap to right of screen

        if (transform.position.x >= 16.64287f){
            transform.position.x = new Vector3(-16.64287f, transform.position.y, 0);
        }
    }
}
