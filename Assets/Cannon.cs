using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    [SerializeField] Text velocityText;
    public GameObject Projectile;
    [SerializeField] Vector3 CannonAnglePower;
    public int CannonPower;
    Quaternion test;
    [SerializeField] int CannonRotation;
    [SerializeField] AudioSource Boom;
    [SerializeField] Transform CannonMuzzle;
    [SerializeField] Transform ShootFromTrans;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Boom.Play();

            CannonAnglePower = new Vector2(CannonPower, CannonPower);


            GameObject projectile = Instantiate(Projectile, ShootFromTrans.transform.position, ShootFromTrans.transform.rotation);
            projectile.GetComponent<Force>().AddForce(CannonAnglePower);
           
        }

    }

}
