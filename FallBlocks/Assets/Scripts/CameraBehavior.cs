using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public float moveSpeed = 5;

    float _targetYPosition;


    // Start is called before the first frame update
    void Start ()
    {
        _targetYPosition = transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, _targetYPosition, transform.position.z);
        transform.position = Vector3.Lerp (transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }


    public void OnPieceDropped ()
    {
        _targetYPosition += 1;
    }
}
