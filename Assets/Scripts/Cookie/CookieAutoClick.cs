using System.Collections;
using UnityEngine;

public class CookieAutoClick : MonoBehaviour
{
    private Cookie cookie; // Cookie ��ũ��Ʈ ����
    private Coroutine coroutine;

    private void Awake()
    {
        // Cookie ������Ʈ ��������
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
            StopCoroutine(AutoClickCoroutine()); //�������� �ڷ�ƾ�� �ִ��� null ���θ� �ľ��ؼ� ����
        }
    }

    private IEnumerator AutoClickCoroutine()
    {
        while (GameManager.Instance.autoClickRate > 0)
        {
            cookie.OnClick(GameManager.Instance.autoClickIncrease);
            yield return new WaitForSeconds(10 / GameManager.Instance.autoClickRate); // ������ �������� �ݺ� ����
        }
    }
}
