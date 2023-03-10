using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace W0NYV
{
    // [RequireComponent(typeof(Camera))]
    public class DrawHead : MonoBehaviour
    {

        [SerializeField] private Mesh _mesh;
        [SerializeField] private Material _material;

        public void SetAlpha(float v)
        {
            _material.SetFloat("_Alpha", v);
        }

        private void Update() {
            Graphics.DrawMesh(_mesh, Vector3.zero, Quaternion.identity, _material, 0);
        }

        // private void Awake() {
        //     var commandBuffer = new CommandBuffer();
        //     commandBuffer.name = "Head Command Buffer";

        //     commandBuffer.DrawMesh(_mesh, Matrix4x4.identity, _material, 0, 0);

        //     GetComponent<Camera>().AddCommandBuffer(CameraEvent.BeforeForwardAlpha, commandBuffer); 
        // }

        //OnPostRenderでいいんか？？？
        // private void OnPostRender() {
        //     _material.SetPass(0);
        //     Graphics.DrawMeshNow(_mesh, Vector3.zero, Quaternion.identity);
        // }

    }
}
