using System.Numerics;
using TMPro;
using UnityEngine;

public class UpgradeCookie : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI increaseClickText;
    [SerializeField] TextMeshProUGUI autoClickCooldownText;
    [SerializeField] TextMeshProUGUI increaseAutoClickText;
    BigInteger increaseClickCost = 100;
    BigInteger autoClickCooldownCost = 1000;
    BigInteger increaseAutoClickCost = 1000;

    CookieAutoClick auto;

    public void Awake()
    {
        auto = GameObject.FindGameObjectWithTag("Cookie").GetComponent<CookieAutoClick>();
    }

    public void IncreaseClick()
    {
        if (GameManager.Instance.money > increaseClickCost)
        {
            GameManager.Instance.money -= increaseClickCost;

            GameManager.Instance.moneyIncrease++;
            increaseClickCost += 100;
            increaseClickText.text = $"{GameManager.Instance.FormatBigInteger(increaseClickCost)}";
        }
    }

    public void AutoClickCooldown()
    {
        if (GameManager.Instance.money > increaseClickCost)
        {
            GameManager.Instance.money -= autoClickCooldownCost;

            auto.StopAutoClick();
            GameManager.Instance.autoClickRate++;
            auto.StartAutoClick();
            autoClickCooldownCost *= 1000;
            autoClickCooldownText.text = $"{GameManager.Instance.FormatBigInteger(autoClickCooldownCost)}";
        }
    }

    public void IncreaseAutoClick()
    {
        if (GameManager.Instance.money > increaseClickCost)
        {
            GameManager.Instance.money -= increaseAutoClickCost;

            auto.StopAutoClick();
            GameManager.Instance.autoClickIncrease++;
            auto.StartAutoClick();
            increaseAutoClickCost += 1000;
            increaseAutoClickText.text = $"{GameManager.Instance.FormatBigInteger(increaseAutoClickCost)}";
        }
    }
}
