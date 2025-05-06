using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelectorButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int levelIndex = 0;
    [SerializeField] private TextMeshProUGUI text;
    public GameObject gameManager;
    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (levelIndex > gameManager.GetComponent<GameManager>().ultimoNivelCompletado) { this.GetComponent<Button>().interactable = false; }
    }
    public void SetLevelIndex(int index)
    {
        levelIndex = index;
        text.SetText((index + 1).ToString());
        print(GameManager.Instance.ultimoNivelCompletado - 1);
    }
    public void OnClick()
    {
      GameManager.Instance.SetSelectedLevel(levelIndex+1);
        SceneManager.LoadScene("BattleScene");
    }


}
