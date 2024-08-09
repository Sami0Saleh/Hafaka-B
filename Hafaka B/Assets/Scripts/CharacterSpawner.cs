using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] List<CharacterScriptableObject> _allCharacters;
    [SerializeField] GameObject _characterPrefab;
    [SerializeField] int _minExpectedWorkers = 2;
    [SerializeField] int _maxExpectedWorkers = 4;
    [SerializeField] ExpectedListUI _expectedListUI;
    [SerializeField] Transform _lastGoal;  // Assign this in the inspector to set the last goal position

    private List<CharacterScriptableObject> _expectedWorkers = new List<CharacterScriptableObject>();

    void Start()
    {
        int numberOfExpectedWorkers = Random.Range(_minExpectedWorkers, _maxExpectedWorkers + 1);
        SelectExpectedWorkers(numberOfExpectedWorkers);
        _expectedListUI.UpdateExpectedList(_expectedWorkers); // Update the UI
        StartCoroutine(SpawnCharactersCoroutine(numberOfExpectedWorkers));
    }

    private void SelectExpectedWorkers(int numberOfExpectedWorkers)
    {
        List<CharacterScriptableObject> workersPool = new List<CharacterScriptableObject>(_allCharacters.FindAll(c => !c.IsAlien));

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
        for (int i = 0; i < numberOfExpectedWorkers; i++)
        {
            SpawnCharacter(_expectedWorkers[i]);
            yield return new WaitForSeconds(5f);  // Wait for 5 seconds before spawning the next worker
        }

        // Optionally spawn additional aliens or unexpected workers
        int additionalCharacters = Random.Range(2, 5);
        for (int i = 0; i < additionalCharacters; i++)
        {
            int randomIndex = Random.Range(0, _allCharacters.Count);
            CharacterScriptableObject randomCharacter = _allCharacters[randomIndex];
            SpawnCharacter(randomCharacter);
            yield return new WaitForSeconds(5f);  // Wait for 5 seconds before spawning the next character
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
    }
}