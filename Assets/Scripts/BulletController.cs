using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] LayerMask _layerMask;
    [SerializeField] Vector3 _frightPoint;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _power = 10f;
    const float deleteDistance = 35 * 35;   // íœ‹——£

    // Start is called before the first frame update
    void Start()
    {
        _frightPoint = transform.Find("BulletPoint").localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float _distance = (_frightPoint - transform.position).sqrMagnitude;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(_bullet,transform.position + _frightPoint, Quaternion.identity);
            transform.Translate(_power * Time.deltaTime,0,0);
        }
        if (_distance > deleteDistance)
        {
            Destroy(_bullet);
        }
    }
}