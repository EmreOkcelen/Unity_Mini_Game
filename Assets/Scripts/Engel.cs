using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Engel : MonoBehaviour
{
    private Scene _scene; 

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); // sahnemizi awakede oyun baþlamadan aldýk
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Score.lives--;
            SceneManager.LoadScene(_scene.name);   // teleport olur baþlama  noktasýna yani oyunun baþýna
        }
    }
}
