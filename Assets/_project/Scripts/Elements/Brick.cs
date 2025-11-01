using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int startHealth;
    private int _currentHealth;

    public TextMeshPro healthTMP;

    private void Start()
    {
        _currentHealth = startHealth;
    }

    public void GetHit(int damage)
    {
        _currentHealth -= damage;
        healthTMP.text = _currentHealth.ToString();

        transform.DOScale(1.2f, .1f).SetLoops(2, LoopType.Yoyo);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
