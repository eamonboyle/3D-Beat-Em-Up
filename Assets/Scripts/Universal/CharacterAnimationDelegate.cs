using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint;
    public GameObject rightArmAttackPoint;
    public GameObject leftLegAttackPoint;
    public GameObject rightLegAttackPoint;

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
}
