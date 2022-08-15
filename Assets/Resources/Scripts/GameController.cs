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
        public static bool _isPlaying = false;

        [SerializeField] GameObject txtCountDownTimer;
        public int secondsLeft = 3;
        public bool takingAway = true;
        public static bool isContinueGame = false;

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0f;
            txtCountDownTimer.GetComponent<Text>().text = secondsLeft + "";

            speed = 10;
            Mixer.Init();
            string axieId = PlayerPrefs.GetString("selectingId", "5");
            string genes = PlayerPrefs.GetString("selectingGenes", "0x2000000000000300008100e08308000000010010088081040001000010a043020000009008004106000100100860c40200010000084081060001001410a04406");
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
                    warShip.transform.Translate(Vector3.right * speed * Time.deltaTime);
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
            Time.timeScale = 1;
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

        IEnumerator TimeTake()
        {
            takingAway = true;
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
            txtCountDownTimer.GetComponent<Text>().text = secondsLeft + "";
            takingAway = false;
            if(secondsLeft == 0)
            {
                isContinueGame = true;
                txtCountDownTimer.SetActive(false);
            }
        }
    }
}
