using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{
    public BigInteger money = 0;
    public TextMeshProUGUI moneyValueLabel;
    public ParticleSystem _particleSystem;

    protected override void Awake()
    {
        base.Awake();
        _particleSystem = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        moneyValueLabel.text = money.ToString();
    }

}
