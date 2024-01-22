using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private AudioSource _audio;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _text.text = Score.totalScore.ToString();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Elmas"))
        {
            _audio.Play();
            Destroy(collision.gameObject);
            Score.totalScore++;
            _text.text = Score.totalScore.ToString();
        }
    }
}
