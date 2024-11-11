using System.Collections;
using System.Collections.Generic;
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
        MoneyIncrease();

        animator.SetTrigger("Click");
        PlayParticle();
    }

    private void MoneyIncrease()
    {
        GameManager.Instance.money += GameManager.Instance.moneyIncrease; // money 증가
    }

    private void PlayParticle()
    {
        ParticleSystem particleSystem = GameManager.Instance._particleSystem;

        // 파티클 시스템 랜덤 위치 설정
        Vector2 randomInsideCircle = Random.insideUnitCircle * radius;
        Vector3 position = new Vector3(randomInsideCircle.x, randomInsideCircle.y, 0f) + transform.position;
        particleSystem.transform.position = position;

        // 파티클 효과 설정 및 재생
        ParticleSystem.EmissionModule em = particleSystem.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, 5));
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startSpeedMultiplier = 10f;
        particleSystem.Play();
    }
}
