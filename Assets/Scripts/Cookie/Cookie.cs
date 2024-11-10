using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    public void OnClick()
    {        
        GameManager.Instance.money++; // money ����

        // ��ƼŬ �ý��� ��ġ ����
        ParticleSystem particleSystem = GameManager.Instance._particleSystem;

        // ��ƼŬ ȿ�� ���� �� ���
        ParticleSystem.EmissionModule em = particleSystem.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(5)));
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startSpeedMultiplier = 10f;
        particleSystem.Play();
    }
}
