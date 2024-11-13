using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlock : BlockBase
{
    [SerializeField] IItem containItem;
    bool isContainingItem;

    [SerializeField] Sprite emptyBlock;
    SpriteRenderer spriteRenderer;

    protected override void Awake()
    {
        base.Awake();

        spriteRenderer = GetComponent<SpriteRenderer>();
        containItem = GetComponentInChildren<IItem>();
        if(containItem != null)
            isContainingItem = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 "Player" 태그를 가진 경우에만 실행
        if (collision.gameObject.CompareTag("Player") && isContainingItem)
        {
            // 충돌 위치가 블록보다 아래에 있는지 확인
            if (collision.transform.position.y < transform.position.y)
            {
                // 아이템 획득
                containItem.GetItem();
                // 빈 블록으로 스프라이트 교체
                spriteRenderer.sprite = emptyBlock;
                // 블록이 튀었다가 다시 돌아옴
                StartCoroutine(base.Bounce());
                isContainingItem = false;
            }
        }
    }
}
