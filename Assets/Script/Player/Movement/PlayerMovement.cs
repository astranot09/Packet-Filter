using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;

    [Header("Direction")]
    [SerializeField] private Vector2 currentDirection;
    [SerializeField] private Vector2 lastDirection;
    public Vector2 LastDirection => lastDirection;

    [SerializeField] private bool alreadyRotate;

    [Header("Reference")]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = currentDirection * movementSpeed;
    }


    public void SetCurrentDirection(Vector2 dir)
    {
        currentDirection = dir;
    }
    public void SetLastDirection(Vector2 dir)
    {
        lastDirection = dir;
        if (lastDirection.x < 0 && !alreadyRotate)
        {
            alreadyRotate = true;
            transform.Rotate(0, 180, 0);
        }
        if (lastDirection.x > 0 && alreadyRotate)
        {
            alreadyRotate = false;
            transform.Rotate(0, -180, 0);
        }
    }
}
