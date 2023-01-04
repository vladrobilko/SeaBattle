using System;

namespace SeaBattle
{
    public class SeaBattleGameStateChanger
    {
        public GameState ChangeGameState(GameState gameState)
        {
            if (gameState.NamePlayerTurn == gameState.Player1.NamePlayer && gameState.IsGameOn)
            {
                var target = gameState.Player1.GetNextValidShootTarget();
                var result = gameState.Player2.OnShoot(target);
                gameState.IsGameOn = (result != ShootResultType.GameOver);
                AssignGameMessage(gameState, result, gameState.Player1.NamePlayer, gameState.Player2.NamePlayer);
                if (result == ShootResultType.Miss)
                    gameState.NamePlayerTurn = gameState.Player2.NamePlayer;
                return gameState;
            }

            else if (gameState.NamePlayerTurn == gameState.Player2.NamePlayer && gameState.IsGameOn)
            {
                var target = gameState.Player2.GetNextValidShootTarget();
                var result = gameState.Player1.OnShoot(target);
                gameState.IsGameOn = (result != ShootResultType.GameOver);
                AssignGameMessage(gameState, result, gameState.Player2.NamePlayer, gameState.Player1.NamePlayer);
                if (result == ShootResultType.Miss)
                    gameState.NamePlayerTurn = gameState.Player1.NamePlayer;
                return gameState;
            }
            throw new NotFiniteNumberException();
        }

        private void AssignGameMessage(GameState gameState,ShootResultType shootResultType, string namePlayer1, string namePlayer2)
        {
            if (shootResultType == ShootResultType.Miss)
            {
                gameState.GameMessage = GameStateMessage.WhoMissAndShoot(namePlayer1, namePlayer2);
            }
            else if (shootResultType == ShootResultType.Hit)
            {
                gameState.GameMessage = GameStateMessage.WhoHitAndShoot(namePlayer1);
            }
            else if (shootResultType == ShootResultType.Kill)
            {
                gameState.GameMessage = GameStateMessage.WhoKillAndShoot(namePlayer1);
            }
            else if (shootResultType == ShootResultType.GameOver)
            {
                gameState.GameMessage = GameStateMessage.WhoWinGame(namePlayer1);
            }
        }
    }
}
