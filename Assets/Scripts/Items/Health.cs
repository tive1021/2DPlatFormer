using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour, IItem
{
    [SerializeField] float moveSpeed = 10f;    // 이동 속도

    private Rigidbody2D rb;
    private Collider2D col;

    private bool isMoving = false;  // 이동 활성화 여부

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rb.gravityScale = 0f;
        col.isTrigger = true;
    }

    public void GetItem()
    {
        // GetItem이 호출되면 이동 시작
        if (!isMoving)
        {
            isMoving = true;
            rb.gravityScale = 1f;
            col.isTrigger = false;
            transform.position += Vector3.up;
            StartCoroutine(MoveRoutine()); // 코루틴으로 이동 시작
        }
    }

    private IEnumerator MoveRoutine()
    {
        while (isMoving)
        {
            // 오른쪽으로 지속적으로 이동
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            yield return null; // 한 프레임 대기
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어와 충돌 시
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player.Instance.condition.Heal(); // 플레이어 회복
            Destroy(gameObject); // 아이템 제거
        }
    }
}
