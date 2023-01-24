using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV.Shivering.CameraWork
{
    public class CameraWork : MonoBehaviour
    {
        [SerializeField] private GameObject _aimObj;
        [SerializeField] private float _interpolateSpeed = 1f;
        [SerializeField] private float _aimDistance = 3f;

        float t = 0;
    
        Vector3 current;
        Vector3 rnd;

        //sloth
        [SerializeField] float _slothSpeed = 0.1f;
        bool canMove = false;
        Vector3 rndDir;

        public void ChangeSlothSpeed(float v)
        {
            _slothSpeed = v * 0.9f + 0.1f;
        }

        public void ChangeSpeed(float v)
        {
            _interpolateSpeed = v * 4f + 1f;
        }

        public void ChangeAimDistance(float v)
        {
            float value = v*7f + 3f;
            _aimDistance = value;
        }

        public void Front(float v)
        {
            if(v == 1.0f)
            {
                if(t>1f)
                {
                    t = 0;
                    current = transform.position;
                    rnd = new Vector3(0, 0, -_aimDistance);
                    canMove = false;
                }
            }
        }

        public void Translate(float v)
        {
            if(v == 1.0f)
            {
                if(t>1f)
                {
                    t = 0;
                    current = transform.position;
                    rnd = Random.onUnitSphere * _aimDistance;
                    canMove = true;
                }   
            }
        }

        private void Start()
        {
            current = transform.position;
            rnd = Random.onUnitSphere * _aimDistance;
            rndDir = Vector3.Normalize(new Vector3(3f, 3f, 3f));
        }

        private void Update()
        {
            
            if(t<1f)
            {
                t += Time.deltaTime * _interpolateSpeed;
                transform.position = Vector3.Slerp(current, rnd, 3*t*t - 2*t*t*t);
            }

            //sloth
            if(canMove)transform.position += rndDir * Time.deltaTime * _slothSpeed;

            var aim = _aimObj.transform.position - transform.position;
            var look = Quaternion.LookRotation(aim, Vector3.up);
            transform.localRotation = look;
        }
    }
}
