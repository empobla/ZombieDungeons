/*
Script to shoot the bullets using left click
use of raycast.

Author Jorge Damian Palacios Hristova
*/


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour
{
    public float damage = 10f;
    public float forceBullet = 30f;
    public float fireRate = 15f;
    public ParticleSystem flashdisparo;
    public GameObject DefaultHit;
    private float nextTimeShoot = 0f;

    public int maxAmmo = 20;
    private int currentAmmo;
    public float reloadTime = 5f;
    private bool isReloading = false; 
    public Text ammoDisplay = null;

    [SerializeField]
    private AudioSource shoot;
    [SerializeField]
    private AudioSource reload;
    public int range;

    
     void Start() 
    {
        
        currentAmmo =  maxAmmo;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if(isReloading)
            return;

        if (currentAmmo <= 0)
        {
             ammoDisplay.text = currentAmmo.ToString();
            StartCoroutine(Reload());
            return;
        }

       
        //when the left click is press it will shoot 
        if (Input.GetButton("Fire1") && Time.time >= nextTimeShoot)
        {
            shoot.Play();
            ammoDisplay.text = currentAmmo.ToString();
            nextTimeShoot = Time.time +1f/fireRate;
            Shoot();  
        }

    }

    IEnumerator Reload()
    {   
        reload.Play();
       //animate.SetBool("Reloading",true);
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
         ammoDisplay.text = currentAmmo.ToString();
        isReloading = false;
    }
    void Shoot()
    {
        
        //generate particles to simulate the bullet going out and hiting the enemy
        flashdisparo.Play();//generate the particles of shooting
        currentAmmo--;

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        RaycastHit hit;

       if(Physics.Raycast(ray, out hit,range)) 
       {
           Debug.Log(hit.transform.name);
           Target target = hit.transform.GetComponent<Target>();

           if (target != null)
           {
               target.TakeDamage(damage);//call the function to kill target 
           }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal *forceBullet);//hit rigidbody
            }
           GameObject impactGO= Instantiate(DefaultHit,hit.point, Quaternion.LookRotation(hit.normal));
           Destroy(impactGO,2f);//destroy de bullets 
       }
    }
}
  
