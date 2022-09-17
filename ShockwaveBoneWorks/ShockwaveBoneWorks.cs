using MelonLoader;
using CustomItemsFramework;
using UnityEngine;
using System.Collections.Generic;
using ModThatIsNotMod.MonoBehaviours;
using RootMotion.FinalIK;
using ModThatIsNotMod;
using System.Reflection;
using UnhollowerBaseLib;
using UnhollowerBaseLib.Attributes;
using HarmonyLib;
using StressLevelZero.VRMK;
namespace ShockwaveBoneWorks
{
 
    public static class BuildInfo
    {
        public const string Name = "Shockwave"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "Akshay"; // Author of the Mod.  (Set as null if none)
        public const string Company = "Shockwave VR" ; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class ShockwaveBoneWorks : MelonMod
    {
        ShockwaveManager suit;
       Animator playerAnimator;
      Transform playArea;
   
        Transform Physbody;
        public override void OnApplicationStart()
        {
         //   CustomMonoBehaviourHandler.RegisterMonoBehaviourInIl2Cpp<AvatarTransform_IK>();
            CustomMonoBehaviourHandler.RegisterMonoBehaviourInIl2Cpp<ShockwaveCollider>();
            suit = ShockwaveManager.Instance;
            suit.InitializeSuit();
           
          
            MelonLogger.Msg("OnApplicationStart");
        }
        void SuitAdded(GameObject suitObject)
        {
            
            MelonLogger.Msg("OnCustomItemAdded: " + suitObject.name);
          
        
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MelonLogger.Msg("OnLevelWasLoaded: " + sceneName);
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            MelonLogger.Msg("OnLevelWasInitialized: " + sceneName);
            
         
            Physbody = GameObject.FindObjectOfType<StressLevelZero.Rig.PhysicsRig>().transform;
            playerAnimator = GameObject.FindObjectOfType<StressLevelZero.Player.CharacterAnimationManager>().gameObject.GetComponent<Animator>(); ;
          playArea= GameObject.FindObjectOfType<StressLevelZero.Rig.SteamControllerRig>().transform.GetChild(0);
       //     CapsuleCollider[] torsoColliders = Physbody.GetChild(3).GetComponentsInChildren<CapsuleCollider>();
       //     BoxCollider[] chestFront = Physbody.GetChild(3).GetComponentsInChildren<BoxCollider>();
            CapsuleCollider legCollider = Physbody.GetChild(4).GetComponentInChildren<CapsuleCollider>();
            ShockwaveCollider shockwaveCollider = Physbody.GetChild(3).gameObject.AddComponent<ShockwaveCollider>();
            shockwaveCollider.animator = playerAnimator;
            shockwaveCollider.bodyForward = playArea.forward;
            shockwaveCollider.region = ColliderRegion.PELVIS;
            
           
    
                
               ShockwaveCollider leftThighCollider = legCollider.transform.parent.gameObject.AddComponent<ShockwaveCollider>();
            ShockwaveCollider leftCalfCollider = legCollider.transform.parent.gameObject.AddComponent<ShockwaveCollider>();
            ShockwaveCollider rightThighCollider = legCollider.transform.parent.gameObject.AddComponent<ShockwaveCollider>();
            ShockwaveCollider rightCalfCollider = legCollider.transform.parent.gameObject.AddComponent<ShockwaveCollider>();
            leftThighCollider.region = ColliderRegion.LEFTUPPERLEG;
            leftCalfCollider.region = ColliderRegion.LEFTLOWERLEG;
            rightThighCollider.region = ColliderRegion.RIGHTUPPERLEG;
            rightCalfCollider.region = ColliderRegion.RIGHTLOWERLEG;
            leftThighCollider.animator = playerAnimator;
            leftCalfCollider.animator = playerAnimator;
            rightThighCollider.animator = playerAnimator;
            rightCalfCollider.animator = playerAnimator;
            leftThighCollider.bodyForward = playArea.forward;
            leftCalfCollider.bodyForward = playArea.forward;
            rightThighCollider.bodyForward = playArea.forward;
            rightCalfCollider.bodyForward = playArea.forward;

            

        }
       

        public override void OnApplicationQuit()
        {
            suit.DisconnectSuit();
        }
        
        
    }



}
