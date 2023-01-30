using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace W0NYV
{
    public class StarField : MonoBehaviour
    {

        [SerializeField] Mesh _mesh;
        [SerializeField] Material _material;
        [SerializeField, Range(0, 1023)] int _numInstances = 128;

        private Matrix4x4[] _instData;

        private void Start() {
            _instData = new Matrix4x4[_numInstances];
            for(int i=0; i<_numInstances; i++)
            {
                _instData[i] = Matrix4x4.identity;

                float rndScl = Random.Range(0.0025f, 0.01f);
                _instData[i].SetTRS(Random.insideUnitSphere * 5.0f, 
                                    Quaternion.Euler(new Vector3(Random.Range(1f, 360f), Random.Range(1f, 360f), Random.Range(1f, 360f))), 
                                    new Vector3(rndScl, rndScl, rndScl));
            }
        }

        void Update()
        {            
            RenderParams rp = new RenderParams(_material);
            Graphics.RenderMeshInstanced(rp, _mesh, 0, _instData);
        }
    }
}
