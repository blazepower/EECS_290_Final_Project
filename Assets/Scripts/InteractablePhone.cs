using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace DefaultNamespace{
    public class InteractablePhone : MonoBehaviour{
        public Collider2D player, phone;
        private Random rand = new Random();
        string[] reqsAsString = new[]{"One plant stat!", "Give me two plants! Right now", "I don't have time! Give me one plant!", "Give me one plant now or you'll never work in this town again!", "Two plants pronto! If I had time like this, I would've order yesterday instead.", "I want one plant immediately", "Hand me your best two plants!"};
        int[] reqsNum = new[]{1, 2, 1, 1, 2, 1, 2};
        private bool gettingRequest;
        public Text currRequest;
        private bool initalTimeOver, ringing;
        private float initialRingTime = 10.0f;
        private float timeInBetweenRings = 15.0f, ringTime = 5.0f, waitBeforeHide = 5.0f;
        public AudioSource ringSound;
        public Animator animator;

        void Start(){
            currRequest.gameObject.SetActive(false);
            ringSound = GetComponent<AudioSource>();
        }

        void getRequest(){
            gettingRequest = true;
            int index = rand.Next(reqsAsString.Length);
            currRequest.text = reqsAsString[index];
            currRequest.gameObject.SetActive(true);
            Global.plantsNeeded += reqsNum[index];
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
                    waitBeforeHide = 5.0f;
                }
            }
        }
    }
}