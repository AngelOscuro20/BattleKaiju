using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelSelectorButton : MonoBehaviour
{
    // Start is called before the first frame update
    private int levelIndex = 0;
    [SerializeField] private TextMeshProUGUI text;
    public void SetLevelIndex(int index)
    {
        levelIndex = index;
        text.SetText((index + 1).ToString());
    }
    public void OnClick()
    {
      //  GameManager.Instance.LoadLevel(levelIndex);
    }
}
