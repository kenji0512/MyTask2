using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Player _player = null;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * 5 * Time.deltaTime;

        float xDis = this.transform.position.x - _player.transform.transform.position.x;
        float xScl = _player.transform.localScale.x + this.transform.localScale.x;
        float yDis = this.transform.position.y - _player.transform.transform.position.y;
        float yScl = _player.transform.localScale.y + this.transform.localScale.y;

        if (Mathf.Abs(xDis) < xScl / 2 && Mathf.Abs(yDis) < yScl / 2)
        {
            CurrentHP currentHP = _player.GetComponent<CurrentHP>();
            currentHP.Damage();
            Destroy(gameObject);
        }
    }
}
