using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDie;

    public bool isPlayer;

    private void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDie)
        {
            return;
        }

        health -= damage;

        // display health UI

        if (health <= 0f)
        {
            animationScript.Death();
            characterDie = true;

            // if is player deactivate enemy script
            if (isPlayer)
            {
            }

            return;
        }

        if (isPlayer)
        {
            if (knockDown)
            {
                if (Random.Range(0, 5) == 4)
                {
                    animationScript.KnockDown();
                }
                else
                {
                    if (Random.Range(0, 3) > 1)
                    {
                        animationScript.Hit();
                    }
                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }

        if (!isPlayer)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }
    }
}