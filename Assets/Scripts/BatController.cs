using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BatController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float axisValue = Input.GetAxis("Horizontal");

        if (axisValue != 0)
        {
            //Check for borders
            if ((axisValue < 0 && transform.position.x > -1.95f) ||
                (axisValue > 0 && transform.position.x < 1.95))
                //Move bat
                transform.Translate(moveSpeed * axisValue, 0, 0);
            else
                //Set max translate position
                transform.position = new Vector3(1.95f * Mathf.Sign(axisValue), transform.position.y, transform.position.z);
        }

    }
}
