using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_leve : MonoBehaviour
{
    private Scene _scene;
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(_scene.buildIndex+1);
        }
    }
    public void startLevel() // BUTTONUN ÝÇÝNDEN ÇAPIRILACAÐI ÝÇÝN PUBLÝC OLMAK ZORUNDAAA
    {

        SceneManager.LoadScene(_scene.buildIndex + 1);

    }
}
