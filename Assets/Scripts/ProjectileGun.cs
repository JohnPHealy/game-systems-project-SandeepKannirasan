using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ProjectileGun : MonoBehaviour
{
    public Animator anim;

    //bullet
    public GameObject bullet;

    //bulletforce
    public float shootForce, upwardForce;

    //Gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    //Recoil
    public Rigidbody playerRb;
    public float recoilForce;

    int bulletsLeft, bulletShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    public bool allowInvoke = true;

    private void Awake()
    {
        //magazine full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {

        //setdisplay
        if (ammunitionDisplay != null) ;
           // ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + "/" + magazineSize / bulletsPerTap);
    }

public void shoot(InputAction.CallbackContext context)
    {

        

        //check if allowed to hold down button and take corresponding input
        if (allowButtonHold && context.performed)
            shooting = true;
        if (allowButtonHold && context.started)
            shooting = true;
       // if (allowButtonHold) shooting = context.performed; //Input.GetKey(KeyCode.Mouse0);
        //else shooting = context.started; //Input.GetKeyDown(KeyCode.Mouse0);

        //reloading
        //if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();
   

    //shooting
    if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletShot = 0;

            Shoot();
        }

        anim.SetTrigger("Throw");
    }

    private void Shoot()
    {
        readyToShoot = false;

        //find hit point using raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        //calculate direction from attack point to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //calcuateSpread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        //rotatebullet to shoot direction
        currentBullet.transform.forward = directionWithoutSpread.normalized;

        //Add force to bullet
        //currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        // currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce,ForceMode.Impulse);

        //instantiate muzzle flash, if you have one
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);


        bulletsLeft--;
        bulletShot++;

        //Invoke resetShot Function (if not invoked)
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil to player
            playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        //if more bulletPerTap, repeat function
        if (bulletShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }


}
