using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] Vector3 _shotpower;
    [SerializeField] BulletType _bulletType;
    int frameCount = 0;             // フレームカウント
    const int deleteFrame = 200;    // 削除フレーム

    public enum BulletType
    {
        Invalid,
        Player,
        Enemy,
    }

    public void SetVector(Vector3 vec)
    {
        _shotpower = vec * 10 * _shotpower.magnitude;
    }
    bool isHitRect(Transform target)
    {
        if (Mathf.Abs(this.transform.position.x - target.transform.position.x) < (target.localScale.x + this.transform.localScale.x) / 2 &&
           Mathf.Abs(this.transform.position.y - target.transform.position.y) < (target.localScale.y + this.transform.localScale.y) / 2)
        {
            return true;
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += _shotpower * Time.deltaTime;
        //var enemise = GameObject.FindObjectsOfType<Enemy>();


        switch (_bulletType)
        {
            case BulletType.Player:
                {
                    foreach (var enemy in GameManager.Instance.Enemies)
                    {
                        if (isHitRect(enemy.transform))
                        {
                            enemy.Damage();
                            Destroy(gameObject);
                        }
                    }
                }
                break;

            case BulletType.Enemy:
                {
                    var player = GameManager.Instance.Player;
                    if (isHitRect(player.transform))
                    {
                        player.Damage();
                        Destroy(gameObject);
                    }
                }
                break;
        }
        if (++frameCount > deleteFrame)
        {
            Destroy(this.gameObject );
        }
    }
}