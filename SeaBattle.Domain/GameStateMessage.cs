
namespace SeaBattle
{
    public static class GameStateMessage
    {
        public static string WhoShoot(string namePlayer)
        {
            return $"{namePlayer} turn to shoot";
        }

        public static string WhoHitAndShoot(string namePlayer)
        {
            return $"{namePlayer} hit the target.\n" + WhoShoot(namePlayer);
        }

        public static string WhoMissAndShoot(string namePlayerWhoMiss, string namePlayerWhoShoot)
        {
            return $"{namePlayerWhoMiss} miss the target.\n" + WhoShoot(namePlayerWhoShoot);
        }

        public static string WhoKillAndShoot(string namePlayer)
        {
            return $"{namePlayer} kill the ship.\n" + WhoShoot(namePlayer);
        }

        public static string WhoShootSameCellAndWhoShoot(string namePlayer)
        {
            return $"{namePlayer} already shot this area.\n" + WhoShoot(namePlayer);
        }

        public static string WhoWinGame(string namePlayer)
        {
            return $"{namePlayer} win the game. ";
        }
    }
}
