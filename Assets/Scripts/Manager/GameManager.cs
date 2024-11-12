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
        BigInteger formatAmount = amount;
        BigInteger demicalAmount = 0;

        // 천 단위로 나누면서 알파벳 포맷을 하나씩 증가
        while (formatAmount >= 1000)
        {
            demicalAmount = formatAmount % 1000;
            formatAmount /= 1000;
            format++;
        }

        string demical = demicalAmount.ToString();
        
        switch (demical.Length)
        {
            case 1:
                demical = $"00{demical}";
                break;
            case 2:
                demical = $"0{demical}";
                break;
        }

        if (demical == "000")
        {
            demical = "";
        }

        // 소수점 첫째 자리까지 포함한 최대 4자리 표현
        string result = $"{formatAmount}.{demical}";
        result = result.Length > 5 ? result.Substring(0, 5) : result;

        return $"{result}{format}";
    }
}
