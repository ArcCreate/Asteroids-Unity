using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    //variables
    public int lives = 3;
    public bool isInvincible = false;
    public float invincibilityDuration = 2f;
    private bool isDead = false;
    public float blinkInterval;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Assume layer 7 is Asteroids or anything damaging
        if (collision.gameObject.layer == 7)
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        if (isInvincible || isDead)
            return;

        lives--;

        if (lives <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvincibilityRoutine());
        }
    }

    public void AddLife()
    {
        lives++;
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Player died.");
        // disable movement or show game over screen
        gameObject.SetActive(false);
        // Or: Destroy(gameObject);
    }

    private System.Collections.IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;

        // Optional flash effect:
        float timer = 0f;
        while (timer < invincibilityDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            timer += 0.2f;
        }
        spriteRenderer.enabled = true;

        isInvincible = false;
    }
}
