namespace SeaBattleApi
{
    public class PlayerClient
    {
        public string Name { get; set; }

        public string ID { get; } = Guid.NewGuid().ToString(); 
    }
}
