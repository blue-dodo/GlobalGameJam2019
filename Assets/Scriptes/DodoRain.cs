using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodoRain : MonoBehaviour
{
    [SerializeField] private List<GameObject> dodos;
    [SerializeField] private float time;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if ((Time.time - startTime) >= time)
        {
            int random = Random.Range(0, dodos.Count);
            startTime = Time.time;
            dodos[random].transform.localPosition = GetRandomPosition();
            dodos[random].transform.localEulerAngles = GetRandomRotation();

            StartCoroutine(CreateObject(dodos[random], time));

        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 pos = new Vector2(0f, 0f);

        pos.x = Random.Range(-9, 9);
        pos.y = Random.Range(12, 15);
        return pos;
    }

    private Vector3 GetRandomRotation()
    {
        Vector3 rotation = new Vector3(0f, 0f, 0f);
        
        rotation.z = Random.Range(0, 360);
        return rotation;
    }

    IEnumerator CreateObject(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        GameObject aux = Instantiate(gameObject);

        yield return new WaitForSeconds(2f);
        Destroy(aux, 3f);
    }
}
