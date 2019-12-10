using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame
{  
    [RequireComponent(typeof(Collider))]
    public class Objective : MonoBehaviour
    {
        
        [SerializeField]
        private string _playerTag = "Player";

       
        private bool _isComplete;
        public bool IsComplete { get { return _isComplete; } }

       
        public void CompleteObjective()
        {
            _isComplete = true;
        }

       
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == _playerTag)
            {
                CompleteObjective();
            }
        }

    }
}
