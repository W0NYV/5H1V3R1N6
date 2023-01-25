using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Camera))]
public class CommandBufferTest : MonoBehaviour {

    [SerializeField]
    private Shader _shader;

    private void Awake () {
        Initialize();
    }

    private void Initialize()
    {
        var camera = GetComponent<Camera>();
        if (camera.allowMSAA) {
            // MSAAがONになっていると正常に動作しない
            Debug.Log("obakasan");
            return;
        }
        var material = new Material(_shader);
        var commandBuffer = new CommandBuffer();
        
        // 一時テクスチャを取得する
        // テクスチャのIDを取得するにはShader.PropertyToIDを使う
        int tempTextureIdentifier = Shader.PropertyToID("_PostEffectTempTexture");
        Debug.Log(tempTextureIdentifier);
        commandBuffer.GetTemporaryRT(tempTextureIdentifier, -1, -1);

        // 現在のレンダーターゲットを一時テクスチャにコピー
        // 一時テクスチャからレンダーターゲットにポストエフェクトを掛けつつ描画
        commandBuffer.Blit(BuiltinRenderTextureType.CurrentActive, tempTextureIdentifier);
        commandBuffer.Blit(tempTextureIdentifier, BuiltinRenderTextureType.CurrentActive, material);

        // 一時テクスチャを解放
        commandBuffer.ReleaseTemporaryRT(tempTextureIdentifier);

        camera.AddCommandBuffer(CameraEvent.AfterImageEffectsOpaque, commandBuffer);
    }
}