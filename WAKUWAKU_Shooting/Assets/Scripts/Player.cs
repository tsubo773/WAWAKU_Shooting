using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0.0f, 20.0f)] float _speed;
    float _moveHorizontal;
    float _moveVertical;

    void Start()
    {
        
    }

    void Update()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _moveVertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(_moveHorizontal * _speed, 0.0f, _moveVertical * _speed);
    }
}
