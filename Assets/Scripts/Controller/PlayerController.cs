using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // SpriteRenderer 변수 추가
    public float moveSpeed = 5f; // 이동 속도
    public float jumpForce = 5f; // 점프 힘
    public LayerMask groundLayer; // 땅의 레이어 (점프 가능 여부 체크용)

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // SpriteRenderer 컴포넌트 가져오기
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        spriteRenderer.flipX = movement.x < 0;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            animator.SetBool("IsMoving", true);
            movement = context.ReadValue<Vector2>(); // 입력 값 저장
        }
        else if (context.canceled)
        {
            animator.SetBool("IsMoving", false);
            movement = Vector2.zero; // 이동 중지
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return true;
    }
}
