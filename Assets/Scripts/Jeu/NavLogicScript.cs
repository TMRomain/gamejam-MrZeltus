using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding.WindowsStore;
using Pathfinding;
public class NavLogicScript : MonoBehaviour
{
    AstarPath path;
    [SerializeField]
    GridGraph graph;

    [SerializeField]
    Transform joueur;
    private void Start() {
        path = transform.GetComponent<AstarPath>();
        graph = path.data.gridGraph;
        // Debug.Log(path.data.gridGraph);
        InvokeRepeating("reloadPathFinding", 1f, 1f);
    }

    void reloadPathFinding(){
        path.Scan();
    }
    private void FixedUpdate() {
        
        transform.position = Vector3.Lerp(transform.position ,new Vector3(joueur.position.x,joueur.position.y,transform.position.z), Time.deltaTime * 100);
        graph.center = new Vector3(joueur.position.x,joueur.position.y,transform.position.z);
    }
}
