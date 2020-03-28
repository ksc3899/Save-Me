using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed;

    private MeshRenderer meshRenderer;
    private string textureOffset = "_MainTex";

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(textureOffset);
        offset.y += scrollSpeed * Time.deltaTime;

        meshRenderer.sharedMaterial.SetTextureOffset(textureOffset, offset);
    }
}
