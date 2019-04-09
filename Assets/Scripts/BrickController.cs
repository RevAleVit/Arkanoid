using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private int countHealth = 1;

    private int healthLeft;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        healthLeft = countHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(1);
    }

    private void TakeDamage(int damage)
    {
        healthLeft -= damage;

        if (healthLeft <= 0)
            Destroy(gameObject);
        else if (spriteRenderer)
            spriteRenderer.color -= new Color(0, 0, 0, 0.6f * ((float)healthLeft / (float)countHealth)); //Decrease value in alpha chanel for adding some transparent to brik
    }
}
