using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] List<CharacterScriptableObject> _workers;
    [SerializeField] List<CharacterScriptableObject> _workersSus;
    [SerializeField] List<CharacterScriptableObject> _workersSuperSus;
    [SerializeField] List<CharacterScriptableObject> _workersAlien;
    [SerializeField] List<CharacterScriptableObject> _workersSubtleAlien;
    [SerializeField] List<CharacterScriptableObject> _workersSuperSubtleAlien;
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
    [SerializeField, Range(0, 1)] float _HumanSuperSusChance = 0;
    [SerializeField,Range(0,1)] float _HumanSusChance = 0.3f;
    [SerializeField, Range(0, 1)] float _AlienSuperSubtleChance = 0;
    [SerializeField, Range(0,1)] float _AlienObvChance = 0.3f;
    
    [SerializeField, Range(0.75f, 1)] float _SpawnAccelerationRate = 0.9f;
    [SerializeField] float _minSpawnTime = 20f;
    [SerializeField] float _maxSpawnTime = 25f;

    public List<CharacterScriptableObject> _expectedWorkers = new List<CharacterScriptableObject>();
    public List<int> _ExpectedWorkersIndexes = new List<int>();
    private List<int> _SpawnedHumans = new List<int>();
    private float _secondsToWait;

    private int ExpectedWorkersLeft;
    private int UnexpectedLeft;
    private int AliensLeft;

    private int _characterCount;

    public int CharacterCount { get { return _characterCount; } private set { _characterCount = value; } }

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
        bool run = true;
        for (int i = 0; i < numberOfExpectedWorkers; i++)
        {
            run = true;
            int randomIndex = Random.Range(0, _workers.Count);
            while (run) {
                if (!_ExpectedWorkersIndexes.Contains(randomIndex))
                {
                    _ExpectedWorkersIndexes.Add(randomIndex);
                    run = false;
                }
                else
                {
                    randomIndex = Random.Range(0, _workers.Count);
                }
            }
            CharacterScriptableObject selectedWorker = _workers[randomIndex];
            _expectedWorkers.Add(selectedWorker);
        }
    }


    private IEnumerator SpawnCharactersCoroutine()
    {
        

        while(CharacterCount > 0 && UnexpectedLeft>0 && AliensLeft>0)
        {
            isExpectedSO Character = GetNextCharacter(); 

            SpawnCharacter(Character._CharacterScriptableObject, Character._IsExpected);
            _secondsToWait = Random.Range(_minSpawnTime, _maxSpawnTime);
            _minSpawnTime = Mathf.Max(_minSpawnTime * _SpawnAccelerationRate, 3);
            _maxSpawnTime = Mathf.Max(_maxSpawnTime * _SpawnAccelerationRate, 5);
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
    }

    private isExpectedSO GetNextCharacter()
    {
        int rnd;
        bool run = true;
        isExpectedSO output = new();
        while (run)
        {
            rnd = Random.Range(0, 4);
            if (rnd < 2)
            {
                output = AddAliens();
                run = false;
            }
            else if (rnd == 2)
            {
                output = AddExpectedHumans();
                run = false;
            }
            else if (rnd == 3)
            {
                output = AddUnexpectedHumans();
                run = false;
            }
        }
        return output;
    }

    private isExpectedSO AddExpectedHumans()
    {
        int randomIndex;
        float Chance;
        bool run = true;
        randomIndex = Random.Range(0, _ExpectedWorkersIndexes.Count);
        while (run)
        {
            if (!_SpawnedHumans.Contains(_ExpectedWorkersIndexes[randomIndex]))
            {
                run = false;
                _SpawnedHumans.Add(_ExpectedWorkersIndexes[randomIndex]);
            }
            else
            {
                randomIndex = Random.Range(0, _ExpectedWorkersIndexes.Count);
            }
        }
        Chance = Random.Range(0, 1);
        CharacterCount--;
        Debug.Log("Summoning Expected Human no." + _ExpectedWorkersIndexes[randomIndex]);
        if (Chance < _HumanSusChance)
        {
            Chance = Random.Range(0, 1);
            if (Chance < _HumanSuperSusChance && _workersSuperSus.Count > randomIndex) return new(_workersSuperSus[randomIndex], true);
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
        bool run = true;
        
        randomIndex = Random.Range(0, _workers.Count);
        while (run)
        {
            if (!_SpawnedHumans.Contains(randomIndex) && !_ExpectedWorkersIndexes.Contains(randomIndex))
            { 
                _SpawnedHumans.Add(randomIndex);
                run = false;
            }
            else
            {
                randomIndex = Random.Range(0, _workers.Count);
            }
        }
        Chance = Random.Range(0, 1);
        UnexpectedLeft--;

        Debug.Log("Summoning Unexpected Human no." + randomIndex);
        if (Chance < _HumanSusChance)
        {
            Chance = Random.Range(0, 1);
            if (Chance < _HumanSuperSusChance && _workersSuperSus.Count > randomIndex) return new(_workersSuperSus[randomIndex], false);
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

        Debug.Log("Summoning Alien no." + randomIndex);
        if (Chance < _AlienObvChance)
        {
            return new(_workersAlien[randomIndex], isExpected);
        }
        else
        {
            Chance = Random.Range(0, 1);
            if (Chance < _AlienSuperSubtleChance && _workersSuperSubtleAlien.Count >randomIndex) return new(_workersSuperSubtleAlien[randomIndex], isExpected);
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