using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextAppear : ClicAgentController
{
    public Transform player;
    private Vector3 posStartPlayer;
    private Quaternion rotStartPlayer;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<MeshRenderer>().enabled = false;
        posStartPlayer = player.position;
        rotStartPlayer = player.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, winObject.transform.position) < 1)
        {
            player.transform.position = posStartPlayer;
            player.transform.rotation = rotStartPlayer;
            transform.GetComponent<MeshRenderer>().enabled = true;
            transform.SetParent(player);
            if (Input.GetButtonDown("Jump"))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
