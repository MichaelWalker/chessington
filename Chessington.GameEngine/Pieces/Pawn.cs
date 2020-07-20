﻿using System.Collections.Generic;
 
 namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var nextSquare = NextSquare(currentSquare);
            var squareTwoInFront = NextSquare(nextSquare);

            var availableMoves = new List<Square>();

            if (CanMoveForwardOneSquare(board, nextSquare))
            {
                availableMoves.Add(nextSquare);
            }
            
            if (CanMoveForwardTwoSquares(board, currentSquare, nextSquare, squareTwoInFront))
            {
                availableMoves.Add(squareTwoInFront);
            }

            return availableMoves;
        }

        private bool CanMoveForwardOneSquare(Board board, Square nextSquare)
        {
            return board.IsSquareFree(nextSquare);
        }

        private bool CanMoveForwardTwoSquares(Board board, Square currentSquare, Square nextSquare, Square squareTwoInFront)
        {
            return HasNotMoved(currentSquare)
                   && board.IsSquareFree(nextSquare)
                   && board.IsSquareFree(squareTwoInFront);
        }

        private Square NextSquare(Square currentSquare)
        {
            if (Player == Player.Black)
            {
                return Square.At(currentSquare.Row + 1, currentSquare.Col);
            }
            return Square.At(currentSquare.Row - 1, currentSquare.Col);
        }

        private bool HasNotMoved(Square currentSquare)
        {
            if (Player == Player.Black)
            {
                return currentSquare.Row == 1;
            }

            return currentSquare.Row == 6;
        }
    }
}