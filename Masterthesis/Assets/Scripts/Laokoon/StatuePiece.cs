using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePiece : MonoBehaviour
{
    //Statue Pieces register themselves on SceneLoad at the StatueAnimator, which acts as a central animation invoker.
    public Vector3 LocalExplosionPosition;
    private Vector3 _localStartingPosition;
    private StatuePieceInspector _spi;
    public float PuzzleTolerance;

    private float _explosionSpeed = 4;

    private bool _animationRunning, _exploded;

	void Start () {
        //Statue pieces register themselves in the statue animator
	    var statueAnimator = transform.parent.GetComponent<StatueAnimator>();
        statueAnimator.RegisterSelf(this);
        //Piece sets itself ready for animation, if every registered piece gives its okay for the next animation, the statueanimator can start the next animation
	    statueAnimator.StatuePiecesReadyCounter++;
        //Remember local starting position
        _localStartingPosition = transform.localPosition;
	}

    void Update()
    {
        RunAnimation();
    }

    private void RunAnimation()
    {
        //statue is not already exploded
        if (_animationRunning && !_exploded)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, LocalExplosionPosition, Time.deltaTime * _explosionSpeed);
            if (Vector3.Distance(transform.localPosition, LocalExplosionPosition) < 0.01f)
            {
                _exploded = true;
                _animationRunning = false;
            }
        }
    }

    public void SetRandomExplosionPosition(Vector3 pos)
    {
        LocalExplosionPosition = pos;
    }

    public void SetStatuePieceInspector(StatuePieceInspector SPI)
    {
        _spi = SPI;
    }
	
    void OnMouseOver()
    {
        //OnClick
        if (Input.GetMouseButtonDown(0) && transform.parent.GetComponent<StatueAnimator>().AnimationReady)
        {
            _spi.ClonePiece(gameObject);
        }
    }

    private void OnMouseDrag()
    {
        if (_exploded)
        {

            RaycastHit[] hits;
            hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 100.0F);

            foreach(var hit in hits)
            {
                if(hit.transform.tag == "PuzzleCollider")
                {
                    transform.position = hit.point;
                }
            }

            Debug.Log(Vector3.Distance(transform.localPosition, _localStartingPosition));
            if (Vector3.Distance(transform.localPosition, _localStartingPosition) < PuzzleTolerance)
            {
                transform.localPosition = _localStartingPosition;
                _exploded = false;
                transform.parent.GetComponent<StatueAnimator>().PieceReady();
            }
        }
    }

    public void StartExplosion()
    {
        _animationRunning = true;
    }


}
