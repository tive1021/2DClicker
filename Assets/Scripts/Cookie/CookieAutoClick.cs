using System.Collections;
using UnityEngine;

public class CookieAutoClick : MonoBehaviour
{
    public float autoClickInterval = 1.0f; // 자동 클릭 간격 (초 단위로 설정 가능)
    private bool isAutoClicking = false; // 자동 클릭 활성화 여부

    private void Start()
    {
        StartAutoClick(); // 스크립트 시작 시 자동 클릭 활성화
    }

    public void StartAutoClick()
    {
        if (!isAutoClicking)
        {
            isAutoClicking = true;
            StartCoroutine(AutoClickCoroutine());
        }
    }

    public void StopAutoClick()
    {
        if (isAutoClicking)
        {
            isAutoClicking = false;
            StopCoroutine(AutoClickCoroutine());
        }
    }

    private IEnumerator AutoClickCoroutine()
    {
        while (isAutoClicking)
        {
            AutoClick();
            yield return new WaitForSeconds(autoClickInterval); // 지정된 간격으로 반복 실행
        }
    }

    private void AutoClick()
    {
        GameManager.Instance.money++; // money 증가
        ParticleSystem particleSystem = GameManager.Instance._particleSystem;

        // 파티클 위치 및 설정
        particleSystem.transform.position = new Vector3(0, 2, 0); // 원하는 위치에 설정
        particleSystem.Play();
    }
}
