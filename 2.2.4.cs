// See https://aka.ms/new-console-template for more information
IMyAsyncInterface myAsyncInterface = new MySynchronousImplementation();
try 
{
    await myAsyncInterface.DoSomethingAsync();
    Console.WriteLine("Задача завершилась успешно");
}
catch (Exception ex)
{
    Console.WriteLine("Получено исключение: {0}", ex.Message);
}
interface IMyAsyncInterface
{
    Task DoSomethingAsync();
}
class MySynchronousImplementation : IMyAsyncInterface
{
    private void DoSomethingSynchronously()
    {
        throw new Exception("Тестовое исключение");
    }
    public Task DoSomethingAsync()
    {
        try
        {
            DoSomethingSynchronously();
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            return Task.FromException(ex);
        }
    }
}