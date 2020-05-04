using System;
using UnityEngine;
using System.Collections;

namespace DefaultNamespace{
    public class MusicScript : MonoBehaviour{
        private void Awake(){
            GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");
            if (musicObjects.Length > 1){
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}