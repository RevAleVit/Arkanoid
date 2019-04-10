using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    [Range(0.05f, 0.3f)]
    [SerializeField] private float moveSpeed = 0.2f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float axisValue = 0;
#if UNITY_ANDROID || UNITY_IOS
        //Check screen touch
        if (Input.touchCount > 0)
        {
            //Set axis value -1 if touch left screen side, else set 1
            axisValue = Input.touches[0].position.x < Screen.currentResolution.width / 2 ? -1 : 1;
        }
        else
            axisValue = 0;
#endif
#if UNITY_EDITOR
        axisValue = Input.GetAxis("Horizontal");
        //Hard set -1 or 1
        axisValue = axisValue != 0 ? Mathf.Sign(axisValue) : 0;
#endif

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
