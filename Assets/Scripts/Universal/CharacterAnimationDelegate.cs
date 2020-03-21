using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint;
    public GameObject rightArmAttackPoint;
    public GameObject leftLegAttackPoint;
    public GameObject rightLegAttackPoint;

    public float standUpTimer = 2f;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whooshSound, fallSound, groundHitSound, deathSound;

    private EnemyMovement enemyMovement;

    private void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();

        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovement = GetComponentInParent<EnemyMovement>();
        }
    }

    void LeftArmAttackOn()
    {
        leftArmAttackPoint.SetActive(true);
    }

    void LeftArmAttackOff()
    {
        if (leftArmAttackPoint.activeInHierarchy)
        {
            leftArmAttackPoint.SetActive(false);
        }
    }

    void RightArmAttackOn()
    {
        rightArmAttackPoint.SetActive(true);
    }

    void RightArmAttackOff()
    {
        if (rightArmAttackPoint.activeInHierarchy)
        {
            rightArmAttackPoint.SetActive(false);
        }
    }

    void LeftLegAttackPointOn()
    {
            leftLegAttackPoint.SetActive(true);
    }

    void LeftLegAttackPointOff()
    {
        if (leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);
        }
    }

    void RightLegAttackPointOn()
    {
        rightLegAttackPoint.SetActive(true);
    }

    void RightLegAttackPointOff()
    {
        if (rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);
        }
    }

    void TagLeft_Arm()
    {
        leftArmAttackPoint.tag = Tags.LEFT_ARM_TAG;
    }

    void UntagLeft_Arm()
    {
        leftArmAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void TagLeft_Leg()
    {
        leftLegAttackPoint.tag = Tags.LEFT_LEG_TAG;
    }

    void UntagLeft_Leg()
    {
        leftLegAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void Enemy_StandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTimer);
        animationScript.StandUp();
    }

    public void Attack_SFX()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whooshSound;
        audioSource.Play();
    }

    public void CharacterDeath_SFX()
    {
        audioSource.volume = 1f;
        audioSource.clip = deathSound;
        audioSource.Play();
    }

    public void EnemyKnockedDown_SFX()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }

    public void EnemyHitGround_SFX()
    {
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }

    void DisableMovement()
    {
        enemyMovement.enabled = false;

        transform.parent.gameObject.layer = 0;
    }

    void EnableMovement()
    {
        enemyMovement.enabled = true;

        transform.parent.gameObject.layer = 9;
    }
}
