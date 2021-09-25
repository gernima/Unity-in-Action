using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] private Vector3 dPos;
    [SerializeField] private float speed = 15f;
    private bool _open;

    public void Activate()
    {
        if (!_open)
        {
            Vector3 pos = transform.position + dPos;
            transform.position = Vector3.Lerp(transform.position, pos, speed);
            _open = true;
        }
    }
    public void Deactivate()
    {
        if (_open)
        {
            Vector3 pos = transform.position - dPos;
            transform.position = Vector3.Lerp(transform.position, pos, speed);
            _open = false;
        }
    }
}
