using System.Collections;
using UnityEngine;

public class Partition : MonoBehaviour
{
    [SerializeField] NoteSpawner[] spawners;
    private float interNote = 0;
    private GameObject closestNote;

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
            if (note == "A") spawners[0].Spawn();
            else if (note == "B") spawners[1].Spawn();
            else if(note == "X") spawners[2].Spawn();
            else if(note == "Y") spawners[3].Spawn();

            yield return new WaitForSeconds(interNote);
        }
    }
}