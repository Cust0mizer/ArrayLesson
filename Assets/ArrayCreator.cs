using System.Collections;
using UnityEngine;

public class ArrayCreator : MonoBehaviour {
    [SerializeField] private GameObject _prefabObject;
    public float CreateTime { get; private set; } = 0.5f;

    public GameObject[,,] StartCreate(int xSize, int ySize, int zSize) {
        GameObject[,,] _objectsThreeSize = new GameObject[xSize, ySize, zSize];
        StartCoroutine(Create(xSize, ySize, zSize, _objectsThreeSize));
        return _objectsThreeSize;
    }

    public GameObject[,] StartCreate(int xSize, int zSize) {
        GameObject[,] _objectsTwoSize = new GameObject[xSize, zSize];
        StartCoroutine(Create(xSize, zSize, _objectsTwoSize));
        return _objectsTwoSize;
    }

    public GameObject[] StartCreate(int xSize) {
        GameObject[] _objectsThreeSize = new GameObject[xSize];
        StartCoroutine(Create(xSize, _objectsThreeSize));
        return _objectsThreeSize;
    }

    private IEnumerator Create(int xSize, int ySize, int zSize, GameObject[,,] _objectsThreeSize) {
        for (int y = 0; y < ySize; y++) {
            for (int z = 0; z < zSize; z++) {
                for (int x = 0; x < xSize; x++) {
                    yield return new WaitForSecondsRealtime(CreateTime);
                    GameObject element = Instantiate(_prefabObject, new Vector3(x, y, z), transform.rotation);
                    _objectsThreeSize[x, y, z] = element;
                }
            }
        }
    }

    private IEnumerator Create(int xSize, int zSize, GameObject[,] _objectsTwoSize) {
        for (int z = 0; z < zSize; z++) {
            for (int x = 0; x < xSize; x++) {
                yield return new WaitForSecondsRealtime(CreateTime);
                GameObject element = Instantiate(_prefabObject, new Vector3(x, 0, z), transform.rotation);
                _objectsTwoSize[x, z] = element;
            }
        }
    }

    private IEnumerator Create(int xSize, GameObject[] _objectsOneSize) {
        for (int x = 0; x < xSize; x++) {
            yield return new WaitForSecondsRealtime(CreateTime);
            GameObject element = Instantiate(_prefabObject, new Vector3(x, 0, 0), transform.rotation);
            _objectsOneSize[x] = element;
        }
    }
}