namespace Code.Core.Services.Savings
{
    public interface ISaveLoadService
    {
        void Save(string key, byte[] data);
        bool TryLoad(string key, out byte[] data);
        void Delete(string key);
    }
}