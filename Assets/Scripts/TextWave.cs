using TMPro;
using UnityEngine;

public class TextWave : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float strength = 10f;
    [SerializeField] float frequency = 0.01f;

    TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.ForceMeshUpdate();

        var textInfo = text.textInfo;
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible) continue;

            Vector3[] vertices = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
            for (int j = 0; j < 4; j++)
            {
                var orig = vertices[charInfo.vertexIndex + j];
                vertices[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * speed + orig.x * frequency) * strength, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            TMP_MeshInfo meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            text.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
