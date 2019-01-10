using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueAnimator : MonoBehaviour {

    public List<StatuePiece> StatuePieces = new List<StatuePiece>();
    public StatuePieceInspector StatuePieceInspector;
    //if every registered piece gives its okay for the next animation, the statueanimator can start the next animation
    public int StatuePiecesReadyCounter;

    public void RegisterSelf(StatuePiece piece)
    {
        StatuePieces.Add(piece);
        //tell the statue pieces who the statuepieceinspector is. kinda ugly and unnecessary
        piece.SetStatuePieceInspector(StatuePieceInspector);
    }

    private void StartExplosionAnimation()
    {
        if (StatuePiecesReadyCounter == StatuePieces.Count)
        {
            StatuePiecesReadyCounter = 0;
            foreach (var sp in StatuePieces)
            {
                sp.StartExplosion();
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartExplosionAnimation();
        }
    }
}
