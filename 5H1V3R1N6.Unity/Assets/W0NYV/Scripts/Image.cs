using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace W0NYV.Shivering
{
    public class Image : MonoBehaviour
    {

        [SerializeField] private float _speed = 1f;
        [SerializeField] Texture[] _textures;

        private float _t = 0f;

        private Material _material;
        private Vector4[] _colors = {
            new Vector4(1f, 1f, 1f, 1f), 
            new Vector4(1f, 1f, 1f, 1f), 
            new Vector4(1f, 1f, 1f, 1f), 
            new Vector4(1f, 1f, 1f, 1f), 
            new Vector4(0.3f, 0.2f, 0.9f, 1f), 
            new Vector4(0.7f, 0.8f, 0.2f, 1f)
        };
        private float threshold = 0;

        void Start()
        {

            if(TryGetComponent<MeshRenderer>(out var meshRenderer))
            {
                _material = meshRenderer.material;
            }

            threshold = Random.Range(0.001f, 0.02f);

            _material.SetTexture("_MainTex", _textures[Random.Range(0, _textures.Length)]);
            _material.SetFloat("_TileOffset", Random.Range(0.1f, 4f));
            _material.SetFloat("_Threshold", threshold);
            _material.SetVector("_MainColor", _colors[Random.Range(0, _colors.Length)]);

        }

        // Update is called once per frame
        void Update()
        {
            _t += Time.deltaTime * _speed;

            threshold += Time.deltaTime * _speed * 1.3f;
            _material.SetFloat("_Threshold", threshold);

            if(1f < _t) Destroy(this.gameObject);
        }
    }
}
