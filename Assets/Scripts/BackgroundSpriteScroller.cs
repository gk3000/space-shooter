using UnityEngine;

public class BackgroundSpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed; // scrolling speed of the sprite

    Vector2 offset; // store the current texture offset
    Material material; // A reference to the material of the sprite

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material; // gets the Material component of the SpriteRenderer attached to the GameObject and assigns it to the material field. 
    }                                                       // This material contains the texture that will be scrolled

    void Update()
    {
        offset = moveSpeed * Time.deltaTime; // Calculates the texture offset based on the moveSpeed and the time elapsed since the last frame (Time.deltaTime). This ensures smooth scrolling that is frame-rate independent
        material.mainTextureOffset += offset; // Updates the texture offset of the material, effectively scrolling the texture. The += operator ensures that the offset accumulates over time, creating continuous scrolling
    }
}