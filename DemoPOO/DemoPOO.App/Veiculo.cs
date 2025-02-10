using System.Text.Json;

// sealed classes


public class Gadget
{
    public void Buy() { }

}
public class Rato : Gadget
{
    public int Buttons { get; set; }
    private string Make { get; set; }

    public Rato(string marca) : base()
    {
        this.Make = marca;
    }

    public void SetMake (string make) => this.Make = make;
    public string GetMake (string make) => this.Make;


    public override string ToString()
    {
        return $"Marca: {Make}, " + JsonSerializer.Serialize(this);
    }

    public void Buy()
    {
        base.Buy();
        // do something else
    }

    public Rato(int buttons) 
    {
        this.Buttons = buttons;
    }

    public Rato() : this("Logitech")
    {
        
    }
}



public abstract class Veiculo
{
    public string Marca { get; set; }
    protected int modelYear;

    public override string ToString()
    {
        return $"Veiculo: Marca: {Marca}, ModelYear: {modelYear}";
    }

    protected virtual void Move()
    { }

    public virtual void Jump() { }

    protected Veiculo(int modelYear)
    {
        this.modelYear = modelYear;
    }

    // C
    protected Veiculo(string marca)
    {
        Marca = marca;
    }

    protected Veiculo()
    {
    }
}