using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random=System.Random;

public class CafeAI : MonoBehaviour
{
    public Transform[] line;
    public Transform[] tableWaypoints;
    public Transform[] lineWaypoints;

    public float waitTime;
    private float speed = 4;
    
    private List<int> seatsLeft;

    private void Start()
    {
        seatsLeft = new List<int>();
        seatsLeft.AddRange(Enumerable.Range(0,tableWaypoints.Length));
        StartCoroutine(CafeLine());
    }

    IEnumerator CafeLine()
    {
        int index = 0;
        while (index < line.Length)
        {
            yield return new WaitForSeconds(waitTime);

            Transform toLeaveLine = line[index];
            float step = Time.deltaTime * speed;
        
            while (toLeaveLine.position != lineWaypoints[0].position) //get the first in line and move them out
            {
                toLeaveLine.position = Vector3.MoveTowards(toLeaveLine.position, lineWaypoints[0].position, step);
                yield return null;
            }
            
            //choose table spot to seat at
            int seat = seatsLeft.Count + 1;
            while (!seatsLeft.Contains(seat))
            {
                seat = new Random().Next(seatsLeft.Count);
            }
            
            Transform spot = tableWaypoints[seat];

            while (toLeaveLine.position != spot.position) 
            {
                toLeaveLine.position = Vector3.MoveTowards(toLeaveLine.position, spot.position, step);
                yield return null;
            }

            seatsLeft.Remove(seat);
            
            index++;
            int waypointIndex = 1;
            for (int i = index; i < line.Length; i++) //move the rest of the line one step up
            {
                Transform nextInLine = line[i];
                while (nextInLine.position != lineWaypoints[waypointIndex].position)
                {
                    nextInLine.position = Vector3.MoveTowards(nextInLine.position, lineWaypoints[waypointIndex].position, step);
                    yield return null;
                }

                waypointIndex++;
            }
            
        }
        
    }
    
    
}
