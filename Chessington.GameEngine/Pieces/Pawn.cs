﻿using System.Collections.Generic;
using System.Linq;
 using System.Runtime.ConstrainedExecution;

 namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            if (HasMoved(currentSquare))
            {
                if (Player == Player.Black)
                {
                    return new List<Square>
                    {
                        Square.At(currentSquare.Row + 1, currentSquare.Col)
                    };
                }
                
                return new List<Square>
                {
                    Square.At(currentSquare.Row - 1, currentSquare.Col)
                };
            }
            
            if (Player == Player.Black)
            {
                return new List<Square>
                {
                    Square.At(currentSquare.Row + 1, currentSquare.Col),
                    Square.At(currentSquare.Row + 2, currentSquare.Col)
                };
            }
                
            return new List<Square>
            {
                Square.At(currentSquare.Row - 1, currentSquare.Col),
                Square.At(currentSquare.Row - 2, currentSquare.Col)
            };
        }

        private bool HasMoved(Square currentSquare)
        {
            if (Player == Player.Black)
            {
                return currentSquare.Row != 1;
            }

            return currentSquare.Row != 6;
        }
    }
}