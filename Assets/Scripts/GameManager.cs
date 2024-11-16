using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = new GameManager();
    public static GameManager Instance => _instance;
    private GameManager() { }

    Player _player;
    List<Enemy> _enemies = new List<Enemy>();
    public Player Player => _player;
    public List<Enemy> Enemies => _enemies;



    public void Register(Player p) 
    { 
        _player = p; 
    }
    public void Register(Enemy e) 
    { 
        _enemies.Add(e);
    }
    public void Remove(Enemy e)
    {
        _enemies.Remove(e);
    }
}
