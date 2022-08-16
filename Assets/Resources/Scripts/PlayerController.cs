using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        public AxieFigure figure;
        public float velocity;
        public float speed;
        public float boostTimer, slowTimer;
        public bool boosting, slowing;
        public bool collider = false;
        //shooting
        public Transform firePosition;
        public GameObject projectile;
        public GameObject buffSpeed;
        public GameObject debuffSpeed;
        public GameObject shilde;
        public GameObject jumpEffect;
        public GameObject winZone;
        public bool canShoot = true;
        public float cooldownTimeShotting;
        public int ammoAmount;
        public Text txtNumAmmo;
        GameObject objProjectitle;


        //Progressbar distance player to win
        public Slider sldProgressBarPercent;
        float maxDistance;
        //Position end map
        int jumpCount = 2;
        //Audio
        static AudioSource audio;
        public AudioClip clickSound;
        //GUI
        public GameObject panel_YouLose, panel_YouWin;

        void Start()
        {
            audio = GetComponent<AudioSource>();
            figure = gameObject.GetComponentInChildren<AxieFigure>();
            speed = 10;
            velocity = 1;
            boostTimer = 0;
            slowTimer = 0;
            boosting = false;
            slowing = false;
            cooldownTimeShotting = 0.5f;
            ammoAmount = 5;
            txtNumAmmo.text = ammoAmount.ToString();
            maxDistance = getDistance();
        }

        // Update is called once per frame
        void Update()
        {

            if (GameController._isPlaying && GameController.isContinueGame)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (Input.GetKeyDown(KeyCode.Space) && jumpCount != 0)
                {
                    AudioManager.SetAudio("jump");
                    figure?.DoJumpAnim();
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, velocity * 500));
                    Instantiate(jumpEffect, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                    jumpCount--;
                }

                if (boosting)
                {
                    boostTimer += Time.deltaTime;
                    if (boostTimer >= 3)
                    {
                        speed = 10;
                        boostTimer = 0;
                        boosting = false;
                    }
                }

                if (slowing)
                {
                    slowTimer += Time.deltaTime;
                    if (slowTimer >= 3)
                    {
                        speed = 10;
                        boostTimer = 0;
                        boosting = false;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Mouse0) && ammoAmount > 0)
                {
                    if (canShoot)
                    {
                        figure?.Attack();
                        StartCoroutine(shoot());
                        AudioManager.SetAudio("fire");
                        ammoAmount -= 1;
                        txtNumAmmo.text = ammoAmount.ToString();
                    }
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    var myShilde = Instantiate(shilde, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    myShilde.transform.parent = gameObject.transform;
                }
                //Distance start position to end position
                if (transform.position.x <= winZone.transform.position.x)
                {
                    float distance = 1 - (getDistance() / maxDistance);
                    setProgress(distance);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.tag == "LightWareship")
            {
                speed = 0;
                boostTimer = 0;
                slowTimer = 0;
                boosting = false;
                slowing = false;
                //panel_YouLose.SetActive(true);
            }
            if (collision.tag == "TheShip")
            {
                Time.timeScale = 0f;
                panel_YouLose.SetActive(true);
            }
            if (collision.tag == "BuffSpeed")
            {
                figure?.GetBuff();
                boosting = true;
                speed = 12;
                Destroy(collision.gameObject);
                var myBuffSpeed = Instantiate(buffSpeed, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                myBuffSpeed.transform.parent = gameObject.transform;
            }
            if (collision.tag == "BuffShield")
            {
                var myShilde = Instantiate(shilde, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                myShilde.transform.parent = gameObject.transform;
                Destroy(collision.gameObject);
            }
            if (collision.tag == "SlowSpeed")
            {
                figure?.GetDeBuff();
                boosting = true;
                speed = 8;
                Destroy(collision.gameObject);
                var myDeBuffSpeed = Instantiate(debuffSpeed, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                myDeBuffSpeed.transform.parent = gameObject.transform;
            }
            if (collision.tag == "winZone")
            {
                panel_YouWin.SetActive(true);
                AudioManager.SetAudio("wingame");
                GameController.isContinueGame = false;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "isGround")
            {
                jumpCount = 2;
            }
            if (collision.gameObject.tag == "lava")
            {
                 figure?.Die();
                boostTimer = 0;
                slowTimer = 0;
                boosting = false;
                slowing = false;
                speed = 0;
            }
            if (collision.gameObject.tag == "Collider")
            {
                figure?.Corlider();
            }
        }
        public IEnumerator shoot()
        {
            shootLogic();
            canShoot = false;
            //wait for some time
            yield return new WaitForSeconds(cooldownTimeShotting);
            canShoot = true;
        }

        void shootLogic()
        {
            objProjectitle = Instantiate(projectile, firePosition.position, firePosition.rotation);
            if (transform.localScale.x == -0.2f)
            {
                objProjectitle.transform.eulerAngles = new Vector3(0f, 0f, 180f);
            }
            else
            {
                objProjectitle.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }

        float getDistance()
        {
            return winZone.transform.position.x - transform.position.x;
        }

        void setProgress(float p)
        {
            sldProgressBarPercent.value = p;
        }
    }
}
