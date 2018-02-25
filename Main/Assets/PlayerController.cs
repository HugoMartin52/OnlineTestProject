using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [Header("Spells")]
    public GameObject fireBallPrefab;
    public GameObject aaPrefab;
    public GameObject swordPrefab;
    public Transform MiddleSpawn;

    [Space]
    public float CooldownFireBall = 5.0f;
    float Cdfb;
    public float CooldownAA = 1.0f;
    float Cdaa;
    public float CooldownSwordSwing = 3.0f;
    float Cdss;

    // Set initial moving variable
    [Header("Moving variables")]
    [SerializeField][Range(1,20)]
    private float speed = 10;
    public bool grounded;
    private Vector3 targetPosition;
    private Vector3 LookAtPosition;
    private bool isMoving;

    public string TargetTag;

    void Start()
    {
        // Set initial Timers
        Cdfb = 0.0f;
        Cdaa = 0.0f;
        Cdss = 0.0f;


        isMoving = false;
        targetPosition = transform.position;
    }

    void Update () {

        // Timers
        Cdfb -= Time.deltaTime;
        Cdaa -= Time.deltaTime;
        Cdss -= Time.deltaTime;


        // Check input keys et timer
        if (Input.GetKeyDown(KeyCode.Q) && Cdfb <= 0)
        {
            SetLookAtPosition();
            transform.LookAt(LookAtPosition);
            CmdFireQ();
            Cdfb = CooldownFireBall;
        }

        if(Input.GetMouseButtonDown(0) && Cdaa <= 0)
        {
            SetLookAtPosition();
            transform.LookAt(LookAtPosition);
            CmdAutoAttack();
            Cdaa = CooldownAA;
        }

        if (Input.GetKeyDown(KeyCode.W) && Cdss <= 0)
        {
            SetLookAtPosition();
            transform.LookAt(LookAtPosition);
            CmdSwordSwing();
            Cdss = CooldownSwordSwing;
        }


        // Deplacement
        if (Input.GetMouseButton(1) && !grounded)
            SetTargetPosition();
        
        if (isMoving)
            MovePlayer();
    }

    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            TargetTag = hit.collider.tag;
            if (TargetTag == "Floor")
            {
                targetPosition = hit.point + new Vector3(0, 1, 0);
            } else if (TargetTag == "Player"){
                targetPosition = transform.position;
            }
        }

        isMoving = true;
    }

    void SetLookAtPosition()
    {
        isMoving = false;
        targetPosition = transform.position;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            LookAtPosition = new Vector3(hit.point.x, 0, hit.point.z);
            Debug.DrawLine(transform.position, hit.point + Vector3.up, Color.blue, 2.0f);
        }
    }

    void MovePlayer()
    {
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
            isMoving = false;

        Debug.DrawLine(transform.position, targetPosition, Color.red);
    }

    void CmdFireQ()
    {
        // Création de la boule de feu à partir de la prefab "FireBall"
        var fireBall = (GameObject)Instantiate(
                fireBallPrefab,
                MiddleSpawn.position,
                MiddleSpawn.rotation);

            //Ajout de la vélocité
            fireBall.GetComponent<Rigidbody>().velocity = fireBall.transform.forward * 10;

            // Faire apparaitre la boule de feu sur les clients
            // NetworkServer.Spawn(fireBall);

            //Destruction de la balle après 2 secondes
            Destroy(fireBall, 2.0f);
    }
    
    void CmdAutoAttack()
    {

        // Création de la boule de feu à partir de la prefab "FireBall"
        var aa = (GameObject)Instantiate(
                aaPrefab,
                MiddleSpawn.position,
                MiddleSpawn.rotation);

        //Ajout de la vélocité
        aa.GetComponent<Rigidbody>().velocity = aa.transform.forward * 15;

        // Faire apparaitre la boule de feu sur les clients
        // NetworkServer.Spawn(aa);

        //Destruction de la balle après 2 secondes
        Destroy(aa, 2.0f);
    }


   void CmdSwordSwing()
    {

        var sword = (GameObject)Instantiate(
            swordPrefab,
            new Vector3(0,3,0),
            new Quaternion(0,0,0,0));

        sword.GetComponent<Transform>().position = new Vector3();

        
        // Destroy(sword, 2.0f);
    }

}
