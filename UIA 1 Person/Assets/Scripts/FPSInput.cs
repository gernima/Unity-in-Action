using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 6f;
    public const float basespeed = 6.0f;

    private CharacterController _characterController;
    private float gravity = -9.8f;

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnSpeedChanged(float value)
    {
        speed = basespeed * value;
    }
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float deltaX = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaZ = -Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
