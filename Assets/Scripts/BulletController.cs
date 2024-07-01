using UnityEngine;

public class BulletController : MonoBehaviour
{//���낢�뎩���ő��̂����Ŏ����������܂��������c
    [SerializeField] LayerMask _layerMask;
    [SerializeField] Vector3 _shot;
    int frameCount = 0;             // �t���[���J�E���g
    const int deleteFrame = 200;    // �폜�t���[��

    public void SetVector(Vector3 vec)
    {
        _shot = vec * 10 * _shot.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _shot * Time.deltaTime;
        if (++frameCount > deleteFrame)
        {
            Destroy( this.gameObject );
        }
    }
}