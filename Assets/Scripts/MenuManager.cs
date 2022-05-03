using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Text bestScore;

    [SerializeField]
    private Text name;
    // Start is called before the first frame update
    void Start()
    {
        SaveManager.Instence.LoadScore();
        bestScore.text = "Best Score : " + SaveManager.Instence.Name + " : " + SaveManager.Instence.Score;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartButton()
    {
        SaveManager.Instence.Name = name.text;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
