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

    private void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();
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
}
