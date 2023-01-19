using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV.Shivering.CameraWork
{
    public class CameraWork : MonoBehaviour
    {
        [SerializeField] private GameObject _aimObj;
        [SerializeField] private float _speed = 1f;

        float t = 0;
    
        Vector3 current;
        Vector3 rnd;

        public void Front(float v)
        {
            if(v == 1.0f)
            {
                if(t>1f)
                {
                    t = 0;
                    current = transform.position;
                    rnd = new Vector3(0, 0, -3f);
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
                    rnd = Random.onUnitSphere * 3f;
                }   
            }
        }

        private void Start()
        {
            current = transform.position;
            rnd = Random.onUnitSphere * 3f;
        }

        private void Update()
        {
            
            if(t<1f)t += Time.deltaTime * _speed;  

            transform.position = Vector3.Slerp(current, rnd, 3*t*t - 2*t*t*t);

            var aim = _aimObj.transform.position - transform.position;
            var look = Quaternion.LookRotation(aim, Vector3.up);
            transform.localRotation = look;
        }
    }
}
