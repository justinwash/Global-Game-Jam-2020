using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatyBoy : MonoBehaviour
{
    public float _distance;

    private Vector3 _top, _bottom;
    private float _percent = 0.2f;
    private float _speed = 10f;
    public Direction _direction;

    public enum Direction { UP, DOWN };

    // Start is called before the first frame update
    void Start()
    {
        _top = new Vector3(transform.position.x,
                           transform.position.y + _distance,
                           transform.position.z);
        _bottom = new Vector3(transform.position.x,
                              transform.position.y - _distance,
                              transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        ApplyFloatingEffect();
        ApplyRotationEffect();
    }

    void ApplyFloatingEffect()
    {
        if (_direction == Direction.UP && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_top, _bottom, _percent);
        }
        else if (_direction == Direction.DOWN && _percent < 1)
        {
            _percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(_bottom, _top, _percent);
        }

        if (_percent >= 1)
        {
            _percent = 0.0f;
            if (_direction == Direction.UP)
            {
                _direction = Direction.DOWN;
            }
            else
            {
                _direction = Direction.UP;
            }
        }
    }

    void ApplyRotationEffect()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 250f);
        transform.Rotate(Vector3.right * Time.deltaTime * 250f);
    }
}
