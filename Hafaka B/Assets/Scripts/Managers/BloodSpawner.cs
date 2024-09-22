using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BloodSpawner : MonoBehaviour
{
    [SerializeField] GameObject _sprite;
    [SerializeField] List<Sprite> _bloodImages;
    [SerializeField] float _spawnYPosition = -2.3f;
    [SerializeField] List<Color> _colors = new List<Color>();

    private Color _redColor;

    public static BloodSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _redColor = Color.red;
    }

    public void SpawnBlood(CharacterController character)
    {
        GameObject bloodSplatter = Instantiate(_sprite);
        bloodSplatter.transform.position = new Vector3(character.transform.position.x, _spawnYPosition, 5);
        SpriteRenderer sr = bloodSplatter.GetComponent<SpriteRenderer>();
        sr.sprite = _bloodImages[Random.Range(0, _bloodImages.Count - 1)];
        if(!character.IsAlien)
        {
            sr.color = _redColor;
            return;
        }
        sr.color = _colors[Random.Range(0, _colors.Count - 1)];
    }
}
