using TMPro;
using UnityEngine;

public class TextShake : MonoBehaviour
{
    [SerializeField] float strength = 1f;
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
            Vector3 noise = Random.insideUnitSphere * strength;
            for (int j = 0; j < 4; j++)
            {
                Vector3 orig = vertices[charInfo.vertexIndex + j];
                vertices[charInfo.vertexIndex + j] = orig + noise;
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
