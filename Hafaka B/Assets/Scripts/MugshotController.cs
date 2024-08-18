using UnityEditor.Sprites;
using UnityEngine;

public class MugshotController : MonoBehaviour
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
  
  public void SetSkin(Material Colors, Sprite head, Sprite eyes, Sprite nose, Sprite hair, Sprite mouthClosed,
  Sprite mouthOpenSmall, Sprite mouthOpenBig, Sprite frontEar, Sprite backEar, Sprite neck,
  Sprite body)
    {
        UpdateRenderer(Head, head, Colors);
        UpdateRenderer(Eyes, eyes, Colors);
        UpdateRenderer(Nose, nose, Colors);
        UpdateRenderer(Hair, hair, Colors);
        UpdateRenderer(MouthClosed, mouthClosed, Colors);
        UpdateRenderer(MouthOpenSmall, mouthOpenSmall, Colors);
        UpdateRenderer(MouthOpenBig, mouthOpenBig, Colors);
        UpdateRenderer(FrontEar, frontEar, Colors);
        UpdateRenderer(BackEar, backEar, Colors);
        UpdateRenderer(Neck, neck, Colors);

        UpdateRenderer(Body, body, Colors);

    }

    private void UpdateRenderer(SpriteRenderer renderer, Sprite Texture, Material mat)
    {
        renderer.sprite = Texture;
        renderer.material = mat;
    }
}
