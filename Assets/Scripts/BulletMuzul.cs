using UnityEngine;

public class BulletMuzul : MonoBehaviour
{
    [SerializeField] GameObject _normal;
    float _radian = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullet = Instantiate(_normal.gameObject, transform.position, transform.rotation);
            var scr = bullet.GetComponent<BulletController>();
            scr.SetVector(this.transform.right);

        }
    }

    public void SetTargetRadian(float rad)
    {
        _radian = rad;

        this.transform.rotation = Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1));
    }
}