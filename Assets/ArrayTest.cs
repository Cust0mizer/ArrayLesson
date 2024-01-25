using System.Collections;
using UnityEngine;

public class ArrayTest : MonoBehaviour {
    [SerializeField] private ArrayCreator _arrayCreator;
    [SerializeField] private Material _firstMaterial;
    [SerializeField] private Material _secondMaterial;
    private float _blinkTime = 0.1f;

    private int _zSize = 3;
    private int _ySize = 3;
    private int _xSize = 10;

    private IEnumerator Start() {
        GameObject[] elements = _arrayCreator.StartCreate(_xSize);
        //GameObject[,] elements = _arrayCreator.StartCreate(5, 3);
        //GameObject[,,] elements = _arrayCreator.StartCreate(5, 3, 5);
        yield return new WaitForSecondsRealtime(_arrayCreator.CreateTime * _xSize + 1);
        DisableAll(elements);
        StartCoroutine(Blink(elements));
    }

    private void DisableAll(GameObject[] elements) {
        for (int i = 0; i < elements.Length; i++) {
            elements[i].GetComponent<MeshRenderer>().material = _secondMaterial;
        }
    }

    private IEnumerator Blink(GameObject[] elements) {
        int elementCount = 0;
        while (true) {
            for (int i = 0; i < elements.Length; i++) {
                if (i == elementCount) {
                    elements[i].GetComponent<MeshRenderer>().material = _firstMaterial;
                }
                else {
                    elements[i].GetComponent<MeshRenderer>().material = _secondMaterial;
                }
            }
            yield return new WaitForSecondsRealtime(_blinkTime);
            elementCount = (elementCount + 1) % elements.Length;
        }
    }
}
