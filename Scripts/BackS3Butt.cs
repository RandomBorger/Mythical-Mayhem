using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackS3Butt : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene(3);
    }
}
