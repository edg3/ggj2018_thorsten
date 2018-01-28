using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    // This is for front page technicallu, I havent decided what to do
    public enum GameResults
    {
        NoResult,
        Win,
        Loss
    }
    class MemoryBinding
    {
        public static GameResults LastGameResult = GameResults.NoResult;
    }
}
