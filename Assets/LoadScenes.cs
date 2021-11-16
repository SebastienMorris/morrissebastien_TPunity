using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScenes : MonoBehaviour
{
    //load
    public void Load(int id)
    {
        SceneManager.LoadScene(id);
    }
}
