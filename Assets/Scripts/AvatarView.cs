using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarView : MonoBehaviour
{
    public float speed = 1;
    public Avatar avatar;

    private bool _isMouseDown = false;
    private Vector3 _lastMoveDir = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (avatar == null)
            return;
        if (avatar.isPlayer())
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isMouseDown = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _isMouseDown = false;
            }
            KBEngine.Event.fireIn("updatePlayer", gameObject.transform.position.x, gameObject.transform.position.z, gameObject.transform.position.y, gameObject.transform.rotation.eulerAngles.y);
        }
        else
        {
            transform.position = new Vector3(avatar.position.x, avatar.position.z, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        if (avatar == null)
            return;
        if (avatar.isPlayer())
        {
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
            transform.position = transform.position + _lastMoveDir * speed * 0.1f;
        }
    }
}
