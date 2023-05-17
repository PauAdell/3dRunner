using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosionv2 : MonoBehaviour
{


    [SerializeField] public GameObject astpices;

    public float explosionForce = 10f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    // Use this for initialization
    void Start()
    {
        astpices.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
        {
            print("entroooo1");
            Spawn();
            print("entroooo2");
        }

    }

    public void explode()
    {
        //make object disappear
        gameObject.SetActive(false);
        astpices.transform.position = transform.position;
        astpices.transform.rotation = transform.rotation;
        astpices.SetActive(true);

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Debug.Log(hit.name);
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    private void Spawn()
    {
        gameObject.SetActive(false);
        astpices.transform.position = transform.position;
        astpices.transform.rotation = transform.rotation;
        astpices.SetActive(true);
        astpices.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        List<Transform> children = GetChildren(astpices.gameObject.transform, false);
        foreach (Transform child in children)
        {
            //Debug.Log(child.name);
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log(child.name);
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    List<Transform> GetChildren(Transform parent, bool recursive)
    {
        /** Get a list of children from a given parent, either the direct
            descendants or all recursively. **/

        List<Transform> children = new List<Transform>();

        foreach (Transform child in parent)
        {
            children.Add(child);
            if (recursive)
            {
                children.AddRange(GetChildren(child, true));
            }
        }

        return children;
    }

}