using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace DefaultNamespace{
    public class InteractablePhone : MonoBehaviour{
        public Collider2D player, phone;
        private Random rand = new Random();
        private Text[] requests = new Text[50];
        private bool gettingRequest;
        private Text currRequest, requestToBeAdded;
        private static int numRequests = 0;

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