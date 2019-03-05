using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBehavior : MonoBehaviour
{
    public float blockSpeed = 8;

    Transform _leftBoundary;
    Transform _rightBoundary;

    bool _isGoingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        _leftBoundary = GameObject.Find("Left Boundary").transform;
        _rightBoundary = GameObject.Find("Right Boundary").transform;

        if (Random.value < 0.5f)
            _isGoingRight = true;
        else
            _isGoingRight = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (_isGoingRight)
        {
            MoveRightTick ();
        }
        else
        {
            MoveLeftTick ();
        }

    }


    void MoveRightTick ()
    {
        transform.Translate (Vector3.right * blockSpeed * Time.deltaTime);

        // If block is too far to right, start going left
        if (transform.position.x > _rightBoundary.position.x)
        {
            _isGoingRight = false;
        }
    }


    void MoveLeftTick()
    {
        transform.Translate (Vector3.left * blockSpeed * Time.deltaTime);

        // If block is too far to let, start going right
        if (transform.position.x < _leftBoundary.position.x)
        {
            _isGoingRight = true;
        }
    }
}
