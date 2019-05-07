using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueAnimator : MonoBehaviour {

    public List<StatuePiece> StatuePieces = new List<StatuePiece>();
    public StatuePieceInspector StatuePieceInspector;
    //if every registered piece gives its okay for the next animation, the statueanimator can start the next animation
    public int StatuePiecesReadyCounter;
    public bool AnimationReady = true;
    public List<Vector3> ExplosionPointList = new List<Vector3>();

    public void RegisterSelf(StatuePiece piece)
    {
        StatuePieces.Add(piece);
        //tell the statue pieces who the statuepieceinspector is. kinda ugly and unnecessary
        piece.SetStatuePieceInspector(StatuePieceInspector);
    }

    public void StartExplosionAnimation()
    {
        if (AnimationReady)
        {
            StatuePiecesReadyCounter = 0;
            AnimationReady = false;

            int rnd = Random.Range(0, 100);

            for(int i = 0; i < StatuePieces.Count; i++)
            {
                StatuePieces[i].SetRandomExplosionPosition(ExplosionPointList[(rnd + i) % StatuePieces.Count]);
                StatuePieces[i].StartExplosion();
            }
        }
    }

    public void PieceReady()
    {
        StatuePiecesReadyCounter++;
        if(StatuePiecesReadyCounter == StatuePieces.Count)
        {
            AnimationReady = true;
        }
    }
}
