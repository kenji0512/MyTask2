using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour   
{
    [SerializeField] float _speed = 1.0f;
    [SerializeField] float _extinc = 0.3f;
    [SerializeField] float _gvScale = 0.3f;
    [SerializeField] float _scale = 2.0f;
    [SerializeField] float _jumpPower = 1.0f;
    float _jumpY = 0.0f;
    float _jtime = 0.0f;

    private void Start()
    {
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        this.transform.position += new Vector3(h, 0, 0) * Time.deltaTime * _speed;

        if (_jumpY < 0.001f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpY = _jumpPower; //初速
                _jtime = 0.0f;
            }
        }
        else
        {
            _jtime += Time.deltaTime; //経過時間
            _jumpY *= 1.0f - Time.deltaTime * _extinc; //力の減衰
            float y = this.transform.position.y;
            y = (_jumpY * _jtime - 9.81f * _jtime * _jtime * _gvScale) * _scale + -2.0f; //(力*時間+重力加速度*重力の強さ) * スケール

            if (y < -4.0f)
            {
                y = -4;
                _jtime = 0;
                _jumpY = 0;
            }
            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
    }
}