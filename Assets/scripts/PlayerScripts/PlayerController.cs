using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    private PlayerInput playerInput;
    private Rigidbody2D body;
    private Vector3 moveVec;
    // Start is called before the first frame update

    void Awake()
    {
        playerInput = new PlayerInput();
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //var horizontal = Mathf.RoundToInt(playerInput.Player.Move.ReadValue<Vector2>().x);
        //var velocityX = speed * horizontal;
        body.velocity = moveVec * speed;
    }


    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        moveVec = new Vector3(inputVec.x, inputVec.y, 0);
    }
}
