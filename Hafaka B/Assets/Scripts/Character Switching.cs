using UnityEngine;

public class CharacterSwitching : MonoBehaviour
{
    [SerializeField] SkinController targetSkinController;
    [SerializeField] CharacterScriptableObject[] skinControllers;

    int i = 0;
    void Start()
    {
      
        
    }

    void Update()
    {
      
    }

    public void TestButton()
    {
        targetSkinController.SetSkin(skinControllers[i]._material, skinControllers[i].Head, skinControllers[i].Eyes, skinControllers[i].Nose
          , skinControllers[i].Hair, skinControllers[i].MouthClosed, skinControllers[i].MouthOpenSmall, skinControllers[i].MouthOpenBig
          , skinControllers[i].FrontEar, skinControllers[i].BackEar, skinControllers[i].Neck, skinControllers[i].Body, skinControllers[i].SholderFront
          , skinControllers[i].SholderBack, skinControllers[i].ForearmFront, skinControllers[i].ForearmBack, skinControllers[i].KneeRight
          , skinControllers[i].KneeLeft, skinControllers[i].AnkleRight, skinControllers[i].AnkleLeft, skinControllers[i].FootRight, skinControllers[i].FootLeft); ;
    }
}
