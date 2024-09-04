using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : CurrentHP
{
    [SerializeField] Player _player;
    [SerializeField] GameObject _prefab;
    [SerializeField] float _searchRadius = 200.0f;
    [SerializeField] float _interval = 1.0f;

    float _shottimer = 0.0f;

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
        GameManager.Instance.Register(this);
    }

    void Update()
    {
        if (_hp <= 0)
        {
            GameManager.Instance.Remove(this);
            Destroy(gameObject);
            return;
        }

        Vector3 sub = _player.transform.position - this.transform.position;
        float len = (sub.x * sub.x) + (sub.y * sub.y);
        if (len < _searchRadius * _searchRadius)
        {
            _shottimer += Time.deltaTime;
            if (_shottimer > _interval)
            {
                _shottimer -= _interval;

                Instantiate(_prefab, this.transform.position + new Vector3(-0.5f, 0, 0), this.transform.rotation);
            }
        }//’e
        else
        {
            _shottimer = 0.0f;
        }
    }
}