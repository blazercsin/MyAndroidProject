using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKArms : MonoBehaviour
{

    protected Animator animator;

    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform leftHandObj;
   

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {

            //if the IK is active, set the position and rotation directly to the goal. 
            

                

                // Set the right hand target position and rotation, if one has been assigned
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                  
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    
                }
            if (leftHandObj != null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

                animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);

            }



            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            
        }
    }
}
