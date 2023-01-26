using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace W0NYV
{
    [RequireComponent(typeof(Camera))]
    public class DrawHead : MonoBehaviour
    {

        [SerializeField] private Mesh _mesh;
        [SerializeField] private Material _material;

        //OnPostRenderでいいんか？？？
        private void OnPostRender() {
            _material.SetPass(0);
            Graphics.DrawMeshNow(_mesh, Vector3.zero, Quaternion.identity);
        }

    }
}
