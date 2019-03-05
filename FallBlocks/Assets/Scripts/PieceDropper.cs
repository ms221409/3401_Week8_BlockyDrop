using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDropper : MonoBehaviour
{
    public GameObject piecePrefab;
    public CameraBehavior cameraBehavior;
    public float pieceFloatHeight = 2;

    float _spawnYpos = 1;
    Transform _currentPiece;
    Transform _previousPiece;
    float _currentPieceWidth = 3.5f;


    // Start is called before the first frame update
    void Start()
    {
        SpawnNewPiece();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0))
        {
            DropCurrentPiece();
        }
    }



    void SpawnNewPiece ()
    {
        if (_currentPiece != null)
        {
            _previousPiece = _currentPiece;
        }

        _currentPiece = Instantiate(piecePrefab).transform;
        _currentPiece.position = new Vector3(0, _spawnYpos + pieceFloatHeight, 0);
        _currentPiece.localScale = new Vector3 (_currentPieceWidth, _currentPiece.localScale.y, _currentPiece.localScale.z);
    }



    void DropCurrentPiece ()
    {
        Destroy(_currentPiece.GetComponent <PieceBehavior> ());
        _currentPiece.position = new Vector3(_currentPiece.position.x, _spawnYpos, 0);
        _spawnYpos += 1;
        cameraBehavior.OnPieceDropped ();

        // Chop our piece based on offset
        if (_previousPiece != null)
        {
            ChopDroppedPiece();
        }

        // Spawn new piece, start over
        SpawnNewPiece();
    }


    void ChopDroppedPiece ()
    {
        float pieceOffset = _currentPiece.position.x - _previousPiece.position.x;
        float amountToChop = Mathf.Abs(pieceOffset);
        _currentPieceWidth = _currentPieceWidth - amountToChop;

        if (_currentPieceWidth <= 0)
        {
            Debug.Log("YOU LOSE");
        }
        else
        {
            _currentPiece.localScale = new Vector3(_currentPiece.localScale.x - amountToChop, _currentPiece.localScale.y, _currentPiece.localScale.z);
        }

        //_currentPiece.localScale = new Vector3 ()
    }
}
