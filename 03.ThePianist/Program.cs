using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|").ToArray();
                string piece = input[0];
                string composer = input[1];
                string key = input[2];
                Piece currentPiece = new Piece(piece, composer, key);
                pieces.Add(piece, currentPiece);
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Stop")
                {
                    break;
                }
                if (command.Contains("Add"))
                {
                    string[] cmd = command.Split("|").ToArray();
                    string currentPiece = cmd[1];
                    if (pieces.ContainsKey(currentPiece))
                    {
                        Console.WriteLine($"{currentPiece} is already in the collection!");
                    }
                    else
                    {
                        Piece newPiece = new Piece(cmd[1], cmd[2], cmd[3]);
                        pieces.Add(cmd[1], newPiece);
                        Console.WriteLine($"{cmd[1]} by {cmd[2]} in {cmd[3]} added to the collection!");
                    }
                }
                else if (command.Contains("Remove"))
                {
                    string[] cmd = command.Split("|").ToArray();
                    string pieceToRemove = cmd[1];
                    if (!pieces.ContainsKey(pieceToRemove))
                    {
                        Console.WriteLine($"Invalid operation! {pieceToRemove} does not exist in the collection.");
                    }
                    else
                    {
                        pieces.Remove(pieceToRemove);
                        Console.WriteLine($"Successfully removed {pieceToRemove}!");
                    }
                }
                else if (command.Contains("ChangeKey"))
                {
                    string[] cmd = command.Split("|").ToArray();
                    string pieceToChange = cmd[1];
                    string newKey = cmd[2];
                    if (!pieces.ContainsKey(pieceToChange))
                    {
                        Console.WriteLine($"Invalid operation! {pieceToChange} does not exist in the collection.");
                    }
                    else
                    {
                        pieces[pieceToChange].Key = newKey;
                        Console.WriteLine($"Changed the key of {pieceToChange} to {newKey}!");
                    }
                }

                
            }

            foreach (var piece in pieces.OrderBy(x => x.Value.PieceName).ThenBy(x => x.Value.Composer))
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }

        class Piece
        {
            public string PieceName { get; set; }
            public string Composer { get; set; }
            public string Key { get; set; }

            public Piece(string name, string composer, string key)
            {
                this.PieceName = name;
                this.Composer = composer;
                this.Key = key;
            }
        }
    }
}
