using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarView : MonoBehaviour
{
    private bool _isMouseDown = false;
    private Vector3 _lastMoveDir = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isMouseDown = false;
        }
        if (_isMouseDown)
        {
            Vector3 movement = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            movement.z = 0.0f;
            if (movement.magnitude <= 1.0)
            {
                _lastMoveDir = Vector3.zero;
                return;
            }
            movement.Normalize();
            _lastMoveDir = movement;
        }
        transform.position = transform.position + _lastMoveDir;
    }
}
