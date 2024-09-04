using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _spawnTime = 1.0f;

    float _spawntimer = 0.0f;
    GameObject _target;

    private void Update()
    {
        if (_target) return;

        _spawntimer += Time.deltaTime;
        if (_spawntimer >= _spawnTime)
        {
            _spawntimer = 0.0f;
            _target = GameObject.Instantiate(_prefab, this.transform.position, this.transform.rotation);
        }
    }
}