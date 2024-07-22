using UnityEngine;


public class SkinController : MonoBehaviour
{
    [Header("Head Renderers")]
    [SerializeField] SpriteRenderer Head;
    [SerializeField] SpriteRenderer Eyes;
    [SerializeField] SpriteRenderer Nose;
    [SerializeField] SpriteRenderer Hair;
    [SerializeField] SpriteRenderer MouthClosed;
    [SerializeField] SpriteRenderer MouthOpenSmall;
    [SerializeField] SpriteRenderer MouthOpenBig;
    [SerializeField] SpriteRenderer FrontEar;
    [SerializeField] SpriteRenderer BackEar;
    [SerializeField] SpriteRenderer Neck;

    [Header("Body Renderers")]
    [SerializeField] SpriteRenderer Body;
    [SerializeField] SpriteRenderer SholderFront;
    [SerializeField] SpriteRenderer SholderBack;
    [SerializeField] SpriteRenderer ForearmFront;
    [SerializeField] SpriteRenderer ForearmBack;
    [SerializeField] SpriteRenderer KneeRight;
    [SerializeField] SpriteRenderer KneeLeft;
    [SerializeField] SpriteRenderer AnkleRight;
    [SerializeField] SpriteRenderer AnkleLeft;
    [SerializeField] SpriteRenderer FootRight;
    [SerializeField] SpriteRenderer FootLeft;


    public void SetSkin(Material Colors, Sprite head, Sprite eyes, Sprite nose, Sprite hair, Sprite mouthClosed, 
        Sprite mouthOpenSmall, Sprite mouthOpenBig, Sprite frontEar, Sprite backEar, Sprite neck, 
        Sprite body, Sprite sholderFront, Sprite sholderBack, Sprite forearmFront, Sprite forearmBack, 
        Sprite kneeRight, Sprite kneeLeft, Sprite ankleRight, Sprite ankleLeft, Sprite footRight, Sprite footLeft)
    {
        UpdateRenderer(Head, head, Colors);
        UpdateRenderer(Eyes, eyes, Colors);
        UpdateRenderer(Nose, nose, Colors);
        UpdateRenderer(Hair, hair, Colors);
        UpdateRenderer(MouthClosed, mouthClosed, Colors);
        UpdateRenderer(MouthOpenSmall, mouthOpenSmall, Colors);
        UpdateRenderer(MouthOpenBig, mouthOpenBig, Colors);
        UpdateRenderer(FrontEar, frontEar, Colors);
        UpdateRenderer (BackEar, backEar, Colors);
        UpdateRenderer(Neck,neck, Colors);

        UpdateRenderer(Body,body, Colors);
        UpdateRenderer(SholderFront, sholderFront, Colors);
        UpdateRenderer(SholderBack, sholderBack, Colors);
        UpdateRenderer(ForearmFront, forearmFront, Colors);
        UpdateRenderer(ForearmBack, forearmBack, Colors);
        UpdateRenderer(KneeRight, kneeRight, Colors);
        UpdateRenderer(KneeLeft, kneeLeft, Colors);
        UpdateRenderer(AnkleRight, ankleRight, Colors);
        UpdateRenderer(AnkleLeft, ankleLeft, Colors);
        UpdateRenderer(FootRight, footRight, Colors);
        UpdateRenderer(FootLeft, footLeft, Colors);

    }

    private void UpdateRenderer(SpriteRenderer renderer,Sprite Texture, Material mat)
    {
        renderer.sprite = Texture;
        renderer.material = mat;
    }
}
