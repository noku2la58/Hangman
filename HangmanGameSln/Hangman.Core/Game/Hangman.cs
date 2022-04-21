using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string _guessProgress;
        private int _numberOfLives;


        public HangmanGame()
        {
            _renderer = new GallowsRenderer();

        }

        public void Run()
        {
            _numberOfLives = 6;

            String[] listowords = new string[] { "Mango", "Banana", "Car", "Book", "Cake", "Soup", "Cheese", "Rop", "Mop", "Window", "Door", "Ice cream", "Cap", "Nat", "Bed", "Cat", "Dog", "Yellow", "Red", "Blue" };

            Random random = new Random();
            var index = random.Next(0, 20);

            string Myguessedworeds = listowords[index];

            char[] guess = Myguessedworeds.ToCharArray();

            Console.SetCursorPosition(0, 15);
            Console.Write("What is your next guess: ");

            for (int i = 0; i < guess.Length; i++)
            {
                _guessProgress += "*";
            }

            while (true)
            {

                _renderer.Render(5, 5, _numberOfLives);

                Console.SetCursorPosition(25, 15);

                char playerguess = Char.Parse(Console.ReadLine());


                char[] guessProgressArray = _guessProgress.ToCharArray();

                bool right = false;
                for (int i = 0; i < guess.Length; i++)
                {

                    if (guess[i] == playerguess)
                    {
                        guessProgressArray[i] = guess[i];
                        right = true;
                    }



                }

                _guessProgress = new string(guessProgressArray);

                Console.WriteLine(_guessProgress);

                if (!right)
                {
                    _numberOfLives--;
                }
                if (_numberOfLives == 0) ;




            }
            Console.SetCursorPosition(2, 15);
            if (_numberOfLives > 0)
            {
                Console.WriteLine($"you dead");

            }
            else
            {

                Console.WriteLine($"you won {_numberOfLives} left");

            }


        }
    }
}        
    
      
    



