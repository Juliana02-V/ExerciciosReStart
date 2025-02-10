public class Moto : IVeiculo
{
    public void None()
    {
        throw new NotImplementedException();
    }

    public void Start()
    { Console.WriteLine("Starting moto"); }

    public void Stop()
    { Console.WriteLine("Stopping moto"); }
}