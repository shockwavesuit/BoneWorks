using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RootMotion.FinalIK;
/*Attach this script to a an avatar using FinalIK or equivalently modify it to use in any IK system
 */
namespace ModThatIsNotMod.MonoBehaviours
{
    public class AvatarTransform_IK : MonoBehaviour
    {


        public AvatarTransform_IK(IntPtr ptr) : base(ptr) { }
        public float customHeight = 0;//Set this to avatar height in game or keep it at 0 to use the tpose calibrated physical height of player
        bool useIK = false;
        float[] headsetPos = new float[3];//For position computation
        float[] headsetRot = new float[4];
      
        Transform headset, leftController, rightController;
        ShockwaveManager manager;
        GameObject leftFoot = new GameObject(), rightFoot = new GameObject(), leftKnee = new GameObject(), rightKnee = new GameObject(), pelvis = new GameObject(), chest = new GameObject();
       
    
        
        void Awake()
        {
           CustomMonoBehaviourHandler.SetFieldValues(this);
            

        }
        void Start()
        {
            
            headset = GameObject.FindObjectOfType<ValveCamera>().transform;//Modify to find the headset in the game
            

        
          
           
            manager = ShockwaveManager.Instance;

            if (useIK)
            {    manager.StartPositionComputation(customHeight);
          
                VRIK ik = GameObject.FindObjectOfType<VRIK>();
               
                ik.solver.leftLeg.positionWeight = 1;
                ik.solver.leftLeg.target = leftFoot.transform;
                ik.solver.leftLeg.bendGoal = leftKnee.transform;
                ik.solver.rightLeg.positionWeight = 1;
                ik.solver.rightLeg.target = rightFoot.transform;
                ik.solver.rightLeg.bendGoal = rightKnee.transform;
                ik.solver.spine.pelvisPositionWeight = 1;
                ik.solver.spine.pelvisRotationWeight = 1;
                ik.solver.spine.pelvisTarget = pelvis.transform;
                ik.solver.spine.chestGoalWeight = 1;
                ik.solver.spine.chestGoal = chest.transform;

            }

        }


        void Update()
        {
            
            if (useIK)
            {
                headsetPos[0] = -headset.position.x; headsetPos[1] = headset.position.y; headsetPos[2] = headset.position.z;
                headsetRot[0] = headset.rotation.x; headsetRot[1] = -headset.rotation.y; headsetRot[2] = -headset.rotation.z; headsetRot[3] = headset.rotation.w;
                manager.SendHeadsetPositionQuaternion(headsetPos, headsetRot);
                leftFoot.transform.position= GetJointPosition(5); //See Index2BoneNames for Indices
                leftKnee.transform.position = GetJointPosition(3);
                rightFoot.transform.position = GetJointPosition(6);
                rightKnee.transform.position = GetJointPosition(4);
                pelvis.transform.position = GetJointPosition(0);
                chest.transform.position = GetJointPosition(7);


            }
           
            
        }
      Vector3 GetJointPosition(int index)
        {
            float [] jointPos=manager.GetTrackerPosition(index);
            return new Vector3(jointPos[0], jointPos[1], jointPos[2]);
        }
        string[] Index2BoneNames = new string[]
        {
        "pelvis",
        "thigh_l",
        "thigh_r",
        "calf_l",
        "calf_r",
        "foot_l",
        "foot_r",
        "spine_02",
      "clavicle_r",
        "clavicle_l",
         "upperarm_r",
         "upperarm_l",
        "head",
          "lowerarm_r",
        "lowerarm_l",
       "hand_r",
        "hand_l",
          "spine_01"

        };
   
    }
}

