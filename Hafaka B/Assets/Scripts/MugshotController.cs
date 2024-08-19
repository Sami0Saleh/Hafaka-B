
using UnityEngine;


public class MugshotController : MonoBehaviour
{
    [Header("Head Renderers")]
    [SerializeField] SpriteRenderer Head;
    [SerializeField] SpriteRenderer Eyes;
    [SerializeField] SpriteRenderer Nose;
    [SerializeField] SpriteRenderer Hair;
    [SerializeField] SpriteRenderer MouthClosed;
    [SerializeField] SpriteRenderer FrontEar;
    [SerializeField] SpriteRenderer BackEar;
    [SerializeField] SpriteRenderer Neck;

    [Header("Body Renderers")]
    [SerializeField] SpriteRenderer Body;
    [SerializeField] SpriteRenderer BackSholder;
    [SerializeField] SpriteRenderer FrontSholder;
    [SerializeField] SpriteRenderer BackWrist;
    [SerializeField] SpriteRenderer FrontWrist;

    [SerializeField] RectTransform Parent;
    private void Update()
    {
        transform.position = Parent.position;
    }
    public void SetSkin(Material Colors, Sprite head, Sprite eyes, Sprite nose, Sprite hair, Sprite mouthClosed, Sprite frontEar, Sprite backEar, Sprite neck,
  Sprite body, Sprite backSholder, Sprite frontSholder, Sprite backWrist, Sprite frontWrist)
    {
        UpdateRenderer(Head, head, Colors);
        UpdateRenderer(Eyes, eyes, Colors);
        UpdateRenderer(Nose, nose, Colors);
        UpdateRenderer(Hair, hair, Colors);
        UpdateRenderer(MouthClosed, mouthClosed, Colors);
        UpdateRenderer(FrontEar, frontEar, Colors);
        UpdateRenderer(BackEar, backEar, Colors);
        UpdateRenderer(Neck, neck, Colors);

        UpdateRenderer(Body, body, Colors);
        UpdateRenderer(BackSholder, backSholder, Colors);
        UpdateRenderer(FrontSholder, frontSholder, Colors);
        UpdateRenderer(BackWrist, backWrist, Colors);
        UpdateRenderer(FrontWrist, frontWrist, Colors);

    }

    private void UpdateRenderer(SpriteRenderer renderer, Sprite Texture, Material mat)
    {
        renderer.sprite = Texture;
        renderer.material = mat;
    }
}
