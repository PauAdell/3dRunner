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
    public float initial_speed;
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
    public int timer_god;
    public int time_to_gir;
    public bool cayendo;
    public bool start;
    public bool salto_corto;
    public Material novaTextura;
    public bool victory;
    bool menu_victoria;

    private GameObject[] tilesdegiro;
    public GameObject menuMuerte;
    public GameObject menuWin;
    public GameObject monedas;
    public GameObject giros;
    public GameObject imagen_m;
    public GameObject imagen_g;
    public GameObject pressstarttxt;
    public SoundEffects sounds;


    // Start is called before the first frame update
    void Start()
    {
        sounds.playPlayMusic();
        jump = 0;
        victory = false;
        initial_speed = speed;
        timer_god = 0;
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
        time_to_gir = 0;
        Application.targetFrameRate = 200;
        monedas.SetActive(true);
        giros.SetActive(true);
        imagen_g.SetActive(true);
        imagen_m.SetActive(true);
        pressstarttxt.SetActive(true);
    }

    public int getNumGiros() {
        return numgiros;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y + 0.1 < pos_ini.y) is_grounded = false;
        if (muerte == 5)
        {
            menuMuerte.SetActive(true);
            monedas.SetActive(false);
            giros.SetActive(false);
            imagen_g.SetActive(false);
            imagen_m.SetActive(false);
            PauseMenu.jugadormort = true;
        }
        else if (victory)
        {
            myAnim.Play("Victory");
            menu_victoria = true;
            menuWin.SetActive(true);
            monedas.SetActive(false);
            giros.SetActive(false);
            imagen_g.SetActive(false);
            imagen_m.SetActive(false);
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
                sounds.playDeathSound();
                if (!is_grounded) playerRb.AddForce(new Vector3(0, -0.5f, 0) * jumpForce, ForceMode.Impulse);
                myAnim.Play("Walk to die");
                in_anim = 425;
                speed = 0;
            }
            else if (muerte == 2 && in_anim == 0)
            {
                myAnim.StopPlayback();
                sounds.playDeathSound();
                if (!is_grounded) playerRb.AddForce(new Vector3(0, -0.5f, 0) * jumpForce, ForceMode.Impulse);
                myAnim.Play("Dying Backwards");
                in_anim = 425;
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
                if (god_mode) action = false;
                if (tile == 1 && action && !giro && is_grounded && time_to_gir == 0)
                { 
                    current = transform.position.z;
                    if (current < target + 1.8)
                    {
                        girando = true;
                        giro = true;
                        aprox = true;
                    }
                }
                else if (tile == 2 && action && !giro && is_grounded && time_to_gir == 0)
                {
                    current = transform.position.x;
                    if (current < target + 1.8)
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
                    in_anim = 90;
                    ++jump;
                    is_grounded = false;
                    sounds.playJumpSound();
                    if (tile != 4) auto_salto = false;
                    else tile = 3;
                }
                if (girando && is_grounded && timer_god == 0)
                {
                    speed = 5.5f;
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
                        time_to_gir = 200;
                        girando = false;
                        numgiros += 1;
                        grado_giro = 0;
                        giro = false;
                        speed = 5;
                    }
                }
                if (timer_god > 0) timer_god -= 1;
                if (in_anim > 0) --in_anim;
                if (muerte > 0) in_anim = 0;
                if (time_to_gir > 0) --time_to_gir;

                if (!cayendo) transform.Translate(0, 0, speed * Time.deltaTime);

                if (aprox && is_grounded && timer_god == 0)
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
                    myAnim.Play("falling");
                    playerRb.AddForce(new Vector3(0, 0, -2f) * 5, ForceMode.Impulse);
                    in_anim = 300;
                    speed = 1;
                    cayendo = true;
                }
                else if (is_grounded && in_anim == 0 && transform.position.y <= pos_ini.y + 0.1) myAnim.Play("running");
                if (!is_grounded) speed = initial_speed;
                if (start) pressstarttxt.SetActive(false);
            }
        }
    }

    public void startFromZero()
    {
        if (menu_victoria) {
            menuWin.SetActive(false);
            menu_victoria = false;
        }
        PauseMenu.jugadormort = false;
        jump = 0;
        playerRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        giro = false;
        girando = false;
        muerte = 0;
        time_to_gir = 0;
        aprox = false;
        speed = initial_speed;
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
        victory = false;
        playerRb.isKinematic = false;
        numgiros = 0;
        menuMuerte.SetActive(false);
        transform.rotation = rot_ini;
        sounds.stopMusic();
        sounds.playPlayMusic();
        cayendo = false;
        monedas.SetActive(true);
        giros.SetActive(true);
        imagen_g.SetActive(true);
        imagen_m.SetActive(true);
        pressstarttxt.SetActive(true);
        tilesdegiro = GameObject.FindGameObjectsWithTag("RightTile");
        foreach (GameObject t in tilesdegiro)
        {
            t.gameObject.GetComponent<Renderer>().material = novaTextura;
        }
        tilesdegiro = GameObject.FindGameObjectsWithTag("LeftTile");
        foreach (GameObject t in tilesdegiro)
        {
            t.gameObject.GetComponent<Renderer>().material = novaTextura;
        }
    }

}