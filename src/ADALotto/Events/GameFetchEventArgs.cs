using System;
using ADALotto.ClientLib;
using ADALottoModels;

namespace ADALotto.Events
{
    public class GameFetchEventArgs : EventArgs
    {
        public ALGameState? GameState { get; set; }
        public ALGame? Game { get; set; }
    }
}