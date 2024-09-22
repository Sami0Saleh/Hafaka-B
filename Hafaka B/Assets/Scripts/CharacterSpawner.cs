using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    private int _spawnCount = 0;
    [SerializeField] List<CharacterScriptableObject> _workers;
    [SerializeField] List<CharacterScriptableObject> _workersSus;
    [SerializeField] List<CharacterScriptableObject> _workersAlien;
    [SerializeField] List<CharacterScriptableObject> _workersSubtleAlien;
    [SerializeField] GameObject _characterPrefab;
    [SerializeField] ExpectedListUI _expectedListUI;
    [SerializeField] Transform _lastGoal;

    [Header("Stats")]
    [SerializeField] int _minExpectedWorkers = 2;
    [SerializeField] int _maxExpectedWorkers = 5;
    [SerializeField] int _MinUnexpectedWorkers = 2;
    [SerializeField] int _MaxUnexpectedworkers = 5;
    [SerializeField] int _MinAlienArrivals = 4;
    [SerializeField] int _MaxAlienArrivals = 8;
    [SerializeField,Range(0,1)] float _HumanSusChance = 0.3f;
    [SerializeField, Range(0,1)] float _AlienObvChance = 0.3f;
    [SerializeField] float _minSpawnTime = 20f;
    [SerializeField] float _maxSpawnTime = 25f;

    public List<CharacterScriptableObject> _expectedWorkers = new List<CharacterScriptableObject>();
    public List<int> _ExpectedWorkersIndexes = new List<int>();
    private List<int> _SpawnedHumans;
    private float _secondsToWait;

    private int ExpectedWorkersLeft;
    private int UnexpectedLeft;
    private int AliensLeft;

    private int _characterCount;

    public int CharacterCount { get { return _characterCount; } private set { _characterCount = value; } }

    public int SpawnCount { get => _spawnCount; set => _spawnCount = value; }
    public int count = 15;
    void Start()
    {
        ExpectedWorkersLeft = Random.Range(_minExpectedWorkers, _maxExpectedWorkers + 1);
        
        SelectExpectedWorkers(ExpectedWorkersLeft);

        UnexpectedLeft = Random.Range(_MinUnexpectedWorkers, _MaxUnexpectedworkers + 1);

        AliensLeft = Random.Range(_MinAlienArrivals, _MaxAlienArrivals + 1);

        CharacterCount = ExpectedWorkersLeft + UnexpectedLeft + AliensLeft;

        Debug.Log("will spawn " + CharacterCount);
        _expectedListUI.NewUpdateExpectedList(_expectedWorkers); // Update the UI
        StartCoroutine(SpawnCharactersCoroutine());
    }

    private void SelectExpectedWorkers(int numberOfExpectedWorkers)
    {
        List<CharacterScriptableObject> workersPool = new List<CharacterScriptableObject>(_workers);

        for (int i = 0; i < numberOfExpectedWorkers; i++)
        {
            int randomIndex = Random.Range(0, workersPool.Count);
            while (!_ExpectedWorkersIndexes.Contains(randomIndex)) {
                randomIndex = Random.Range(0, workersPool.Count);
            }
            CharacterScriptableObject selectedWorker = workersPool[randomIndex];
            _expectedWorkers.Add(selectedWorker);
            _ExpectedWorkersIndexes.Add(randomIndex);
        }
    }


    private IEnumerator SpawnCharactersCoroutine()
    {
        

        while(CharacterCount > 0 && UnexpectedLeft>0 && AliensLeft>0)
        {
            isExpectedSO Character = GetNextCharacter(); 

            SpawnCharacter(Character._CharacterScriptableObject, Character._IsExpected);
            _secondsToWait = Random.Range(_minSpawnTime, _maxSpawnTime);
            _minSpawnTime = Mathf.Max(_minSpawnTime * 0.9f, 3);
            _maxSpawnTime = Mathf.Max(_maxSpawnTime * 0.9f, 5);
            yield return new WaitForSeconds(_secondsToWait);
        }
    }

    private void SpawnCharacter(CharacterScriptableObject characterSO,bool isExpected)
    {
        GameObject character = Instantiate(_characterPrefab);
        CharacterController characterController = character.GetComponent<CharacterController>();
        characterController.Init(characterSO,isExpected);

        // Position the character randomly on the screen
        Vector2 position = transform.position;
        character.transform.position = position;

        // Set the last goal for the character
        characterController.SetGoal(_lastGoal);
        SpawnCount++;
    }

    private isExpectedSO GetNextCharacter()
    {
        int rnd;
        bool run = true;
        isExpectedSO output = new();
        while (run)
        {
            rnd = Random.Range(0, 3);
            switch (rnd)
            {
                case 0:
                    if (AliensLeft > 0)
                    {
                        output = AddAliens();
                        run = false;
                    }
                    break;
                case 1:
                    if (CharacterCount > 0)
                    {
                        output = AddExpectedHumans();
                        run = false;
                    }
                    break;  
                case 2:
                    if (UnexpectedLeft > 0)
                    {
                        output = AddUnexpectedHumans();
                        run = false;
                    }
                    break;
            }
        }
        return output;
    }

    private isExpectedSO AddExpectedHumans()
    {
        int randomIndex;
        float Chance;
        randomIndex = Random.Range(0, _ExpectedWorkersIndexes.Count);
        while (!_SpawnedHumans.Contains(_ExpectedWorkersIndexes[randomIndex]))
        {
            randomIndex = Random.Range(0, _ExpectedWorkersIndexes.Count);
        }
        _SpawnedHumans.Add(_ExpectedWorkersIndexes[randomIndex]);
        Chance = Random.Range(0, 1);
        CharacterCount--;
        if (Chance < _HumanSusChance)
        {
            return new(_workersSus[randomIndex], true);
        }
        else
        {
            return new(_workers[randomIndex], true);
        }
        
    }

    private isExpectedSO AddUnexpectedHumans()
    {
        int randomIndex;
        float Chance;
        
        randomIndex = Random.Range(0, _workers.Count);
        while (!_SpawnedHumans.Contains(randomIndex) && !_ExpectedWorkersIndexes.Contains(randomIndex))
        {
            randomIndex = Random.Range(0, _workers.Count);
        }
        _SpawnedHumans.Add(randomIndex);
        Chance = Random.Range(0, 1);
        UnexpectedLeft--;
        if (Chance < _HumanSusChance)
        {
            return new(_workersSus[randomIndex], false);
        }
        else
        {
            return new(_workers[randomIndex], false);
        }
        
        
    }

    private isExpectedSO AddAliens()
    {
        int randomIndex;
        bool isExpected;
        float Chance;
        
        randomIndex = Random.Range(0, _workers.Count);
        if (_ExpectedWorkersIndexes.Contains(randomIndex))
        {
            isExpected = true;
        }
        else
        {
            isExpected = false;
        }
        Chance = Random.Range(0, 1);
        AliensLeft--;
        if (Chance < _AlienObvChance)
        {
            return new(_workersAlien[randomIndex], isExpected);
        }
        else
        {
            return new(_workersSubtleAlien[randomIndex], isExpected);
        }
        
    }
}

public class isExpectedSO
{
    public CharacterScriptableObject _CharacterScriptableObject;
    public bool _IsExpected;

    public isExpectedSO(CharacterScriptableObject SO, bool isExpected)
    {
        _CharacterScriptableObject = SO;
        _IsExpected = isExpected;
    }

    public isExpectedSO()
    {

    }

}