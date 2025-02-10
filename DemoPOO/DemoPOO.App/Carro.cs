public class Animal { }


public class Carro : Veiculo
{
    private int _miles;

    public int Miles
    {
        get { return _miles; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Miles cannot be negative");
            }
            _miles = value;
        }
    }

    private string _plate;

    public string Plate
    {
        get { return _plate; }  // var plate = carro.Plate;
        set { _plate = value; }                 // carro.Plate = "AB-C1-34";
    }

    //
    private int _year;

    // >= 1900 && <= current year
    public int Year
    {
        get { return _year; }
        set
        {
            if (value < 1900)
                _year = 1900;
            else if (value > DateTime.Now.Year)
                _year = DateTime.Now.Year;
            else
                _year = value;
        }
    }

    private int kms;

    private int GetKms()
    {
        return kms;
    }

    public void SetKms(int kms)
    {
        // this.kms = kms;
    }

    public void DoSomething()
    {
        //Start();
        Move();
        // XXX Stop()
    }

    private void MoveCarro()
    { }

    public override void Jump()
    {
        Console.WriteLine("Jumpooo......Carro");
    }

    public Carro(string marca)
    {
    }

    public Carro(int kms)
    {
    }

    public Carro()
    {
        
    }
}