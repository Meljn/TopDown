using Entities;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    [SerializeField] private HealthComponent m_health;
    [SerializeField] private EnemyData m_enemyData;

    private EnemyData m_data;

    public HealthComponent health => m_health;

    // TODO Add HealthComponent
    // TODO Add Movement
    // TODO Add AttackComponent


    public void Awake()
    {
        Initialize(m_enemyData);
    }
    private void OnEnable()
    {
        m_health.ValueChanged += () =>
        {
            Debug.Log($"Health changed: {m_health.Value}");
        };

        m_health.Died += OnDied;
    }

    private void OnDisable()
    {
        m_health.Died -= OnDied;
    }

    public void Initialize(EnemyData data)
    {
        m_data = data;
        m_health.Initialize(data.health);
    }

    private void OnDied()
    {
       Died?.Invoke(this);
    }
    
}
