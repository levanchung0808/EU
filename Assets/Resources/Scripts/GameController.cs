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

        // Start is called before the first frame update
        void Start()
        {
            speed = 10;
            Mixer.Init();
            string axieId = PlayerPrefs.GetString("selectingId", "2727");
            string genes = PlayerPrefs.GetString("selectingGenes", "0x2000000000000300008100e08308000000010010088081040001000010a043020000009008004106000100100860c40200010000084081060001001410a04406");
            _birdFigure.SetGenes(axieId, genes);
        }

        // Update is called once per frame
        void Update()
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
            if(Input.GetKeyDown(KeyCode.P))
            {
                gamePause.SetActive(true);
                Time.timeScale = 0;
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
    }
}
