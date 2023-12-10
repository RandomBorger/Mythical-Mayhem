using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnfinishedScene : MonoBehaviour
{
    public void NoScene()
    {
        SceneManager.LoadScene(4);
    }
}