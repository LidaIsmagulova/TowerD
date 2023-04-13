using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;
    [SerializeField] private int difficultyRamp = 1;

    private int _currentHitPoints;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        _currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        _currentHitPoints--;
        if (_currentHitPoints <= 0)
        {
            _enemy.RewardGold();
            maxHitPoints += difficultyRamp;
            gameObject.SetActive(false);
        }
    }
}
