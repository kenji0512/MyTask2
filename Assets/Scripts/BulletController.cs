using UnityEngine;

public class BulletController : MonoBehaviour
{//いろいろ自分で他のやり方で試したがうまくいかず…
    [SerializeField] LayerMask _layerMask;
    [SerializeField] Vector3 _shot;
    int frameCount = 0;             // フレームカウント
    const int deleteFrame = 200;    // 削除フレーム

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