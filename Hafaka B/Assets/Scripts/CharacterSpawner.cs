using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    private int _spawnCount = 0;
    [SerializeField] List<CharacterScriptableObject> _workers;
    [SerializeField] List<CharacterScriptableObject> _workersSus;
    [SerializeField] List<CharacterScriptableObject> _workersAlian;
    [SerializeField] List<CharacterScriptableObject> _workersSubtleAlian;
    [SerializeField] GameObject _characterPrefab;
    [SerializeField] ExpectedListUI _expectedListUI;
    [SerializeField] Transform _lastGoal;

    [Header("Stats")]
    [SerializeField] int _minExpectedWorkers = 2;
    [SerializeField] int _maxExpectedWorkers = 5;
    [SerializeField] float _minSpawnTime = 20f;
    [SerializeField] float _maxSpawnTime = 25f;

    public List<CharacterScriptableObject> _expectedWorkers = new List<CharacterScriptableObject>();
    private float _secondsToWait;

    public int CharacterCount { get; private set; }
    public int SpawnCount { get => _spawnCount; set => _spawnCount = value; }
    public int count = 15;
    void Start()
    {
        CharacterCount = Random.Range(_minExpectedWorkers, _maxExpectedWorkers + 1);
        Debug.Log("will spawn " + CharacterCount);
        SelectExpectedWorkers(CharacterCount);
        _expectedListUI.NewUpdateExpectedList(_expectedWorkers); // Update the UI
        StartCoroutine(SpawnCharactersCoroutine(CharacterCount));
    }

    private void SelectExpectedWorkers(int numberOfExpectedWorkers)
    {
        List<CharacterScriptableObject> workersPool = new List<CharacterScriptableObject>(_workers);

        for (int i = 0; i < numberOfExpectedWorkers; i++)
        {
            int randomIndex = Random.Range(0, workersPool.Count);
            CharacterScriptableObject selectedWorker = workersPool[randomIndex];
                _expectedWorkers.Add(selectedWorker);
                workersPool.RemoveAt(randomIndex);
            
        }
    }


    private IEnumerator SpawnCharactersCoroutine(int numberOfExpectedWorkers)
    {
        List<CharacterScriptableObject> spawnWorkerPool = new List<CharacterScriptableObject>(_workers);
        List<CharacterScriptableObject> spawnWorkerSusPool = new List<CharacterScriptableObject>(_workersSus);
        List<CharacterScriptableObject> spawnWorkerAlianPool = new List<CharacterScriptableObject>(_workersAlian);
        List<CharacterScriptableObject> spawnWorkerSubtleAlianPool = new List<CharacterScriptableObject>(_workersSubtleAlian);

        CharacterScriptableObject randomCharacter;
        for (int i = 0; i < numberOfExpectedWorkers; i++)
        {
            int randomIndex = Random.Range(0, count);
            int randomNum = Random.Range(0, 4);
            switch (randomNum)
            {
                case 0:
                    randomCharacter = spawnWorkerPool[randomIndex];
                    SpawnCharacter(randomCharacter);
                    spawnWorkerPool.RemoveAt(randomIndex);
                    spawnWorkerSusPool.RemoveAt(randomIndex);
                    break;
                case 1:
                    randomCharacter = spawnWorkerSusPool[randomIndex];
                    SpawnCharacter(randomCharacter);
                    spawnWorkerPool.RemoveAt(randomIndex);
                    spawnWorkerSusPool.RemoveAt(randomIndex);
                    break;
                case 2:
                    randomCharacter = spawnWorkerAlianPool[randomIndex];
                    SpawnCharacter(randomCharacter);
                    spawnWorkerAlianPool.RemoveAt(randomIndex);
                    spawnWorkerSubtleAlianPool.RemoveAt(randomIndex);
                    break;
                case 3:
                    randomCharacter = spawnWorkerSubtleAlianPool[randomIndex];
                    SpawnCharacter(randomCharacter);
                    spawnWorkerAlianPool.RemoveAt(randomIndex);
                    spawnWorkerSubtleAlianPool.RemoveAt(randomIndex);
                    break;
                default:
                    break;
            }
            count--;
            _secondsToWait = Random.Range(_minSpawnTime, _maxSpawnTime) - i * 2;
            yield return new WaitForSeconds(_secondsToWait);
        }
    }

    private void SpawnCharacter(CharacterScriptableObject characterSO)
    {
        GameObject character = Instantiate(_characterPrefab);
        CharacterController characterController = character.GetComponent<CharacterController>();
        characterController.Init(characterSO);

        // Position the character randomly on the screen
        Vector2 position = transform.position;
        character.transform.position = position;

        // Set the last goal for the character
        characterController.SetGoal(_lastGoal);
        SpawnCount++;
    }
}