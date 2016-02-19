using System;

namespace TicTacToe
{
    class TicTacToeGame {
        private int[,] board; //2-D board
        private const int BOARD_SIZE = 3; //Size of the board will be 3 x 3
        private int empty = 0; //initialize to X player

        //DEFAULT CONSTRUCTOR
        public TicTacToeGame() {
            board = new int[BOARD_SIZE, BOARD_SIZE]; //initialize board to 0
        }//end TicTacToeGame constructor

        //PRINT DEFAULT BOARD
        public void PrintBoard() {            
            int rows = -1;
            for (int cols = 0; cols < 3; cols++) {
                Console.Write("  "+cols+" ");
            }
            for (int x = 0; x < BOARD_SIZE; x++) {               
                rows++;
                Console.WriteLine("\n"+rows);
                for (int y = 0; y < BOARD_SIZE; y++) {
                    if (board[x, y] == empty) {
                        Console.Write("  "+"."+" ");
                    }//end empty check                    
                }//end col for loop
            }//end row for loop
            Console.WriteLine("\n");                       
        }//end PrintBoard()

        //UPDATE THE BOARD AS GAME GOES ON
        //board: The game board
        public void UpdateBoard(int [,] board) {
            int rows = -1;
            for (int cols = 0; cols < 3; cols++) {
                Console.Write("  " + cols + " ");
            }
            for (int x = 0; x < BOARD_SIZE; x++) {
                rows++;
                Console.WriteLine("\n" + rows);
                for (int y = 0; y < BOARD_SIZE; y++) {
                    
                    if (board[x, y] == empty){
                        Console.Write("  " + "." + " "); //outputs dots to represent empty
                    }//end empty check
                    if (board[x, y] == 1) {
                        Console.Write("   " + "1"); //player 1's piece
                    }
                    if (board[x, y] == -1) {
                        Console.Write("   " + "2"); //player 2's piece
                    }
                }//end col for loop
            }//end row for loop
            Console.WriteLine("\n");
        }//end UpdateBoard function

        //CHECK WHETHER PLAYER 1 OR 2 WON THE GAME.
        //ITERATES THROUGH THE BOARD AND KEEPS TRACK OF THE PLAYER. 
        //board: Game board
        //player: The current player 
        public bool CheckResult(int [,] board, int player) {
            for (int x = 0; x < BOARD_SIZE; x++) {
                for (int y = 0; y < BOARD_SIZE; y++) {
                    //HORIZONTAL CHECK FOR WINNERS                 
                    if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) {
                        return true;
                    }//check to see if first row is filled with X

                    if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) {                        
                        return true;
                    }//check to see if second row is filled with X

                    if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) {                        
                        return true;
                    }//check to see if third row is filled with X
                    //END HORIZONTAL CHECKS

                    //VERTICAL CHECKS
                    if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) {                        
                        return true;
                    }//check to see if first col is filled with X (vertical)

                    if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) {                        
                        return true;
                    }//check to see if second col is filled with O (vertical)

                    if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) {                        
                        return true;
                    }//check to see if third col is filled with O (vertical)
                    //END VERTICAL CHECKS

                    //DIAGONALS CHECKS
                    if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) {                        
                        return true;
                    }//end left corner to right corner check 
                    if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) {                        
                        return true;
                    }//end left corner to right corner check 
                    //END DIAGONAL CHECKS
                }//end column check
            }//end rows check
            return false;
        }//end CheckWinner()

        // CHECKS TO SEE IF THE GAME IS A DRAW.
        //moves: Counting variable. Tic Tac Toe has a max of 9 moves, so if all
        //9 moves have been made, but no winner, that means it's a draw
        public bool isDraw(int moves) {        
            return moves == 9;
        }//end isDraw()

        //MAIN GAME METHOD. THIS METHOD IS WHERE THE MAIN GAME LOGIC IS
        public void Play() {
            TicTacToeGame game = new TicTacToeGame();
            int[,] gameBoard = new int[BOARD_SIZE, BOARD_SIZE]; //initialize game board
            bool gameLoop = true; // boolean value for main game loop
            int currPlayer = 1, row = 0, col = 0, moves = 0;
            String sCurrPlayer = "1", sRow, sCol;

            currPlayer = Int32.Parse(sCurrPlayer);//initialize to player 1           

            do {
                //FOR OUTPUT PURPOSES. CHECKS TO SEE WHOSE TURN IT IS AND DISPLAY IT
                if (currPlayer == 1) {
                    Console.WriteLine("Player 1's Turn");
                }
                else {
                    Console.WriteLine("Player 2's Turn");
                }//end turn output               
                Console.WriteLine("Enter row value: ");
                sRow = Console.ReadLine();
                row = Int32.Parse(sRow);
                //CHECK TO MAKE SURE ROWS AREN'T NEGATIVE OR OUT OF BOUNDS
                while (row < 0 || row > 2) {
                    Console.WriteLine("Invalid row value. Re-enter: ");
                    sRow = Console.ReadLine();
                    row = Int32.Parse(sRow);
                }//end check for valid row value
                Console.WriteLine("Enter column value: ");
                sCol = Console.ReadLine();
                col = Int32.Parse(sCol);
                //CHECK TO MAKE SURE COLUMNS AREN'T NEGATIVE OR OUT OF BOUNDS
                while (col < 0 || col > 2) {
                    Console.WriteLine("Invalid column value. Re-enter: ");
                    sCol = Console.ReadLine();
                    col = Int32.Parse(sCol);
                }//end check for valid column 

                //CHECK TO SEE IF THE SPACE IS EMPTY
                while (gameBoard[row, col] != empty) {
                    Console.WriteLine("Space is not empty. Re-enter row and col:");
                    Console.WriteLine("Re-enter row: ");
                    sRow = Console.ReadLine(); // takes value of row as a string
                    row = Int32.Parse(sRow);// parse
                    while (row < 0 || row > 2) {
                        Console.WriteLine("Re-enter row: ");
                        sRow = Console.ReadLine();
                        row = Int32.Parse(sRow);
                    }//end row/empty check
                    Console.WriteLine("Re-enter col: ");
                    sCol = Console.ReadLine();
                    col = Int32.Parse(sCol);
                    while (col < 0 || col > 2) {
                        Console.WriteLine("Re-enter col: ");
                        sCol = Console.ReadLine();
                        col = Int32.Parse(sCol);
                    }//end row/empty check
                }//end overall empty square check

                //APPLY THE PIECE IF VALID
                gameBoard[row, col] = currPlayer; //sets the square specified by player to player's piece               
                game.UpdateBoard(gameBoard); //update the board
                moves++; //increment number of moves made (used to check for draw)
                if (CheckResult(gameBoard, currPlayer)) {
                    if (currPlayer == 1) 
                        Console.WriteLine("Player 1 Wins!");                    
                    else 
                        Console.WriteLine("Player 2 Wins!");                    
                    break;
                }//end the check for a win
                if (isDraw(moves)) {
                    Console.Write("Draw.");
                    break;
                }//end check for draw
                currPlayer *= -1; //TOGGLE PLAYER               
            } while (gameLoop);
            Console.Read();
        }//end Play()
    }//end class TicTacToeGame

    //BEGINNING OF MAIN CLASS
    class MainClass
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame();
            game.PrintBoard();
            game.Play();           
        }//end main method
    }//end main class
}//end namespace
