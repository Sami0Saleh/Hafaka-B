using UnityEngine;


public class SkinController : MonoBehaviour
{
    [SerializeField] private Material _colors;

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

    public SpriteRenderer Head1 { get => Head; set => Head = value; }
    public Material Colors { get => _colors; set => _colors = value; }
    public SpriteRenderer Eyes1 { get => Eyes; set => Eyes = value; }
    public SpriteRenderer Nose1 { get => Nose; set => Nose = value; }
    public SpriteRenderer Hair1 { get => Hair; set => Hair = value; }
    public SpriteRenderer MouthClosed1 { get => MouthClosed; set => MouthClosed = value; }
    public SpriteRenderer MouthOpenSmall1 { get => MouthOpenSmall; set => MouthOpenSmall = value; }
    public SpriteRenderer MouthOpenBig1 { get => MouthOpenBig; set => MouthOpenBig = value; }
    public SpriteRenderer FrontEar1 { get => FrontEar; set => FrontEar = value; }
    public SpriteRenderer BackEar1 { get => BackEar; set => BackEar = value; }
    public SpriteRenderer Neck1 { get => Neck; set => Neck = value; }
    public SpriteRenderer Body1 { get => Body; set => Body = value; }
    public SpriteRenderer SholderFront1 { get => SholderFront; set => SholderFront = value; }
    public SpriteRenderer SholderBack1 { get => SholderBack; set => SholderBack = value; }
    public SpriteRenderer ForearmFront1 { get => ForearmFront; set => ForearmFront = value; }
    public SpriteRenderer ForearmBack1 { get => ForearmBack; set => ForearmBack = value; }
    public SpriteRenderer KneeRight1 { get => KneeRight; set => KneeRight = value; }
    public SpriteRenderer KneeLeft1 { get => KneeLeft; set => KneeLeft = value; }
    public SpriteRenderer AnkleRight1 { get => AnkleRight; set => AnkleRight = value; }
    public SpriteRenderer AnkleLeft1 { get => AnkleLeft; set => AnkleLeft = value; }
    public SpriteRenderer FootRight1 { get => FootRight; set => FootRight = value; }
    public SpriteRenderer FootLeft1 { get => FootLeft; set => FootLeft = value; }

    public void SetSkin(Material Colors, Sprite head, Sprite eyes, Sprite nose, Sprite hair, Sprite mouthClosed, 
        Sprite mouthOpenSmall, Sprite mouthOpenBig, Sprite frontEar, Sprite backEar, Sprite neck, 
        Sprite body, Sprite sholderFront, Sprite sholderBack, Sprite forearmFront, Sprite forearmBack, 
        Sprite kneeRight, Sprite kneeLeft, Sprite ankleRight, Sprite ankleLeft, Sprite footRight, Sprite footLeft)
    {
        UpdateRenderer(Head1, head, Colors);
        UpdateRenderer(Eyes1, eyes, Colors);
        UpdateRenderer(Nose1, nose, Colors);
        UpdateRenderer(Hair1, hair, Colors);
        UpdateRenderer(MouthClosed1, mouthClosed, Colors);
        UpdateRenderer(MouthOpenSmall1, mouthOpenSmall, Colors);
        UpdateRenderer(MouthOpenBig1, mouthOpenBig, Colors);
        UpdateRenderer(FrontEar1, frontEar, Colors);
        UpdateRenderer (BackEar1, backEar, Colors);
        UpdateRenderer(Neck1,neck, Colors);

        UpdateRenderer(Body1,body, Colors);
        UpdateRenderer(SholderFront1, sholderFront, Colors);
        UpdateRenderer(SholderBack1, sholderBack, Colors);
        UpdateRenderer(ForearmFront1, forearmFront, Colors);
        UpdateRenderer(ForearmBack1, forearmBack, Colors);
        UpdateRenderer(KneeRight1, kneeRight, Colors);
        UpdateRenderer(KneeLeft1, kneeLeft, Colors);
        UpdateRenderer(AnkleRight1, ankleRight, Colors);
        UpdateRenderer(AnkleLeft1, ankleLeft, Colors);
        UpdateRenderer(FootRight1, footRight, Colors);
        UpdateRenderer(FootLeft1, footLeft, Colors);

    }

    private void UpdateRenderer(SpriteRenderer renderer,Sprite Texture, Material mat)
    {
        renderer.sprite = Texture;
        renderer.material = mat;
    }
}
