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

        public GameObject pink;
        public GameObject purple;
        public GameObject white;
        public GameObject yellow;

        private int randomInt;

        private void Start(){
            acceptablePositions.Add(new Vector3(15,-4, z));
            acceptablePositions.Add(new Vector3(-3, -9, z));
            acceptablePositions.Add(new Vector3(0, -9, z));
            acceptablePositions.Add(new Vector3(3, -9,z));
            acceptablePositions.Add(new Vector3(6, -9, z));
            acceptablePositions.Add(new Vector3(9, -9, z));
            acceptablePositions.Add(new Vector3(12, -9, z));
            acceptablePositions.Add(new Vector3(-15, -8, z));
            acceptablePositions.Add(new Vector3(-15, -4, z));
            acceptablePositions.Add(new Vector3(-6, -9, z));
            acceptablePositions.Add(new Vector3(-9, -9, z));
            acceptablePositions.Add(new Vector3(-12, -9, z));
        }

        private void Update(){
            try{
                if (Input.GetKeyUp(KeyCode.B)){
                    if (Global.money > 20){
                        int index = rand.Next(acceptablePositions.Count);
                        Vector3 temp = acceptablePositions[index];
                        if (!Physics.CheckSphere(temp, 1)){
                            acceptablePositions.Remove(temp);

                            randomInt = UnityEngine.Random.Range(0, 5);
                            switch(randomInt)
                            {
                                default:
                                    Instantiate(plant, temp, Quaternion.identity);
                                    Debug.Log("Red");
                                    break;
                                case 0:
                                    Instantiate(plant, temp, Quaternion.identity);
                                    Debug.Log("Red");
                                    break;
                                case 1:
                                    Instantiate(pink, temp, Quaternion.identity);
                                    Debug.Log("Pink");
                                    break;
                                case 2:
                                    Instantiate(purple, temp, Quaternion.identity);
                                    Debug.Log("Purple");
                                    break;
                                case 3:
                                    Instantiate(white, temp, Quaternion.identity);
                                    Debug.Log("White");
                                    break;
                                case 4:
                                    Instantiate(yellow, temp, Quaternion.identity);
                                    Debug.Log("Yellow");
                                    break;
                            }

                            //Global.plantsReady++;
                            Global.money -= 20;
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