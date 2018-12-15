using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerak : MonoBehaviour {

    Text infonyawa, infokoin;

    public int kecepatan, kekuatanlompat;

    public bool balik;
    public int pindah;

    Rigidbody2D lompat;

    public bool tanah;
    public LayerMask targetlayar;
    public Transform deteksitanah;
    public float jangkawan;

    public int nyawa;
    public int koin;

    Animator anim;

    Vector2 mulai;
    public bool ulang;

    public bool tombolkiri;
    public bool tombolkanan;
    public bool tombollompat;

    public GameObject menang, kalah;

    // Use this for initialization
    void Start () {
        infonyawa = GameObject.Find("unitynyawa").GetComponent<Text>();
        infokoin = GameObject.Find("unitykoin").GetComponent<Text>();
        lompat = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        mulai = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        infonyawa.text = "Nyawa : " + nyawa.ToString();
        infokoin.text = "Koin : " + koin.ToString();

        if (ulang == true)
        {
            transform.position = mulai;
            mulai = transform.position;
            ulang = false;
        }

        if (nyawa <= 0)
        {
            Destroy(gameObject);
            print("anda kalah");
            kalah.SetActive(true);
            menang.SetActive(false);
        }
        else if (koin >=7)
        {
            menang.SetActive(true);
            kalah.SetActive(false);
        }

        if (tanah == false)
        {
            anim.SetBool("lompat", true);
        }
        else
        {
            anim.SetBool("lompat", false);
        }

        tanah = Physics2D.OverlapCircle(deteksitanah.position, jangkawan, targetlayar);

        if (Input.GetKey(KeyCode.D) || (tombolkanan == true))
        {
            anim.SetBool("lari", true);
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah = 1;
        }else if (Input.GetKey(KeyCode.A) || (tombolkiri == true))
        {
            anim.SetBool("lari", true);
            transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            pindah = -1;
        }
        else
        {
            anim.SetBool("lari", false);
        }

        if (tanah == true && ((Input.GetKey(KeyCode.W)) || tombollompat == true))
        {
            lompat.AddForce(new Vector2(0,kekuatanlompat));
        }

        if (pindah >0 && !balik)
        {
            berbalik();
        }else if (pindah < 0 && balik)
        {
            berbalik();
        }
    }

    void berbalik()
    {
        balik = !balik;
        Vector3 karakter = transform.localScale;
        karakter.x *= -1;
        transform.localScale = karakter;
    }

    public void tekankiri()
    {
        tombolkiri = true;
    }

    public void lepaskiri()
    {
        tombolkiri = false;
    }

    public void tekankanan()
    {
        tombolkanan = true;
    }

    public void lepaskanan()
    {
        tombolkanan = false;
    }

    public void tekanlompat()
    {
        tombollompat = true;
    }

    public void lepaslompat()
    {
        tombollompat= false;
    }
}
