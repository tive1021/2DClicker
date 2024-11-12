using System.Collections;
using UnityEngine;

public class CookieAutoClick : MonoBehaviour
{
    private Cookie cookie; // Cookie 스크립트 참조
    private Coroutine coroutine;

    private void Awake()
    {
        // Cookie 컴포넌트 가져오기
        cookie = GetComponent<Cookie>();
    }

    private void Start()
    {
        StartAutoClick();
    }

    public void StartAutoClick()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(AutoClickCoroutine());
        }
    }

    public void StopAutoClick()
    {
        if (coroutine != null)
        {
            StopCoroutine(AutoClickCoroutine()); //실행중인 코루틴이 있는지 null 여부를 파악해서 관리
        }
    }

    private IEnumerator AutoClickCoroutine()
    {
        while (GameManager.Instance.autoClickRate > 0)
        {
            cookie.OnClick(GameManager.Instance.autoClickIncrease);
            yield return new WaitForSeconds(10 / GameManager.Instance.autoClickRate); // 지정된 간격으로 반복 실행
        }
    }
}
