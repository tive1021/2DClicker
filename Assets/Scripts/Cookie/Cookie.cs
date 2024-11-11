using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cookie : MonoBehaviour
{
    [SerializeField] float radius;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnClick()
    {
        MoneyIncrease(GameManager.Instance.moneyIncrease);

        animator.SetTrigger("Click");
        PlayParticle();
    }

    public void OnClick(BigInteger amount)
    {
        MoneyIncrease(amount);

        animator.SetTrigger("Click");
        PlayParticle();
    }

    private void MoneyIncrease(BigInteger amount)
    {
        GameManager.Instance.money += GameManager.Instance.moneyIncrease; // money ����
    }

    private void PlayParticle()
    {
        ParticleSystem particleSystem = GameManager.Instance._particleSystem;

        // ��ƼŬ �ý��� ���� ��ġ ����
        UnityEngine.Vector2 randomInsideCircle = Random.insideUnitCircle * radius;
        UnityEngine.Vector3 position = new UnityEngine.Vector3(randomInsideCircle.x, randomInsideCircle.y, 0f) + transform.position;
        particleSystem.transform.position = position;

        // ��ƼŬ ȿ�� ���� �� ���
        ParticleSystem.EmissionModule em = particleSystem.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, 5));
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startSpeedMultiplier = 10f;
        particleSystem.Play();
    }
}
