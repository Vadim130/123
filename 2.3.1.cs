// See https://aka.ms/new-console-template for more information
await CallMyMethodAsync();
async Task MyMethodAsync(IProgress<double> progress = null)
{
    bool done = false;
    double percentComplete = 0;
    while (!done)
    {
        await Task.Delay(200);
        percentComplete+=10;
        if (percentComplete >= 100)
            done = true;
        progress?.Report(percentComplete);
    }
}
async Task CallMyMethodAsync()
{
    var progress = new Progress<double>();
    progress.ProgressChanged += (sender, args) =>
    {
        Console.WriteLine("Прогресс: {0}%", args);
    };
    await MyMethodAsync(progress);
    Console.WriteLine("Все готово!");
}
