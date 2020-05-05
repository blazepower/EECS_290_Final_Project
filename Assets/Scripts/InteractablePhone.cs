using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace DefaultNamespace{
    public class InteractablePhone : MonoBehaviour{
        public Collider2D player, phone;
        private Random rand = new Random();
        string[] reqsAsString = new[]{"One plant stat!", "Give me two plants! Right now", "Give me one plant now!", "Two plants pronto!", "I want one plant immediately", "Hand me your best two plants!"};
        int[] reqsNum = new[]{1, 2, 1, 2, 1, 2};
        private bool gettingRequest;
        public Text currRequest;
        private bool currRequestActive;
        private bool initalTimeOver, ringing;
        private float initialRingTime = 10.0f;
        private float timeInBetweenRings = 14.0f, ringTime = 7.0f, waitBeforeHide = 4.0f;
        public AudioSource ringSound;
        public Animator animator;

        void Start(){
            currRequest.gameObject.SetActive(false);
            currRequestActive = false;
            ringSound = GetComponent<AudioSource>();
        }

        void getRequest(){
            ringTime = 0;
            gettingRequest = true;
            int index = rand.Next(reqsAsString.Length);
            currRequest.text = reqsAsString[index];
            currRequest.gameObject.SetActive(true);
            currRequestActive = true;
            Global.plantsNeeded += reqsNum[index];
            Global.orders.Enqueue(reqsNum[index]);
        }

        void Update(){
            if (currRequestActive == true)
                ringSound.Stop();
            if (Time.timeSinceLevelLoad > initialRingTime){
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
                    initialRingTime = Time.timeSinceLevelLoad + timeInBetweenRings;
                    gettingRequest = false;
                }

                animator.SetBool("ring", ringing);
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
                    currRequestActive = false;
                    waitBeforeHide = 5.0f;
                }
            }
        }
    }
}