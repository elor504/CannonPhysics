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
    public int CannonRBPower => CannonPower * 2000;
    Quaternion test;
    public int CannonRotation;
    [SerializeField] AudioSource Boom;
    [SerializeField] Transform CannonMuzzle;
    [SerializeField] Transform ShootFromKinematic;
    [SerializeField] Transform ShootNormal;
    public bool isShootingCalculated;
    public bool isShootingRigidBody;
    [SerializeField] bool isShootingKinematic1;
    [SerializeField] bool isShootingKinematic2;

    public int cannonHeight;

    SpriteRenderer sprite;








    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CannonMuzzle.rotation.x != CannonRotation)
        {
            CannonRotation = Mathf.Clamp(CannonRotation, 0, 90);
            CannonMuzzle.localEulerAngles = new Vector3(CannonRotation, 0, 0);

        }
        if(transform.position.y != cannonHeight)
        {
            transform.position = new Vector2(transform.position.x, cannonHeight);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isShootingCalculated)
            ShootKinematic();
            if(isShootingRigidBody)
                shootRB();
        }

    }

    void ShootKinematic()
    {
        Boom.Play();

        CannonAnglePower = new Vector2(CannonPower, CannonPower);


        GameObject projectile = Instantiate(Projectile, ShootFromKinematic.transform.position, ShootFromKinematic.transform.rotation);
        projectile.GetComponent<Rigidbody>().isKinematic = isShootingKinematic1;
        projectile.GetComponent<Force>().AddForce(CannonMuzzle.rotation * Vector3.back * CannonPower);



    }
    void shootRB()
    {
        Boom.Play();

        CannonAnglePower = new Vector2(CannonPower, CannonPower);


        GameObject projectile = Instantiate(Projectile, ShootNormal.transform.position, ShootNormal.transform.rotation);
        projectile.GetComponent<Rigidbody>().isKinematic = isShootingKinematic2;
        projectile.GetComponent<Rigidbody>().AddForce(CannonMuzzle.rotation * Vector3.back * CannonRBPower);
        //projectile.GetComponent<Force>().AddForce(CannonMuzzle.rotation * Vector3.back * CannonPower);

    }






}
