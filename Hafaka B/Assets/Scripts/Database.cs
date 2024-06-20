using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{

    [SerializeField] List<CharacterScriptableObject> SOlist;
    // Scriptble Objects
    [SerializeField] CharacterScriptableObject d1e1;
    [SerializeField] CharacterScriptableObject d1e2;
    [SerializeField] CharacterScriptableObject d1e3;
    [SerializeField] CharacterScriptableObject d2e1;
    [SerializeField] CharacterScriptableObject d2e2;
    [SerializeField] CharacterScriptableObject d2e3;
    [SerializeField] CharacterScriptableObject d3e1;
    [SerializeField] CharacterScriptableObject d3e2;
    [SerializeField] CharacterScriptableObject d3e3;
    [SerializeField] CharacterScriptableObject d4e1;
    [SerializeField] CharacterScriptableObject d4e2;
    [SerializeField] CharacterScriptableObject d4e3;
    [SerializeField] CharacterScriptableObject d5e1;
    [SerializeField] CharacterScriptableObject d5e2;
    [SerializeField] CharacterScriptableObject d5e3;

    // UI Presentation

     //slot 1
    // slot 2 
    // slot 3
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertSO(int index, CharacterScriptableObject SO)
    {
        switch (index)
        {
            case 11: break;
            case 12: break;
            case 13: break;
            case 21: break;
            case 22: break;
            case 23: break;
            case 31: break;
            case 32: break;
            case 33: break;
            case 41: break;
            case 42: break;
            case 43: break;
            case 51: break;
            case 52: break;
            case 53: break;
        
        }
    }
    public void CreateDictionary()
    {

    }
}
