using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMuzul : MonoBehaviour
{
    [SerializeField] GameObject _bul;
    float _radian = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(_bul.gameObject, transform.position, transform.rotation);
            var scr = bullet.GetComponent<BulletController>();
            scr.SetVector(this.transform.right);

        }

    }
    public void TargetRadian(float rad)
    {
        _radian = rad;
        this.transform.rotation = Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1));
    }
}
