using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class UpgradeCookie : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI increaseClickText;
    [SerializeField] TextMeshProUGUI autoClickCooldownText;
    [SerializeField] TextMeshProUGUI increaseAutoClickText;
    BigInteger increaseClickMoney = 100;
    BigInteger autoClickCooldownMoney = 1000;
    BigInteger increaseAutoClickMoney = 1000;

    CookieAutoClick auto;

    public void Awake()
    {
        auto = GameObject.FindGameObjectWithTag("Cookie").GetComponent<CookieAutoClick>();
    }

    public void IncreaseClick()
    {
        if (GameManager.Instance.money > increaseClickMoney)
        {
            GameManager.Instance.money -= increaseClickMoney;

            GameManager.Instance.moneyIncrease++;
            increaseClickMoney += 100;
            increaseClickText.text = $"{GameManager.Instance.FormatBigInteger(increaseClickMoney)}";
        }
    }

    public void AutoClickCooldown()
    {
        if (GameManager.Instance.money > increaseClickMoney)
        {
            GameManager.Instance.money -= autoClickCooldownMoney;

            auto.StopAutoClick();
            GameManager.Instance.autoClickRate++;
            auto.StartAutoClick();
            autoClickCooldownMoney *= 1000;
            autoClickCooldownText.text = $"{GameManager.Instance.FormatBigInteger(autoClickCooldownMoney)}";
        }
    }

    public void IncreaseAutoClick()
    {
        if (GameManager.Instance.money > increaseClickMoney)
        {
            GameManager.Instance.money -= increaseAutoClickMoney;

            auto.StopAutoClick();
            GameManager.Instance.autoClickIncrease++;
            auto.StartAutoClick();
            increaseAutoClickMoney += 1000;
            increaseAutoClickText.text = $"{GameManager.Instance.FormatBigInteger(increaseAutoClickMoney)}";
        }
    }
}
