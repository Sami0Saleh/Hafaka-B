using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BloodSpawner : MonoBehaviour
{
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] List<Sprite> _bloodImages;
    [SerializeField] List<Material> _materials;
    [SerializeField] float _spawnYPosition = -2.5f;

    private Material _redMaterial;

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
        _redMaterial = _materials.FirstOrDefault(m => m.name.Contains("Red"));
    }

    public void SpawnBlood(CharacterController character)
    {
        GameObject bloodSplatter = Instantiate(_sprite.gameObject);
        bloodSplatter.transform.position = new Vector3(character.transform.position.x, _spawnYPosition, 0);
        SpriteRenderer sr = bloodSplatter.GetComponent<SpriteRenderer>();
        sr.sprite = _bloodImages[Random.Range(0, _bloodImages.Count - 1)];
        if(character.IsAlien)
        {
            sr.material = _redMaterial;
            return;
        }
        sr.material = _materials[Random.Range(0, _materials.Count - 1)];
    }
}
