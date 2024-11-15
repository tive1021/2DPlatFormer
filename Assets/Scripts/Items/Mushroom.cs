using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour, IItem
{
    [SerializeField] float distance = 1f;   // 이동 거리
    [SerializeField] float moveSpeed = 10f;   // 이동 속도
 
    Vector3 targetPosition;

    void Awake()
    {
        targetPosition = transform.position + new Vector3(0, distance, 0);
    }

    public void GetItem()
    {
        GameManager.Instance.coinAmount++;
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        // 목표 위치에 도달할 때까지 이동
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;  // 다음 프레임까지 대기
        }

        Destroy(gameObject); // 오브젝트 삭제
    }
}
