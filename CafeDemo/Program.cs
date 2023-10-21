//insan
//Calisan
//Urun hazırlama
//Siparis Alma
//Musteri
//Siparis Ver

//cafe
//sira sistemi
// kasa = 3
//Sparis ver


//Urun
//Urun ozellikleri

//Siparis
//Siparis ver
//Siparis Teslimi


//Initilization

using CafeDemo;
using CafeDemo.CafeMenu;
using CafeDemo.CafeMenu.Extrass;
using CafeDemo.CafeOrder;
using CafeDemo.Enums;
using CafeDemo.People;

List<Employee> employees = new List<Employee>()
{
    new("Ahmet"),
    new("Irem"),
    new("Ali"),
    new("Veli"),
    new("Ayşe")
};

Cafe cafe = new Cafe(employees,new Product("Espresso", 10, TimeSpan.FromSeconds(2)),
    new Product("Latte", 8, TimeSpan.FromSeconds(3)),
    new Product("Türk Kahvesi", 12, TimeSpan.FromSeconds(5)));

Menu menu = new Menu();

//Musteri Gelir

var c1 = new Customer("Mehmet");

// Siraya Girer

cafe.GetInLine(c1);

// Urun secicek

//menu.MenuItems.First(item => item.Name == "Espresso");

var selectedItem = menu["Espresso"];


// Ozellikleirni belirle
var OrderItem = new OrderItems[]
{
    new OrderItems(cafe.Menu["Espresso"],CofeeSize.Small,new Milk(),new Syrup()),
    new OrderItems(cafe.Menu["Latte"],CofeeSize.Medium,new Milk()),
    new OrderItems(cafe.Menu["Türk Kahvesi"],CofeeSize.Large)
};


// Sirasini kontrol et

while (!cafe.IsNext(c1))   // sira bende mi kontrol ediyor. Değilse başa dönüyoruz while ile
{
    await Task.Delay(2000);
}

// Kasa Siparis aliyor mu

while (!cafe.CanRegisterTakeOrder())
{
    await Task.Delay(2000);
}



//Siparis ver
var receipt = await cafe.RegisterTakeOrder(c1, OrderItem);

//urunun hazirlanmasini bekle

while (!cafe.IsOrderPrepared(receipt))
{
    await Task.Delay(2000);
}

//Urunu teslim al

Order preparedOrder = cafe.ServeOrder(receipt);

//kafeden ayrıl
