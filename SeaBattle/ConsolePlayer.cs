using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle

{
    public interface IPlayer// получатеся игре будет без разницы какого игрока реализовывать, можно плодить их сколько угодно, и нужно наверное 
                            //сделать тоже самое для заполнения кораблей, чтобы игроку было без разницы кого рализовывать!!!
    {
        PlayArea PlayArea { get; set; }        

        bool IsLose();
    }
    // какой плеер? что то выглядит как какой то гейм хелпер а не плеер
    public class ConsolePlayer : IPlayer
    {
        // не уверен что оно должно быть прям паблик
        public PlayArea PlayArea { get; set; }

        // Не очевидно что делает это свойсво и за что отвечает
        // из кода выше выглядит так как будто оно тут и не надо, это не обязанность игрока
        public bool IsLose()
        {
            return !IsPlayAreaHaveBusyDeck();
        }

        public ConsolePlayer(IShipsFiller fill)
        {
            this.PlayArea = new PlayArea();
            fill.FillShips(PlayArea.Cells);         
        }

        private bool IsPlayAreaHaveBusyDeck()
        {
            for (int i = 0; i < PlayArea.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < PlayArea.Cells.GetLength(1); j++)
                {
                    if (PlayArea.Cells[i, j].State == CellState.BusyDeck)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Игровая логика, игрок должен стрелять, поидее не его обязанность проверять попал или нет, тем более обновлять ячейки
        public PlayArea Shoot(PlayArea playAreaEnemy, int y, int x)
        {
            // неочевидная логика
            if (playAreaEnemy.Cells[y, x].State == CellState.BusyDeck && playAreaEnemy.Cells[y, x].State != CellState.HasShooted)
            {
                playAreaEnemy.Cells[y, x].State = CellState.HasShooted;                
                return playAreaEnemy;
            }
            else if (playAreaEnemy.Cells[y, x].State != CellState.HasShooted)
            {
                playAreaEnemy.Cells[y, x].State = CellState.HasMiss;                
                return playAreaEnemy;
            }
            // так может стрелять лучше сразу только туда куда можно? зач
            return playAreaEnemy;
        }
    }

    public class BotPlayer : IPlayer
    {
        public PlayArea PlayArea { get; set; }

        public BotPlayer(IShipsFiller fill)
        {
            this.PlayArea = new PlayArea();
            fill.FillShips(PlayArea.Cells);
        }        

        public bool IsLose()
        {
            throw new System.NotImplementedException();
        }
    }

}
