using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace DefaultNamespace{
    public class InteractablePhone : MonoBehaviour{
        public Collider2D player, phone;
        private Random rand = new Random();
        string[] reqsAsString = new[]{"One plant stat!", "Give me two plants! Right now"};
        int[] reqsNum = new[]{1, 2};
        private bool gettingRequest;
        public Text currRequest;
        private int numRequests = 0;
        private bool initalTimeOver, ringing;
        private float initialRingTime = 10.0f;
        private float timeInBetweenRings = 10.0f, ringTime = 5.0f, waitBeforeHide = 5.0f;
        public AudioSource ringSound;

        void Start(){
            currRequest.gameObject.SetActive(false);
            ringSound = GetComponent<AudioSource>();
        }

        void getRequest(){
            gettingRequest = true;
            int index = rand.Next(reqsAsString.Length);
            currRequest.text = reqsAsString[index];
            currRequest.gameObject.SetActive(true);
            Global.orders.Enqueue(reqsNum[index]);
        }

        void Update(){
            if (Time.time > initialRingTime){
                if (ringTime > 0){
                    if (!ringSound.isPlaying)
                        ringSound.Play(0);
                    ringTime -= (Time.deltaTime);
                    ringing = true;
                }
                else{
                    ringTime = 3.0f;
                    ringing = false;
                    ringSound.Stop();
                    initialRingTime = Time.time + timeInBetweenRings;
                    gettingRequest = false;
                }
            }

            if (player.IsTouching(phone) && !gettingRequest && ringing){
                getRequest();
            }
            else{
                if (waitBeforeHide > 0){
                    waitBeforeHide -= (Time.deltaTime);
                }
                else{
                    currRequest.gameObject.SetActive(false);
                    waitBeforeHide = 5.0f;
                }
                
            }
        }
    }
}