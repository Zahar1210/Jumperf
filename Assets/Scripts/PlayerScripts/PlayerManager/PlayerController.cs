using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //поля для управлления компьютером
    [SerializeField] private TypeControl typeControl;
    [SerializeField] private float currentForce = 0.1f;
    [SerializeField] private float currentDistance;
    [SerializeField] private float minMappedValue;
    [SerializeField] private float maxMappedValue;
    [SerializeField] private float maxDistance;
    [SerializeField] private float maxForce;
    private bool _isDirection;
    private int _moveDirection;
    private Vector2 _screenCenter;

    //поля для управления телефоном
    private Rigidbody2D _rb;
    public float forcePlay;
    public float filter;
    
    private Vector2 _acceleration;
    private PlayerBehaviour _player;

    private enum TypeControl
    {
        Computer,
        Phone
    }

    private void Start()
    {
        _player = PlayerBehaviour.Instance;
        _rb = GetComponent<Rigidbody2D>(); 
        _screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void FixedUpdate()
    {
        if (typeControl == TypeControl.Computer)
        {
            ComputerControl();
        }
        else
        {
            PhoneControl();
        }
    }

    private void PhoneControl()
    {
        _acceleration = Input.acceleration;
        _acceleration = LowPassFilter(_acceleration, filter);
        if (_player.UseReverseBonus)
            ApplyForce(-_acceleration.x);
        else
            ApplyForce(_acceleration.x);
    }

    private Vector2 LowPassFilter(Vector2 current, float factor)
    {
        return current * factor + _acceleration * (1.0f - factor);
    }

    private void ApplyForce(float force)
    {
        _rb.velocity = new Vector2(force * forcePlay, _rb.velocity.y);
    }
    
    // private void PhoneControl()
    // {
    //     _acceleration = Input.acceleration;
    //     _acceleration = LowPassFilter(_acceleration, filter);
    //
    //     if (Input.GetKey(KeyCode.C)) 
    //     {
    //         ApplyForce(-_acceleration.x); 
    //     }
    //     else
    //     {
    //         ApplyForce(_acceleration.x); 
    //     }
    // }// пока так 
    private void ComputerControl()
    {
        Vector2 mousePos = Input.mousePosition;

        int moveDirection = MathF.Sign(mousePos.x - _screenCenter.x);
        _moveDirection = moveDirection;

        float distance = MathF.Abs(mousePos.x - _screenCenter.x);
        currentDistance = Remap(distance, 0, maxDistance, minMappedValue, maxMappedValue);

        currentForce = Mathf.Clamp(currentDistance, 0, maxForce);
        currentForce *= _moveDirection;

        float moveAmount = currentForce * Time.deltaTime;
        transform.Translate(new Vector2(moveAmount, 0));
    }

    private float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }
}