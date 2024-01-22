using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;            //hareketi saðlayacak rigidbodyyi oluþturduk
    private Animator _animator;         //animasyon yürütmek için
    private SpriteRenderer _spriteRenderer; //Karakter animasyonu gerçekleþirken karakterin yön deðiþtirince animasyonunda deðiþmesini saðlamak için
    private Vector3 charPos;            // yine anismayon fiziði sðalamak için(r2d gibi) oluþturudlu ancak el ile yönetilir
    [SerializeField] private GameObject _camera;     //kamera objesini programda oluþturduk SERÝALZED FÝELD OBJEYÝ EKRANDA CACHELEMYEY YARAR GET COMPONENNT KULLANMADAN !!!
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>(); //caching yapýsý
        _animator = GetComponent<Animator>();//
        charPos = transform.position; // HER GAME OBJENÝN TRANSORMU VAR POSÝTÝONA BAÐLAYIP HAREKET ETTÝRÝYORUZ
    }

    private void FixedUpdate()  // Fiizksel bilgileri içeren yapý PER FRAME ÇALIÞMAZ!   50 fps çalýþýr
    {
  //      r2d.velocity = new Vector2(speed, 0.0f);// karakterin hýz deðiþkeni ile orantýlý haraketini saðladýk (ileriye/geriye)   ELÝMÝZLE HAREKET YAZDIÐIM ÝÇÝN KAPATTIM
    }
    private void Update()  // per frame çalýþýr(her saniye)
    {
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y); // delta zamaný frameler arasý zamaný tutuyo ondan dolayý hýzla çarptýk. horizontal axisli kýsým saða veya sola gidilmesini saðlayacak deðeri - veya + yaparak
        transform.position = charPos; // yukarýda yapýlan yürüme iþlemini karakter objesine yüklüyoruz
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);    // animasyuon içindeki hýz deðiþkenlkerini baðladýk
        }
        if (Input.GetAxis("Horizontal")> 0.01f) 
        {
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < -0.01f) { _spriteRenderer.flipX = true;}
    }
    private void LateUpdate() //en son çalýþan update kamera kontrolü saðlar
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f); //z de -1 olmasýnýný sebebi kameranýn kahramanýn üstünde durmasýndan oluþan sorunun giderilmesi
    }
}
