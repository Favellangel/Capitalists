using Player;

/// <summary>
/// класс провайдер, для предоставления данных об игроках
/// </summary>
public class Players 
    {
        public static IPlayer current => Proxy<PlayerProxy>.Instance;
        public static IPlayers all => Proxy<PlayersProxy>.Instance;
    }
