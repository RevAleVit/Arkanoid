using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GUIManager.instance.GameOver(false);
    }
}
