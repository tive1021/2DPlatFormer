using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // SpriteRenderer ���� �߰�
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float jumpForce = 5f; // ���� ��
    public LayerMask groundLayer; // ���� ���̾� (���� ���� ���� üũ��)

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // SpriteRenderer ������Ʈ ��������
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
            movement = context.ReadValue<Vector2>(); // �Է� �� ����
        }
        else if (context.canceled)
        {
            animator.SetBool("IsMoving", false);
            movement = Vector2.zero; // �̵� ����
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
