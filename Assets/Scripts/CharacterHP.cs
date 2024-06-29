using UnityEngine;

public class CharacterHP : MonoBehaviour
{
    [SerializeField] protected int _hp;
    public int HP => _hp;

    public void Damage()
    {
        _hp--;
        if (_hp <= 0)
        {
            _hp = 0;
        }
    }
}