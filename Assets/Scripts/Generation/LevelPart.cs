using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LevelPart : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(Tags.Player) || !gameObject.scene.isLoaded) return;
        LevelGenerator.Instance.NextChunk();
    }
}