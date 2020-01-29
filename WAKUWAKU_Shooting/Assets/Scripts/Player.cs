using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary> Playerのスピード </summary>
    [SerializeField] int _speed = 3;
    /// <summary> 弾のプレハブ </summary>
    [SerializeField] GameObject _bulletName;
    /// <summary> 弾の発射点 </summary>
    [SerializeField] Transform _bulletSpawn;
    /// <summary> 弾の発射間隔 </summary>
    [SerializeField] float _interval = 0.2f;

    float _moveHorizontal;
    float _moveVertical;
    /// <summary> 弾発射中の経過時間 </summary>
    float _elapsedTime;

    void Start()
    {
        
    }

    void Update()
    {
        Direction();
        Move();
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(_moveHorizontal * _speed, 0.0f, _moveVertical * _speed);
    }

    /// <summary>
    /// Playerの方向
    /// </summary>
    void Direction()
    {
        float _directionHorizontal = Input.GetAxis("Horizontal2");
        float _directionVertical = Input.GetAxis("Vertical2");
        if (_directionHorizontal != 0 || _directionVertical != 0) {
            var _direction = new Vector3(_directionHorizontal, 0, _directionVertical);
            transform.localRotation = Quaternion.LookRotation(_direction);
            Shoot();
        }
        else if(_moveHorizontal != 0 || _moveVertical != 0) {
            var _direction = new Vector3(-_moveHorizontal, 0, -_moveVertical);
            transform.localRotation = Quaternion.LookRotation(_direction);
        }
    }

    /// <summary>
    /// Playerの移動
    /// </summary>
    void Move()
    {
        _moveHorizontal = Input.GetAxis("Horizontal1");
        _moveVertical = Input.GetAxis("Vertical1");
    }

    /// <summary>
    /// 弾を撃つ
    /// </summary>
    void Shoot()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _interval) {
            Instantiate(_bulletName, _bulletSpawn.position, transform.localRotation);
            _elapsedTime = 0f;
        }
    }
}
