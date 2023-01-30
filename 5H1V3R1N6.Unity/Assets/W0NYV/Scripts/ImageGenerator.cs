using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV.Shivering
{   
    public class ImageGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _imageParent;
        [SerializeField] private GameObject _image;

        public void Generate(float v)
        {
            if(v == 1)
            {
                GameObject o = Instantiate(_image, Vector3.zero, Quaternion.identity);
                o.transform.SetParent(_imageParent.transform);
                o.transform.localPosition = new Vector3(0f, 0f, 0.301f);
                o.transform.localRotation = Quaternion.Euler(Vector3.zero);
                Debug.Log("生成");
            }
        }
    }
}