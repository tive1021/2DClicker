using System.Collections;
using UnityEngine;

public class CookieAutoClick : MonoBehaviour
{
    public float autoClickInterval = 1.0f; // �ڵ� Ŭ�� ���� (�� ������ ���� ����)
    private bool isAutoClicking = false; // �ڵ� Ŭ�� Ȱ��ȭ ����

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
        while (isAutoClicking)
        {
            AutoClick();
            yield return new WaitForSeconds(autoClickInterval); // ������ �������� �ݺ� ����
        }
    }

    private void AutoClick()
    {
        GameManager.Instance.money++; // money ����
        ParticleSystem particleSystem = GameManager.Instance._particleSystem;

        // ��ƼŬ ��ġ �� ����
        particleSystem.transform.position = new Vector3(0, 2, 0); // ���ϴ� ��ġ�� ����
        particleSystem.Play();
    }
}
