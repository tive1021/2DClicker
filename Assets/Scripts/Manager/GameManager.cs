using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{
    public BigInteger money = 0;
    public BigInteger moneyIncrease = 1;
    public float autoClickRate = 0;
    public BigInteger autoClickIncrease = 1;
    public TextMeshProUGUI moneyValueLabel;
    public ParticleSystem _particleSystem;

    protected override void Awake()
    {
        base.Awake();
        _particleSystem = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        moneyValueLabel.text = FormatBigInteger(money);
    }

    public string FormatBigInteger(BigInteger amount)
    {
        char format = 'a';
        format--;
        BigInteger formatMoney = amount;

        while (formatMoney / 1000 > 0)
        {
            formatMoney = formatMoney / 1000;
            format++;
        }

        return $"{formatMoney}{format}";
    }
}
