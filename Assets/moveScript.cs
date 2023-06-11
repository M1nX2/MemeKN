using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private float playerSpeed = 2.0f;

    private void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _controller.Move(playerSpeed * Time.deltaTime * move);

        if (move != Vector3.zero)
        {
            //gameObject.transform.forward = move;
        }
        

    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);

        if (_controller.collisionFlags == CollisionFlags.Sides)
        {

            Debug.DrawRay(hit.point, hit.normal, Color.red, 2f);
        }
    }
}