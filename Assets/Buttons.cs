using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadMuseum()
    {
        SceneManager.LoadScene("Museum");
    }

    public void LoadQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void LoadQuiz2()
    {
        SceneManager.LoadScene("Quiz2");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
