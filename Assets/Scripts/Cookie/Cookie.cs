using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    public void OnClick()
    {        
        GameManager.Instance.money++; // money 증가

        // 파티클 시스템 위치 설정
        ParticleSystem particleSystem = GameManager.Instance._particleSystem;

        // 파티클 효과 설정 및 재생
        ParticleSystem.EmissionModule em = particleSystem.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(5)));
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startSpeedMultiplier = 10f;
        particleSystem.Play();
    }
}
