using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{

    [SerializeField] List<CharacterScriptableObject> SOlist;
    [SerializeField] List<GameObject> databaseSlots;
    private Dictionary<int, CharacterScriptableObject> DatabaseDictionary;

    // UI Presentation
    void Start()
    {
        DatabaseDictionary = new Dictionary<int, CharacterScriptableObject>();
        CreateDictionary(SOlist);
        foreach (GameObject slot in databaseSlots)
        {
            //InsertSO(slot, DatabaseDictionary[slot.id]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertSO(GameObject slot, CharacterScriptableObject CharSO)
    {
        
    }
    public void CreateDictionary(List<CharacterScriptableObject> SOlist)
    {
        foreach (CharacterScriptableObject SO in SOlist) 
        {
            DatabaseDictionary.Add(SO.DatabaseID, SO);

        }
        Debug.Log(DatabaseDictionary.ToString());
    }
}
