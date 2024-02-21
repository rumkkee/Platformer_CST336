using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    public float moveSpeed;
    private void Update()
    {
        float horizMovement = Input.GetAxis("Horizontal");
        if(horizMovement != 0)
        {
            Vector3 movement = new Vector3(transform.position.x + (horizMovement * moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            transform.position = movement;
        }
    }
}
