using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller2 : MonoBehaviour
{
    [Header("PlayerController Settings")]

    public int forceJump;
    public float speed = 20f;
    public float playerMaxVelo = 3f;
    public float timeJump;
    public float walkSpeed;
    public float runSpeed;
    public bool desactivatedForVehicule = true;
    bool _ground = true;

    public Camera cam;
    Rigidbody _rb;
    CharacterController _cc;

    float _mouseX;
    float _mouseY;
    float _mouseSensibility = 10f;
    float _mouseAngleLock = 30f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        _mouseX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _mouseSensibility;
        _mouseY = _mouseY - Input.GetAxis("Mouse Y") * _mouseSensibility;
        transform.localEulerAngles = new Vector3(0, _mouseX, 0);


        if (desactivatedForVehicule)
        {
            cam.transform.localEulerAngles = new Vector3(_mouseY, 0, 0);
            _mouseY = Mathf.Clamp(_mouseY, -_mouseAngleLock, _mouseAngleLock);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _ground)
        {
            _rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            _ground = false;
        }
    }

    void FixedUpdate()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector3 newvelocity = Vector3.up * _rb.velocity.y;
        newvelocity.x = Input.GetAxis("Horizontal") * speed;
        newvelocity.z = Input.GetAxis("Vertical") * speed;
        _rb.velocity = transform.TransformDirection(newvelocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _ground = true;
    }

}

