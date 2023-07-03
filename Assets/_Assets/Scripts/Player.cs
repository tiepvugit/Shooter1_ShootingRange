using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField]
    private PlayerUi _playerUi;
    [SerializeField]
    private Transform _playerFoot;
    [SerializeField]
    private Health _playerHealth;


    public Transform PlayerFoot { get => _playerFoot; set => _playerFoot = value; }
    public PlayerUi PlayerUi { get => _playerUi; set => _playerUi = value; }
    public Health PlayerHealth { get => _playerHealth; set => _playerHealth = value; }
}
