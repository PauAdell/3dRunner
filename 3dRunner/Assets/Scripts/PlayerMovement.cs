using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator myAnim;
    public bool is_grounded;
    public bool girando;
    public int tile;
    private bool action;
    private bool action_g;
    public bool giro;
    public float jumpForce = 50.0f;
    public float speed = 9.0f;
    public int jump = 0;
    private Rigidbody playerRb;
    private int in_anim;
    public int muerte;
    public float current, target;
    public Vector3 goalPosition;
    public bool aprox;
    public bool god_mode;
    public bool auto_salto;
    public int grado_giro;
    private int numgiros;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        giro = false;
        muerte = 0;
        current = 0;
        god_mode = false;
        grado_giro = 0;
        numgiros = 0;
    }

    public int getNumGiros() {
        return numgiros;
    }

    // Update is called once per frame
    void Update()
     {
        action_g = Input.GetKeyDown(KeyCode.G);
        if (action_g) god_mode = !god_mode;
        action = Input.GetKeyDown(KeyCode.Space);
        if (tile == 1 && action && !giro && is_grounded)
        {
                girando = true;
                giro = true;
                aprox = true;
                current = transform.position.z;
        }
        else if (tile == 2 && action && !giro && is_grounded)
        {
                girando = true;
                giro = true;
                aprox = true;
                current = transform.position.x;
        }
        else if ((action && jump < 2 && in_anim == 0) || (auto_salto && in_anim == 0)) {
            myAnim.StopPlayback();
            myAnim.Play("Running jump");
            playerRb.AddForce(new Vector3(0, 0.5f, 0) * jumpForce, ForceMode.Impulse);
            in_anim = 180;
            ++jump;
            is_grounded = false;
            if (tile != 4) auto_salto = false;
            else tile = 3;
        }
        if (girando)
        {
            speed = 4;
            if (tile == 1)
            {
                transform.Rotate(new Vector3(0f, 3f, 0f));
                grado_giro += 3;
            }
            else if (tile == 2)
            {
                transform.Rotate(new Vector3(0f, -3f, 0f));
                grado_giro -= 3;
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
        if (muerte == 1 && in_anim == 0)
        {
            myAnim.StopPlayback();
            myAnim.Play("Walk to die");
            in_anim = 300;
        }
        else if (muerte == 2 && in_anim == 0)
        {
            myAnim.StopPlayback();
            myAnim.Play("Dying Backwards");
            in_anim = 300;
        }
        else transform.Translate(0, 0, speed * Time.deltaTime);
        if (aprox) {
            current = Mathf.MoveTowards(current, target, Time.deltaTime);
            Vector3 pos;
            if (tile == 1) pos = new Vector3(transform.position.x, transform.position.y, goalPosition.z);
            else pos = new Vector3(goalPosition.x, transform.position.y,transform.position.z);
            transform.position = Vector3.Lerp(transform.position, pos, current/target);
            if (transform.position == pos) aprox = false;
        }
        if (is_grounded && in_anim == 0) myAnim.Play("running");
    }
}