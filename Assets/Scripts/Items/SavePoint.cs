using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private Animator animator;
    private int isSavedHash;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isSavedHash = Animator.StringToHash("IsSaved"); // "IsSaved" 문자열을 해시 값으로 변환
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO : 플레이어 스폰 위치를 여기로 변경
        animator.SetTrigger(isSavedHash); // 해시 값을 사용
    }
}
