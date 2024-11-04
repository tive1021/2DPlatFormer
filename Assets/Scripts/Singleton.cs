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
                // ���� ������ Ÿ�� T�� ã�´�.
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    // T�� ������ ���ο� ���� ������Ʈ�� �����ϰ� �߰��Ѵ�.
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
        // �ν��Ͻ��� �̹� �����ϸ� ����
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� ������Ʈ ����
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ� ����
        }
    }
}
