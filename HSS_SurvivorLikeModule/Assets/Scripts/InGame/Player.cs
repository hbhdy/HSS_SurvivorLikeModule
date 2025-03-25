using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;

    private Vector2 inputVec2;
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public Vector2 GetInputVector2() => inputVec2;

    public Rigidbody2D GetRigid() => rigid;

    private void OnMove(InputValue value)
    {
        inputVec2 = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = inputVec2 * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
    }


    //private void LateUpdate()
    //{
    //}
}
