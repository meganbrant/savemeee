using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class spawnerToys : MonoBehaviour
{

[SerializeField, Range(1,50)]
int totalObjects = 10;
[SerializeField]
int upForce = 10;
[SerializeField]
Vector2 WaitIntervalRange = new Vector2(2,3);
[SerializeField]
List<GameObject> prefabs;

    List<Rigidbody> toys = new List<Rigidbody>();
    bool canSpawn = true;


    // Start is called before the first frame update
    void Start()
    {
        SpawnToy();

        StartCoroutine(Hop());

    }


    void Update(){
        var keyboard = Keyboard.current;
        if(keyboard == null) return;

        if(keyboard.rKey.wasPressedThisFrame) SpawnToy();
      
    }
    void SpawnToy(){
        if(!canSpawn){
            return;
        }
    
        for(int i =0; i<totalObjects;i++){
           // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
           GameObject cube = Instantiate(prefabs[Random.Range(0,prefabs.Count)]);
            cube.tag = "Toy";
            cube.name = "Toy";
            cube.transform.position= new Vector3(0,9 +(i*2f),0);
            Rigidbody rb = cube.AddComponent<Rigidbody>();
            toys.Add(rb);
        }
        StartCoroutine(WaitToSpawn());

    }

    IEnumerator WaitToSpawn(){
        canSpawn = false;
        yield return new WaitForSeconds(2);
        canSpawn = true;
    }
    IEnumerator Hop() {
        Debug.Log("Hopping!");
        while(true) {
            yield return new WaitForSeconds(Random.Range(WaitIntervalRange.x, WaitIntervalRange.y));
            foreach(Rigidbody rb in toys) {
                if(rb != null){
                    rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);

                }
            }
        }
    }


}
