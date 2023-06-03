using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts
{
    public class PitStructureInfo : MonoBehaviour {
        public GameObject[] text;
        private Mesh mesh;
        private int index;
        private int matIndex;

        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                mesh = hit.collider.gameObject.GetComponent<MeshFilter>().mesh;
                Debug.Log("GameObject: " + hit.collider.gameObject);
                index = hit.triangleIndex;
                if(mesh.subMeshCount == 3)
                {
                    matIndex = GetMaterialIndex(mesh, index);
                    if (matIndex == 0)
                    {
                        text[3].SetActive(false);
                        text[1].SetActive(false);
                        text[2].SetActive(false);
                        text[0].SetActive(true);
                    } else if(matIndex == 1)
                    {
                        text[3].SetActive(false);
                        text[0].SetActive(false);
                        text[2].SetActive(false);
                        text[1].SetActive(true);
                    } else if(matIndex == 2)
                    {
                        text[3].SetActive(false);
                        text[0].SetActive(false);
                        text[1].SetActive(false);
                        text[2].SetActive(true);
                    }
                } else
                {
                    text[0].SetActive(false);
                    text[1].SetActive(false);
                    text[2].SetActive(false);
                    text[3].SetActive(true);
                }
            
            }
        }

        private int GetMaterialIndex(Mesh m, int index) 
        {
            int totalSubMeshes = m.subMeshCount;
            int[] subMeshesFaceTotals = new int[totalSubMeshes];
            int hitSubMeshNumber = 0;
            int maxVal = 0;

            for (int i = 0; i<totalSubMeshes; i++) 
            {
                subMeshesFaceTotals[i] = m.GetTriangles(i).Length / 3;
                maxVal += subMeshesFaceTotals[i];
                if (index < maxVal) 
                {      
                    hitSubMeshNumber = i;
                    break;
                }
            }
            Debug.Log("We hit sub mesh number: " + hitSubMeshNumber);
            return hitSubMeshNumber;
        }
    }
}

