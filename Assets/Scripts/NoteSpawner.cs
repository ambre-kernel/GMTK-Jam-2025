using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] GameObject note;

    public void Spawn()
    {
        Instantiate(note, transform);
    }
}
