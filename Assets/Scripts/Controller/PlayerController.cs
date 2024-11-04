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
        if (context.started || context.performed) // 입력이 시작되었거나 수행된 경우
        {
            Vector2 movement = context.ReadValue<Vector2>(); // 이동 벡터 읽기
            // 이동 로직 처리
            Debug.Log($"Player is moving: {movement}");
        }
    }
}
