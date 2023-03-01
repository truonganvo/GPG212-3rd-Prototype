using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] MazeNode nodePrefab;
    [SerializeField] Vector2Int mazeSize;

    private void Start()
    {
        StartCoroutine(GenerateMaze(mazeSize));
    }

    IEnumerator GenerateMaze(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();

        //Create nodes
        for(int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                Vector3 nodePosition = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePosition, Quaternion.identity, transform);
                nodes.Add(newNode);

                yield return null;
            }
        }

        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completeNodes= new List<MazeNode>();

        //Choosing starting nodes
        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        currentPath[0].SetState(NodeState.Current);

        while (completeNodes.Count < nodes.Count)
        {
            //Check nodes next to the current nodes 
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirections = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.x;

            if (currentNodeX < size.x - 1)
            {
                //check node to the right of the current node
                if (!completeNodes.Contains(nodes[currentNodeIndex + size.y]) && !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                {
                    possibleDirections.Add(1);
                    possibleNextNodes.Add(currentNodeIndex + size.y);
                }
            }


            if (currentNodeX > 0)
            {
                //check node to the left of the current node
                if (!completeNodes.Contains(nodes[currentNodeIndex - size.y]) && !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                {
                    possibleDirections.Add(2);
                    possibleNextNodes.Add(currentNodeIndex - size.y);
                }
            }

            if (currentNodeY < size.y - 1)
            {
                //Check node above the current one
                if (!completeNodes.Contains(nodes[currentNodeIndex +1]) && !currentPath.Contains(nodes[currentNodeIndex +1]))
                {
                    possibleDirections.Add(3);
                    possibleNextNodes.Add(currentNodeIndex + 1);
                }
            }

            if (currentNodeY > 0)
            {
                //Check node below the current one
                if (!completeNodes.Contains(nodes[currentNodeIndex -1]) && !currentPath.Contains(nodes[currentNodeIndex - 1]))
                {
                    possibleDirections.Add(4);
                    possibleNextNodes.Add(currentNodeIndex - 1);
                }
            }

            //Choose next node
            if(possibleDirections.Count > 0)
            {
                int chosenDirection = Random.Range(0, possibleDirections.Count);
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                switch (possibleDirections[chosenDirection])
                {
                    case 1:
                        chosenNode.RemoveWall(1);
                        currentPath[currentPath.Count - 1].RemoveWall(0);
                        break;

                    case 2:
                        chosenNode.RemoveWall(0);
                        currentPath[currentPath.Count - 1].RemoveWall(1);
                        break;

                    case 3:
                        chosenNode.RemoveWall(3);
                        currentPath[currentPath.Count - 1].RemoveWall(2);
                        break;

                    case 4:
                        chosenNode.RemoveWall(2);
                        currentPath[currentPath.Count - 1].RemoveWall(3);
                        break;
                }

                currentPath.Add(chosenNode);
                chosenNode.SetState(NodeState.Current);
            }
            else
            {
                completeNodes.Add(currentPath[currentPath.Count - 1]);

                currentPath[currentPath.Count - 1].SetState(NodeState.Complete);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            yield return new WaitForSeconds(0.05f);
        }
    }
}
