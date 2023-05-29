using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 pos_ini;
    public Quaternion rot_ini;
    public Animator myAnim;
    public bool is_grounded;
    public bool girando;
    public int tile;
    private bool action;
    private bool action_g;
    public bool giro;
    public float jumpForce = 1.0f;
    public float speed;
    public int jump;
    public Rigidbody playerRb;
    public int in_anim;
    public int muerte;
    public float current, target;
    public Vector3 goalPosition;
    public bool aprox;
    public bool god_mode;
    public bool auto_salto;
    public int grado_giro;
    private int numgiros;

    public bool start;
    public bool salto_corto;

    public GameObject menuMuerte;

    // Start is called before the first frame update
    void Start()
    {
        jump = 0;
        playerRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        giro = false;
        girando = false;
        muerte = 0;
        aprox = false;
        salto_corto = false;
        is_grounded = true;
        current = 0;
        god_mode = false;
        grado_giro = 0;
        in_anim = 0;
        auto_salto = false;
        start = false;
        myAnim.SetBool("start", false);
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        pos_ini = transform.position;
        rot_ini = transform.rotation;
        numgiros = 0;
    }

    public int getNumGiros() {
        return numgiros;
    }

    // Update is called once per frame
    void Update()
    {
        print(jump);
        if (transform.position.y + 0.1 < pos_ini.y) is_grounded = false;
        if (muerte == 5)
        {
            menuMuerte.SetActive(true);
            PauseMenu.jugadormort = true;
        }
        else
        {
            if (!start)
            {
                speed = 0;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    start = true;
                    myAnim.SetBool("start", true);
                    speed = 5;
                }
            }
            else if (muerte == 1 && in_anim == 0)
            {
                myAnim.StopPlayback();
                myAnim.Play("Walk to die");
                in_anim = 900;
                speed = 0;
            }
            else if (muerte == 2 && in_anim == 0)
            {
                myAnim.StopPlayback();
                myAnim.Play("Dying Backwards");
                in_anim = 900;
                speed = 0;
            }
            else if (muerte != 0 && in_anim != 0)
            {
                if (!PauseMenu.jocParat) --in_anim;
                if (in_anim == 0) muerte = 5;
            }
            else if (!PauseMenu.jocParat)
            {
                action_g = Input.GetKeyDown(KeyCode.G);
                if (action_g) god_mode = !god_mode;
                action = Input.GetKeyDown(KeyCode.Space);
                if (tile == 1 && action && !giro && is_grounded)
                { 
                    current = transform.position.z;
                    if (current < target + 1.6)
                    {
                        girando = true;
                        giro = true;
                        aprox = true;
                    }
                }
                else if (tile == 2 && action && !giro && is_grounded)
                {
                    current = transform.position.x;
                    if (current < target + 1.6)
                    {
                        girando = true;
                        giro = true;
                        aprox = true;
                    }
                  
                }
                else if ((action && jump < 2 && in_anim == 0) || (auto_salto && in_anim == 0))
                {
                    speed = 5.5f;
                    myAnim.StopPlayback();
                    myAnim.Play("Running jump");
                    playerRb.AddForce(new Vector3(0, 0.5f, 0) * jumpForce, ForceMode.Impulse);
                    in_anim = 250;
                    ++jump;
                    is_grounded = false;
                    if (tile != 4) auto_salto = false;
                    else tile = 3;
                }
                if (girando && is_grounded)
                {
                    speed = 4;
                    if (tile == 1)
                    {
                        transform.Rotate(new Vector3(0f, 5f, 0f));
                        grado_giro += 5;
                    }
                    else if (tile == 2)
                    {
                        transform.Rotate(new Vector3(0f, -5f, 0f));
                        grado_giro -= 5;
                    }
                    if (grado_giro == 90 || grado_giro == -90)
                    {
                        girando = false;
                        numgiros += 1;
                        grado_giro = 0;
                        speed = 5;
                    }
                }
                if (in_anim > 0) --in_anim;
                if (muerte > 0) in_anim = 0;

                transform.Translate(0, 0, speed * Time.deltaTime);

                if (aprox && is_grounded)
                {
                    current = Mathf.MoveTowards(current, target, Time.deltaTime);
                    Vector3 pos;
                    if (tile == 1) pos = new Vector3(transform.position.x, transform.position.y, goalPosition.z);
                    else pos = new Vector3(goalPosition.x, transform.position.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, pos, current / target);
                    if (transform.position == pos) aprox = false;
                }
                if (salto_corto && in_anim == 0)
                {
                    salto_corto = false;
                    playerRb.AddForce(new Vector3(0, 0, -2f) * jumpForce, ForceMode.Impulse);
                    in_anim = 1000;
                    speed = 1;
                }
                else if (is_grounded && in_anim == 0) myAnim.Play("running");

            }
        }
    }

    public void startFromZero()
    {
        PauseMenu.jugadormort = false;
        jump = 0;
        playerRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        giro = false;
        girando = false;
        muerte = 0;
        aprox = false;
        is_grounded = true;
        current = 0;
        in_anim = 0;
        god_mode = false;
        grado_giro = 0;
        auto_salto = false;
        start = false;
        myAnim.SetBool("start", false);
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        transform.position = pos_ini;
        myAnim.Play("Idle");
        salto_corto = false;
        playerRb.isKinematic = false;
        numgiros = 0;
        menuMuerte.SetActive(false);
        transform.rotation = rot_ini;
    }

}