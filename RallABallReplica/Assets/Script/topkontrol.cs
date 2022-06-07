using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topkontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    private Rigidbody rg;
    public float hiz=100f;
    public UnityEngine.UI.Text zaman, can, durum;
    public float zamanSayaci = 20;
    public int canSayaci=3;
    public bool oyunDevam=true;
    public bool oyunTamam=false;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
         if (zamanSayaci < 0)
        {
            oyunDevam = false;
            durum.text = "Zaman Bitti Kaybettiniz";
            btn.gameObject.SetActive(true);
        }
        

        
    }
    private void FixedUpdate()
    {
       if (oyunDevam&&!oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rg.AddForce(kuvvet* hiz*Time.deltaTime);
         }
        else 
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="bitti")
        {
            oyunTamam = true;
            durum.text = "Oyun Tamlandý, Tebrikler";
            btn.gameObject.SetActive(true);
        }
        else if (collision.gameObject.tag == "duvar")
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci==0)
            {
                oyunDevam = false;
                durum.text = "Can Bitti Kaybettiniz";
                btn.gameObject.SetActive(true);

            }
        }

    }
}
