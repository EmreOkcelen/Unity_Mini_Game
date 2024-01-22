using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Engel : MonoBehaviour
{
    private Scene _scene; 

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); // sahnemizi awakede oyun ba�lamadan ald�k
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Score.lives--;
            SceneManager.LoadScene(_scene.name);   // teleport olur ba�lama  noktas�na yani oyunun ba��na
        }
    }
}
