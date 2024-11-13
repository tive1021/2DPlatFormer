using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour
{
    [SerializeField] private float bounceHeight = 0.5f; // 튀어오르는 높이
    [SerializeField] private float bounceSpeed = 2f;    // 이동 속도
    private Vector3 originalPosition;                   // 블록의 원래 위치

    protected virtual void Awake()
    {
        originalPosition = transform.position;
    }

    protected IEnumerator Bounce()
    {
        Vector3 targetPosition = originalPosition + new Vector3(0, bounceHeight, 0); // 목표 위치 설정

        // 블록이 위로 튀어오르는 과정
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, bounceSpeed * Time.deltaTime);
            yield return null;
        }

        // 블록이 원래 위치로 돌아오는 과정
        while (Vector3.Distance(transform.position, originalPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, bounceSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
