using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float duration = 0.1f; // Inspector에서 보이도록 일반 필드로 정의

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // duration을 읽는 public 메서드 추가
    public float GetDuration()
    {
        return duration;
    }
}
