using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MausePointer : MonoBehaviour
{
    private Vector3 _mousePos;
    [SerializeField] Transform _muzul;
    [SerializeField] Transform _player;

    // Update is called once per frame
    void Update()
    {
        _mousePos = Input.mousePosition;
        _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(this._mousePos.x, this._mousePos.y, 0));
        _mousePos.z = 0;
        this.transform.position = _mousePos;

    }
}
