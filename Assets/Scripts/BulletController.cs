using UnityEngine;

public class BulletController : MonoBehaviour
{//いろいろ自分で他のやり方で試したがうまくいかず…
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
        var enemise = GameObject.FindObjectsOfType<Enemy>();
        foreach (var enemy in enemise)
        {
            if (Mathf.Abs(this.transform.position.x - enemy.transform.transform.position.x) < (enemy.transform.localScale.x + this.transform.localScale.x) / 2 &&
                Mathf.Abs(this.transform.position.y - enemy.transform.transform.position.y) < (enemy.transform.localScale.y + this.transform.localScale.y) / 2)
            {
                enemy.Damage();
                Destroy(gameObject);
            }
        }
        if (++frameCount > deleteFrame)
        {
            Destroy( this.gameObject );
        }
    }
}