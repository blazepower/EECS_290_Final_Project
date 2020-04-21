using System;
using UnityEngine;
using Random = System.Random;

namespace DefaultNamespace{
    public class BuyPlant : MonoBehaviour{
        private static float z = 24.44197f;
        Random rand = new Random();
        private Vector3[] acceptablePositions = new Vector3[]{new Vector3(15, -8, z), new Vector3(15,-4,z) };
        public GameObject plant;
        //private int money = Global.money;

        private void Update(){
            if (Input.GetKey(KeyCode.B)){
                if (Global.money > 10){
                    Global.money -= 10;
                    Vector:
                    int index = rand.Next(acceptablePositions.Length);
                    Vector3 temp = acceptablePositions[index];
                    if (!Physics.CheckSphere(temp, 1)){
                        Instantiate(plant, temp, Quaternion.identity);
                    }
                    else{
                        goto Vector;
                    }
                }
            }
        }
    }
}