using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingWarining : MonoBehaviour
{
    public GameObject warnImage;

    // Start is called before the first frame update
    void Start()
    {
        warnImage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3(Mathf.Sin(Time.time * 6) + 1,Mathf.Sin(Time.time * 6) + 1,Mathf.Sin(Time.time * 6) + 1);
        if (vec.x > 0.5  && vec.x < 1.0f) {
            warnImage.transform.localScale = vec;
        }
       
        
    }
    public void makeWarnAppear() {
        warnImage.SetActive(true);
        print("me toca spawnear!");
    }

    public void removeWarining() {
        warnImage.SetActive(false);
        print("me toca desaparece");
    }

}
