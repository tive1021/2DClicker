using System.Collections;
using UnityEngine;

public class CookieAutoClick : MonoBehaviour
{
    public float autoClickInterval = 1.0f; // 자동 클릭 간격 (초 단위로 설정 가능)
    private bool isAutoClicking = false; // 자동 클릭 활성화 여부
    private Cookie cookie; // Cookie 스크립트 참조

    private void Awake()
    {
        // Cookie 컴포넌트 가져오기
        cookie = GetComponent<Cookie>();
    }

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
        while (isAutoClicking && autoClickInterval > 0)
        {
            AutoClick();
            yield return new WaitForSeconds(100 / autoClickInterval); // 지정된 간격으로 반복 실행
        }
    }

    private void AutoClick()
    {
        // Cookie의 OnClick 메서드를 호출하여 클릭 동작 수행
        if (cookie != null)
        {
            cookie.OnClick();
        }
    }
}
