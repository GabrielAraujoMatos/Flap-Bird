using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;

    public Vector3 originPoint = new Vector3(0, 0, 0);

    public float interval = 3;

    private float colldown = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameActive)
        {
            return;
        }

        colldown -= Time.deltaTime;
        if (colldown <= 0f)
        {
            colldown = interval;
            SpwanBall();
        }
    }

    private void SpwanBall()
    {
        //Prefab
        int prefabIndex = Random.Range(0, prefabs.Count);
        GameObject prefab = prefabs[prefabIndex];


        float gameWidth = GameManager.Instance.gameWidth;
        float xOffset = Random.Range(-gameWidth / 2f, gameWidth / 2f);
        Vector3 position = originPoint + new Vector3(xOffset, 0, 0);

        Quaternion rotation = prefab.transform.rotation;

        Instantiate(prefab, position, rotation);
    }
}
