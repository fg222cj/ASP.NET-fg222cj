using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HemligaTalet.Model
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }

    public class SecretNumber
    {
        #region Privata fält och konstanter

        private int _number;
        private List<int> _previousGuesses;
        const int MaxNumberOfGuesses = 7;

        #endregion
        #region Egenskaper

        public bool CanMakeGuess
        {
            get
            {
                if (Count < MaxNumberOfGuesses)
                {
                    return true;
                }
                return false;
            }
        }

        public int Count
        {
            get
            {
                return PreviousGuesses.Count();
            }
        }

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }

                return _number;
            }
        }

        public Outcome Outcome { get; set; }

        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }

        #endregion

        public void Initialize()
        {
            Random r = new Random();
            _number = r.Next(1, 100);

            _previousGuesses.Clear();

            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (!CanMakeGuess)
            {
                return Outcome.NoMoreGuesses;
            }

            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (PreviousGuesses.Contains(guess))
            {
                return Outcome.PreviousGuess;
            }

            _previousGuesses.Add(guess);

            if (guess < _number)
            {
                return Outcome.Low;
            }

            if (guess > _number)
            {
                return Outcome.High;
            }

            return Outcome.Correct;
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>(7);
            Initialize();
        }
    }
}