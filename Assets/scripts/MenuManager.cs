using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void LoadStage2()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadStage3()
    {
        SceneManager.LoadScene("SampleScene");
    }
}