using System.Collections;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint;
    public GameObject leftLegAttackPoint;
    public GameObject rightArmAttackPoint;
    public GameObject rightLegAttackPoint;

    public float standUpTimer = 2f;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    private EnemyMovement enemyMovement;
    private PlayerMovement playerMovement;

    private ShakeCamera shakeCamera;

    [SerializeField]
    private AudioClip whooshSound, fallSound, groundHitSound, deathSound;

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

    public void EnemyHitGround_SFX()
    {
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }

    public void EnemyKnockedDown_SFX()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }

    private void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();
        audioSource = GetComponent<AudioSource>();
        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();

        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovement = GetComponentInParent<EnemyMovement>();
        }

        if (gameObject.CompareTag(Tags.PLAYER_TAG))
        {
            playerMovement = GetComponentInParent<PlayerMovement>();
        }
    }

    private void DisableMovement()
    {
        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovement.enabled = false; 
        }

        if (gameObject.CompareTag(Tags.PLAYER_TAG))
        {
            playerMovement.enabled = false;
        }

        transform.parent.gameObject.layer = 0;
    }

    private void EnableMovement()
    {
        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovement.enabled = true;
            transform.parent.gameObject.layer = 9;
        }

        if (gameObject.CompareTag(Tags.PLAYER_TAG))
        {
            playerMovement.enabled = true;
            transform.parent.gameObject.layer = 8;
        }

    }

    private void Enemy_StandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    private void LeftArmAttackOff()
    {
        if (leftArmAttackPoint.activeInHierarchy)
        {
            leftArmAttackPoint.SetActive(false);
        }
    }

    private void LeftArmAttackOn()
    {
        leftArmAttackPoint.SetActive(true);
    }

    private void LeftLegAttackPointOff()
    {
        if (leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);
        }
    }

    private void LeftLegAttackPointOn()
    {
        leftLegAttackPoint.SetActive(true);
    }

    private void RightArmAttackOff()
    {
        if (rightArmAttackPoint.activeInHierarchy)
        {
            rightArmAttackPoint.SetActive(false);
        }
    }

    private void RightArmAttackOn()
    {
        rightArmAttackPoint.SetActive(true);
    }

    private void RightLegAttackPointOff()
    {
        if (rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);
        }
    }

    private void RightLegAttackPointOn()
    {
        rightLegAttackPoint.SetActive(true);
    }

    private void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    private IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTimer);
        animationScript.StandUp();
    }

    private void TagLeft_Arm()
    {
        leftArmAttackPoint.tag = Tags.LEFT_ARM_TAG;
    }

    private void TagLeft_Leg()
    {
        leftLegAttackPoint.tag = Tags.LEFT_LEG_TAG;
    }

    private void UntagLeft_Arm()
    {
        leftArmAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    private void UntagLeft_Leg()
    {
        leftLegAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void CharacterDied()
    {
        Invoke("DeactivateGameObject", 2f);
    }

    void DeactivateGameObject()
    {
        EnemyManager.instance.SpawnEnemy();

        gameObject.SetActive(false);
    }
}