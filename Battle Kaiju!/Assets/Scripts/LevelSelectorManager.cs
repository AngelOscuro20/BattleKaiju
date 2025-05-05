using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorManager : MonoBehaviour
{
    [SerializeField] private GameObject loadLevelPrefab;
    [SerializeField] private GameObject loadLevelBtnContainer;
    void Start()
    {
        GameObject.FindGameObjectWithTag("CareManager").GetComponent<CareManager>().enabled = false;
        for (int i = 0; i < GameManager.Instance.GetNumberOfLevels(); i++)
        {
           GameObject btn = Instantiate(loadLevelPrefab, loadLevelBtnContainer.transform);
            btn.GetComponent<LevelSelectorButton>().SetLevelIndex(i);
            
        }
    }
}
