using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMuzul : MonoBehaviour
{
    [SerializeField] GameObject _bul;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(_bul.gameObject, transform.position, Quaternion.identity);
            var scr = bullet.GetComponent<BulletController>();
            scr.SetVector(this.transform.right);

        }
    }
}
