using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxieMixer.Unity;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Game
{
    public class GameController : MonoBehaviour
    {
        public GameObject warShip;
        public GameObject player;
        public GameObject gamePause;
        // public GameObject gameCompelete;
        [SerializeField] AxieFigure _birdFigure;
        public float speed;
        [SerializeField] GameObject _startMsgGO;
        public static bool _isPlaying;

        [SerializeField] GameObject txtCountDownTimer;
        public int secondsLeft = 3;
        public bool takingAway = true;
        public static bool isContinueGame = false;
        public GameObject panel_GiftNFTToken;
        bool checkAudio = false;

        // Start is called before the first frame update
        void Start()
        {
            _isPlaying = false;
            Time.timeScale = 0f;
            txtCountDownTimer.GetComponent<Text>().text = secondsLeft + "";

            speed = 10;
            Mixer.Init();
            string axieId = PlayerPrefs.GetString("axieId");
            string genes = PlayerPrefs.GetString("genesStr");
            _birdFigure.SetGenes(axieId, genes);
        }

        // Update is called once per frame
        void Update()
        {

            if (!_isPlaying)
            {
                _startMsgGO.SetActive((Time.unscaledTime % .5 < .2));
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _startMsgGO.SetActive(false);
                    _isPlaying = true;
                    Time.timeScale = 1f;

                    txtCountDownTimer.SetActive(true);

                }
            }
            else
            {

                if (isContinueGame)
                {
                    if (warShip.transform.position.x < player.transform.position.x)
                    {
                        warShip.transform.Translate(Vector3.right * speed * Time.deltaTime);
                    }
                    else
                    {
                        player.GetComponent<BoxCollider2D>().isTrigger = true;
                        player.GetComponent<Rigidbody2D>().gravityScale = -0.05f;
                        rotatePlayerDie();
                        if (!checkAudio)
                        {
                            AudioManager.SetAudio("die");
                            checkAudio = true;
                        }

                    }
                    if ((player.transform.localPosition.x - warShip.transform.position.x) >= 20)
                    {
                        speed = 15;
                    }
                    if ((player.transform.localPosition.x - warShip.transform.position.x) <= 12)
                    {
                        speed = 10;
                    }
                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        gamePause.SetActive(true);
                        Time.timeScale = 0;
                    }
                }
            }

            if (takingAway == false && secondsLeft > 0)
            {
                StartCoroutine(TimeTake());
            }
        }
        public void gameLoad()
        {
            Time.timeScale = 1f;
            gamePause.SetActive(false);
            // gameCompelete.SetActive(false);
        }

        public void gameVoice()
        {

        }

        public void gameRestart()
        {
            gameLoad();
            SceneManager.LoadScene("Level_Game");
        }

        public void gameLobby()
        {
            SceneManager.LoadScene("Lobby");
        }

        IEnumerator TimeTake()
        {
            takingAway = true;
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
            txtCountDownTimer.GetComponent<Text>().text = secondsLeft + "";
            takingAway = false;
            if (secondsLeft == 0)
            {
                isContinueGame = true;
                txtCountDownTimer.SetActive(false);
            }
        }
        public void rotatePlayerDie()
        {
            if (player.transform.localScale.x >= 0)
            {
                player.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            }
            player.transform.Rotate(0, 0, -1f);
        }

        public void giftNFTToken()
        {
            panel_GiftNFTToken.SetActive(true);
        }

    }
}
