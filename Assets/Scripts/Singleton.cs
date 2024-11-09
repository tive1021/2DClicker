using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // 현재 씬에서 타입 T를 찾는다.
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    // T가 없으면 새로운 게임 오브젝트를 생성하고 추가한다.
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).Name + " (Singleton)";
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        // 인스턴스가 이미 존재하면 삭제
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // 중복 인스턴스 제거
        }
    }
}
