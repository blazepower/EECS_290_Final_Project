using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace DefaultNamespace{
    public class BuyPlant : MonoBehaviour{
        private static float z = 24.44197f;
        Random rand = new Random();
        private List<Vector3> acceptablePositions = new List<Vector3>(); //{new Vector3(15, -8, z), new Vector3(15,-4,z), new Vector3(-3, -9, z) };
        public GameObject plant;
        public AudioSource outOfSpots;
      

        private void Start(){
            acceptablePositions.Add(new Vector3(15, -8, z));
            acceptablePositions.Add(new Vector3(15,-4, z));
            acceptablePositions.Add(new Vector3(-3, -9, z));
        }

        private void Update(){
            try{
                if (Input.GetKeyUp(KeyCode.B)){
                    if (Global.money > 10){
                        Global.money -= 10;
                        int index = rand.Next(acceptablePositions.Count);
                        Vector3 temp = acceptablePositions[index];
                        if (!Physics.CheckSphere(temp, 1)){
                            acceptablePositions.Remove(temp);
                            Instantiate(plant, temp, Quaternion.identity);
                            Global.plantsRemaining++;
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException e){
                if (!outOfSpots.isPlaying){
                    outOfSpots.Play(0);
                }
            }
        }
    }
}