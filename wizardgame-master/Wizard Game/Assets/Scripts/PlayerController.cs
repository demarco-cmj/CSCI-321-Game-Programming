using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform spawnPoint;
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float jumpHeight = 10f;
    public float gravity;
    public GameObject menu;
    public GameObject UICanvas;
    public GameObject winScreen;
    //public var hearts : GameObject[] = new GameObject[6];
    public GameObject[] hearts;
    
    private bool onGround = true;
    private bool onBouncy = false;
    private bool recordTime = true;
    private int bounceTimer = 0;

    private float movementX;
    private float movementY;

    private Rigidbody playerBody;
    public Transform TP;
    
    //Audio
    private AudioSource jumpSFX;
    public AudioClip[] jumps;
    private AudioSource bounceSFX;
    public AudioClip[] bounces;
    private AudioSource injureSFX;
    public AudioClip[] injures;
    private AudioSource menuSFX;
    public AudioClip menuClip;


    private Ray ray;
    private RaycastHit hit;
    private float attackDistance = 5f;

    private PlayerAnimationController animController;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        this.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
        // hearts = new GameObject[6];
        //jumpSFX = gameObject.GetComponent<AudioSource>();


        // Allow hiding of UICanvas in editor by enabling on start
        UICanvas.gameObject.SetActive(true);

        // Fix for gravity due to variable scales between scenes -- set manually from editor
        Physics.gravity = new Vector3(0f, gravity, 0f);
        AudioSource jumpSFX = gameObject.AddComponent<AudioSource>();

        animController = GetComponent<PlayerAnimationController>();
    }

    void FixedUpdate() {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        float lookH = Input.GetAxis("Mouse X");
        float lookV = Input.GetAxis("Mouse Y");

        Vector3 movement = new Vector3(moveH, 0f, moveV);
        Vector3 rotation = new Vector3(0f, lookH, 0f);
        transform.Translate(movement * Time.deltaTime * moveSpeed);
        transform.Rotate(rotation * Time.deltaTime * rotationSpeed);
    }

    void Update() {
        //Keep track of time
        if(recordTime){
            GameVariables.timeElapsed += Time.deltaTime;
            if(winScreen) {
                winScreen.SetActive(false);
            }
        }

        if(onBouncy){
            bounceTimer++;
        }

        if (Input.GetButtonDown("Jump") && onGround) {
            print("jumping");

            float tempJumpHeight = jumpHeight;
            if(onBouncy && bounceTimer < 60){
                tempJumpHeight = jumpHeight * 2; //BOUNCE AMOUNT

                //Play Random Bounce SFX
                int j = Random.Range(0, bounces.Length);
                AudioSource bounceSFX = gameObject.AddComponent<AudioSource>();
                bounceSFX.clip = bounces[j];
                bounceSFX.Play();
                Destroy(bounceSFX, 2);
            }

            playerBody.AddForce(new Vector3(0f, tempJumpHeight * 10, 0f));

            //Play Random Jump SFX
            int i = Random.Range(0, jumps.Length);
            AudioSource jumpSFX = gameObject.AddComponent<AudioSource>();
            jumpSFX.clip = jumps[i];
            jumpSFX.Play();
            Destroy(jumpSFX, 2);

            onGround = false;
            onBouncy = false;
            bounceTimer = 0;
        }
        
        //User Interface

        if (Input.GetButtonDown("ToggleUI")){
            menu.SetActive(!menu.activeInHierarchy);
            AudioSource menuSFX = gameObject.AddComponent<AudioSource>();
            menuSFX.clip = menuClip;
            menuSFX.Play();
            Destroy(menuSFX, 2);
        }

        //Display Health
        //DisplayHealth.CheckHP(); //TODO
        switch(GameVariables.playerHealth){
            case 0:
                for(int i = 0; i < 6; i++){
                        hearts[i].SetActive(false);
                }
                break;
            case 1:
                hearts[0].SetActive(true);
                for(int i = 0; i < 6; i++){
                    if(i != 0){
                        hearts[i].SetActive(false);
                    }
                }
                break;
            case 2:
                hearts[1].SetActive(true);
                for(int i = 0; i < 6; i++){
                    if(i != 1){
                        hearts[i].SetActive(false);
                    }
                }
                break;
            case 3:
                hearts[2].SetActive(true);
                for(int i = 0; i < 6; i++){
                    if(i != 2){
                        hearts[i].SetActive(false);
                    }
                }
                break;
            case 4:
                hearts[3].SetActive(true);
                for(int i = 0; i < 6; i++){
                    if(i != 3){
                        hearts[i].SetActive(false);
                    }
                }
                break;
            case 5:
                hearts[4].SetActive(true);
                for(int i = 0; i < 6; i++){
                    if(i != 4){
                        hearts[i].SetActive(false);
                    }
                }
                break;
            case 6:
                hearts[5].SetActive(true);
                for(int i = 0; i < 6; i++){
                    if(i != 5){
                        hearts[i].SetActive(false);
                    }
                }
                break;
        }

        //Check HP
        if(GameVariables.playerHealth <= 0){
            //Reset Health and TP to start - Must connect TP target
            this.transform.position = TP.transform.position;
            GameVariables.playerHealth = 6;
            GameVariables.deaths += 1;

            //OR Reload Scene
            // print("Resetting");
            // SceneManager.LoadScene("Main Level");
        }

        //Check win condition
        if(GameVariables.redGems == 4 && GameVariables.blueGems == 4 && GameVariables.yellowGems == 4){
            //print("Player won");
            recordTime = false;
            if(winScreen) {
                winScreen.SetActive(true);
            }
        }
        
        //code for attack
        if (Input.GetButtonDown("Fire1")) 
        {
            //draw a ray outwards
            //if the ray hits object tagged "bee", do thing:
            ray = new Ray(transform.position + new Vector3(0f, 3f, 0f), transform.forward);
            //tell animator to animate attack
            animController.Attack();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Enemy" && hit.distance < attackDistance) 
                {
                    
                    //get controller for collided enemy
                    BeeController bee = hit.collider.gameObject.GetComponent<BeeController>();
                    //enemy dies
                    bee.Die();

                    
                }
            }
        }
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnCollisionEnter(Collision other) {
        print("on the ground");
        onGround = true;

        if(other.gameObject.tag == "Bouncy"){
            onBouncy = true;
        }
        else{
            onBouncy = false;
        }

        if(other.gameObject.tag == "Water"){
            playerBody.AddForce(new Vector3(0f, 100, 0f));
            injurePlayer(1);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Water")){
            playerBody.AddForce(new Vector3(0f, 500, 0f));
            GameVariables.playerHealth -= 1;
        }
    }

    // void OnTriggerExit(Collider other) {
    //     if(other.gameObject.CompareTag("Water")) {
            
    //     }
    // }
    
    void injurePlayer(int amount) {
        GameVariables.playerHealth -= amount;
        int i = Random.Range(0, injures.Length);
        AudioSource injureSFX = gameObject.AddComponent<AudioSource>();
        injureSFX.clip = injures[i];
        injureSFX.Play();
        Destroy(injureSFX, 2);
    }
}
