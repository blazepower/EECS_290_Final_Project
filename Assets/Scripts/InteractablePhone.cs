using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace DefaultNamespace{
    public class InteractablePhone : MonoBehaviour{
        public Collider2D player, phone;
        private Random rand = new Random();
        private Text[] requests = new Text[60];
        private bool gettingRequest;
        private Text currRequest;
        private int numRequests = 0;
        public Text requestToBeAdded;
        private bool initalTimeOver, ringing;
        private float initialRingTime = 10.0f;
        private float timeInBetweenRings = 10.0f, ringTime = 3.0f ;
        public AudioSource ringSound;

        void Start(){
            string[] reqsAsString = new[]{"One plant stat!", "Give me two plants! Right now"};
            int[] reqsNum = new[]{1, 2};
            foreach (string s in reqsAsString){
                requestToBeAdded.text = s;
                requests[numRequests] = requestToBeAdded;
                numRequests++;
            }

            ringSound = GetComponent<AudioSource>();
        }

        void getRequest(){
            gettingRequest = true;
            int index = rand.Next(requests.Length);
            currRequest = requests[index];
            currRequest.gameObject.SetActive(true);
        }

        void Update(){
            if (Time.time > initialRingTime){
                if (ringTime > 0){
                    Debug.Log(ringTime);
                    if(!ringSound.isPlaying)
                        ringSound.Play(0);
                    //Debug.Log("test");
                    ringTime -= (Time.deltaTime);
                    ringing = true;
                }
                else{
                    ringTime = 3.0f;
                    ringing = false;
                    ringSound.Stop();
                    initialRingTime = Time.time + timeInBetweenRings;
                }
                
            }
            if (player.IsTouching(phone) && !gettingRequest && ringing){
                getRequest();
            }
            else{
                gettingRequest = false;
                //currRequest.gameObject.SetActive(false);
            }
        }
    }
}