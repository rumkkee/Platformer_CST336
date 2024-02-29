using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.Log("Clicked!");
            DrawClickerCast();
        }
    }

    private void DrawClickerCast()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        float startingZPos = -2f;
        float length = 4f;
        mousePos = new Vector3(mousePos.x, mousePos.y, startingZPos);

        //Debug.Log(mousePos);

        RaycastHit hitInfo;

        if(Physics.Raycast(mousePos, Vector3.forward, out hitInfo))
        {
            Debug.DrawRay(mousePos, Vector3.forward * length, Color.red, 5f);

            InteractableBlock interactableBlock = hitInfo.collider.gameObject.GetComponent<InteractableBlock>();
            if (interactableBlock != null)
            {
                Debug.Log("Brick hit!");
                interactableBlock.OnHit();
            }
        }
    }
}
