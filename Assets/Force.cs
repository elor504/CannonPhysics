using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{


    List<Vector3> forces = new List<Vector3>();
    Vector3 shakul;
    float gravityCounter = 0f;
    [SerializeField] Vector3 gravity;

    Rigidbody rb;


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddForce(Vector3 _Force)
    {

        forces.Add(_Force);
    }
    //public void ShootDirection(int Power)
    //{
    //    rb.AddForce(Vector3.right * (Power / 2), ForceMode.Impulse);
    //}
    private void Update()
    {

    }
    private void FixedUpdate()
    {

        gravityCounter += Time.fixedDeltaTime;
        shakul = Vector3.zero;
        for (int i = 0; i < forces.Count; i++)
        {
            shakul += forces[i];
        }
        shakul += gravityCounter * gravity;

        if (rb.isKinematic)
        {
            rb.position = transform.position + shakul;
        }
        else
        {

            Vector3 pos = transform.position;
            //do changes
            pos += shakul;
            transform.position = pos;

        }

        //transform.Translate(shakul);




        if (transform.position.y < -5)
        {
            transform.GetChild(0).SetParent(null);


            Destroy(this.gameObject);
        }


    }


}
