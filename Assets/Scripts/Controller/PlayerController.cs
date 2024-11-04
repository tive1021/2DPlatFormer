using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = Player.Instance;
        player.Move += OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.started || context.performed) // �Է��� ���۵Ǿ��ų� ����� ���
        {
            Vector2 movement = context.ReadValue<Vector2>(); // �̵� ���� �б�
            // �̵� ���� ó��
            Debug.Log($"Player is moving: {movement}");
        }
    }
}
