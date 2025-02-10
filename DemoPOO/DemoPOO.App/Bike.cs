public class Bike : Veiculo
{
    // B
    public Bike(string marca) : base(marca)
    {
    }

    // A
    public Bike() : this ("[Sem Marca]")
    {
      
    }

    public  void Something() { }

    public override void Jump()
    {
        Console.WriteLine("Jump......Bike");
    }

    protected override void Move()
    {
        base.Move();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    //public override string ToString()
    //{
    //    return $"Bike: Marca: {Marca}, ModelYear: {modelYear}";
    //}

    public void None()
    {
        throw new NotImplementedException();
    }

    public void Start()
    { Console.WriteLine("..... start bike"); }

    public void Stop()
    { Console.WriteLine("... Stopping bike"); }
}