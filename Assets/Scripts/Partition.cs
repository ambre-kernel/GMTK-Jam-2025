using System.Collections;
using UnityEngine;

public class Partition : MonoBehaviour
{
    [SerializeField] NoteSpawner[] spawners;
    private float interNote = 0;

    public float bpm = 120f;
    public string[] notes;

    void Start()
    {
        interNote = 1 / (bpm / 60f);
        StartCoroutine(PlayNotes());
    }

    void Update()
    {
    }

    IEnumerator PlayNotes()
    {
        foreach (var note in notes)
        {
            var n = note.ToUpper();
            if (n == "A" || n == "DOWN") spawners[0].Spawn();
            else if (n == "B" || n == "LEFT") spawners[1].Spawn();
            else if (n == "X" || n == "RIGHT") spawners[2].Spawn();
            else if (n == "Y" || n == "UP") spawners[3].Spawn();
            else if (n == "S" || n == "SPACE") spawners[4].Spawn();

            yield return new WaitForSeconds(interNote);
        }
    }
}