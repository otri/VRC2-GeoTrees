using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class WaveGen : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    public float _Input;

    [SerializeField]
    [Range(0, 10)]
    public float _WaveSpeed;

    Texture2D _texture;

    void Awake() {
        _texture = new Texture2D(256, 1, TextureFormat.RFloat, false, true);
        var textureBuffer = _texture.GetRawTextureData<float>();
        var textureWidth = _texture.width;
        for (int i = 0; i < textureWidth; i++) {
            textureBuffer[i] = _Input;
        }
        _texture.Apply();

        GetComponent<MeshRenderer>().material.mainTexture = _texture;
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateTexture();
    }

    void GenerateTexture() {
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate shift based on rate of change
        var textureWidth = _texture.width;
        int shift = (int)(Time.deltaTime * _WaveSpeed * textureWidth);
        if( shift > textureWidth ) {
            shift = textureWidth;
        }
    
        // Shift the texture by shift.
        var textureBuffer = _texture.GetRawTextureData<float>();
        if( textureWidth > shift ) {
            NativeArray<float>.Copy(textureBuffer, 0, textureBuffer, shift, textureWidth - shift);
        }

        for (int i = 0; i < shift; i++) {
            textureBuffer[i] = _Input;
        }

        _texture.Apply();
    }
}
