var rato = new Rato("Logitech") { Buttons = 4 };

Gadget gadget = rato;

var r = gadget as Rato;
r.SetMake ( "Microsoft");

Console.WriteLine(rato);    //4: Logitech  
Console.WriteLine(gadget);  //4: Logitech
Console.WriteLine(r);       //4: Microsoft 


rato = gadget as Rato;
Console.WriteLine(rato);


if (gadget is Rato mouse)
    rato = mouse;

rato = (Rato)gadget;


Console.WriteLine(rato);


var bike = new Bike("Mercedes");
var bici = new Bicicleta();
List<Veiculo> veiculos = new List<Veiculo>()
{
    bike,
    bici,
    new Carro()
};

foreach (var veic in veiculos)
{
    veic.Jump();
}



Veiculo veiculo = bike;
object obj = bike;


Console.WriteLine(bike.ToString());
Console.WriteLine(veiculo.ToString());
Console.WriteLine(obj.ToString());


Console.WriteLine(new Carro().ToString());
Console.WriteLine(new Bike().ToString());


Console.WriteLine(bike.Marca);  //Seat

Console.WriteLine( bike.ToString());

Console.ReadLine();

//List<IVeiculo> veiculos = new();
//IVeiculo moto = new Moto();
//IVeiculo bike = new Bike();

//bike.Update();

//veiculos.AddRange(moto, bike);

//foreach (var veiculo in veiculos)
//{
//    veiculo.None();
//    veiculo.Start();
//    veiculo.Stop();

//    if (veiculo is Moto moto1)
//        moto1.Start();
//    else if (veiculo is Bike bike1)
//        bike1.Start();

//    // veiculo.Start();
//}
