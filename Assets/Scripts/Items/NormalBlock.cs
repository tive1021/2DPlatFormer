using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBlock : BlockBase
{    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 "Player" 태그를 가진 경우에만 실행
        if (collision.gameObject.CompareTag("Player"))
        {
            // 충돌 위치가 블록보다 아래에 있는지 확인
            if (collision.transform.position.y < transform.position.y)
            {
                // 블록이 튀었다가 다시 돌아옴
                StartCoroutine(base.Bounce());
            }
        }
    }
}
