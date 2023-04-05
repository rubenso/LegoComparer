namespace LegoComparer.Abstaraction
{
    interface ILegoComparer<T>
    {
        Task<bool> Compare(IEnumerable<T> userPieces, IEnumerable<T> setPieces);
    }
}
