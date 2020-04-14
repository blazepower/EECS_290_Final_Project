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

        private void Start(){
            string[] reqsAsString = new[]{"One plant stat!", "Give me two plants! Right now"};

            foreach (string s in reqsAsString){
                requestToBeAdded.text = s;
                requests[numRequests] = requestToBeAdded;
                numRequests++;
            }
        }

        void addRequests(){
            requests[numRequests] = requestToBeAdded;
            numRequests++;
        }
        
        void getRequest(){
            gettingRequest = true;
            int index = rand.Next(requests.Length);
            currRequest = requests[index];
            currRequest.gameObject.SetActive(true);
        }

        void Update(){
            if (requestToBeAdded != null){
                addRequests();
                requestToBeAdded = null;
            }
            if (player.IsTouching(phone) && !gettingRequest){
                getRequest();
            }
            else{
                gettingRequest = false;
                currRequest.gameObject.SetActive(false);
            }
        }
    }
}