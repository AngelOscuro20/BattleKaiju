using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorManager : MonoBehaviour
{
    [SerializeField] private GameObject loadLevelPrefab;
    [SerializeField] private GameObject loadLevelBtnContainer;
    void Start()
    {
      //  for (int i = 0; i < GameManager.Instance.GetNumberOfLevels(); i++)
      //  {
      //      GameObject btn = Instantiate(loadLevelPrefab, loadLevelBtnContainer.transform);
      //      btn.GetComponent<LevelSelectorButton>().SetLevelIndex(i);
      //  }
    }
}
