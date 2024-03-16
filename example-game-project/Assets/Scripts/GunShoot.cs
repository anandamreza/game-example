using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class GunShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform gun;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
        }
    }

    void Shooting()
    {
        Instantiate(bullet, gun.position, Quaternion.identity);
    }
}


