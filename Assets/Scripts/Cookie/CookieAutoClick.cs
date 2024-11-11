using System.Collections;
using UnityEngine;

public class CookieAutoClick : MonoBehaviour
{
    public float autoClickInterval = 1.0f; // �ڵ� Ŭ�� ���� (�� ������ ���� ����)
    private bool isAutoClicking = false; // �ڵ� Ŭ�� Ȱ��ȭ ����
    private Cookie cookie; // Cookie ��ũ��Ʈ ����

    private void Awake()
    {
        // Cookie ������Ʈ ��������
        cookie = GetComponent<Cookie>();
    }

    private void Start()
    {
        StartAutoClick(); // ��ũ��Ʈ ���� �� �ڵ� Ŭ�� Ȱ��ȭ
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
            yield return new WaitForSeconds(100 / autoClickInterval); // ������ �������� �ݺ� ����
        }
    }

    private void AutoClick()
    {
        // Cookie�� OnClick �޼��带 ȣ���Ͽ� Ŭ�� ���� ����
        if (cookie != null)
        {
            cookie.OnClick();
        }
    }
}
