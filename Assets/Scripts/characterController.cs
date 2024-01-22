using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;            //hareketi sa�layacak rigidbodyyi olu�turduk
    private Animator _animator;         //animasyon y�r�tmek i�in
    private SpriteRenderer _spriteRenderer; //Karakter animasyonu ger�ekle�irken karakterin y�n de�i�tirince animasyonunda de�i�mesini sa�lamak i�in
    private Vector3 charPos;            // yine anismayon fizi�i s�alamak i�in(r2d gibi) olu�turudlu ancak el ile y�netilir
    [SerializeField] private GameObject _camera;     //kamera objesini programda olu�turduk SER�ALZED F�ELD OBJEY� EKRANDA CACHELEMYEY YARAR GET COMPONENNT KULLANMADAN !!!
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>(); //caching yap�s�
        _animator = GetComponent<Animator>();//
        charPos = transform.position; // HER GAME OBJEN�N TRANSORMU VAR POS�T�ONA BA�LAYIP HAREKET ETT�R�YORUZ
    }

    private void FixedUpdate()  // Fiizksel bilgileri i�eren yap� PER FRAME �ALI�MAZ!   50 fps �al���r
    {
  //      r2d.velocity = new Vector2(speed, 0.0f);// karakterin h�z de�i�keni ile orant�l� haraketini sa�lad�k (ileriye/geriye)   EL�M�ZLE HAREKET YAZDI�IM ���N KAPATTIM
    }
    private void Update()  // per frame �al���r(her saniye)
    {
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y); // delta zaman� frameler aras� zaman� tutuyo ondan dolay� h�zla �arpt�k. horizontal axisli k�s�m sa�a veya sola gidilmesini sa�layacak de�eri - veya + yaparak
        transform.position = charPos; // yukar�da yap�lan y�r�me i�lemini karakter objesine y�kl�yoruz
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);    // animasyuon i�indeki h�z de�i�kenlkerini ba�lad�k
        }
        if (Input.GetAxis("Horizontal")> 0.01f) 
        {
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < -0.01f) { _spriteRenderer.flipX = true;}
    }
    private void LateUpdate() //en son �al��an update kamera kontrol� sa�lar
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f); //z de -1 olmas�n�n� sebebi kameran�n kahraman�n �st�nde durmas�ndan olu�an sorunun giderilmesi
    }
}
