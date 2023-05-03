fVehicle MyVehicle = new Vehicle("Car", "blue");
Vehicle MySkates = new Vehicle("Skates", "white", false, 1);
Vehicle MyBike = new Vehicle("Bicycle", "pink", false, 2, 67);

List<Vehicle> VehicleList = new List<Vehicle>();
VehicleList.Add(MyVehicle);
VehicleList.Add(MySkates);
VehicleList.Add(MyBike);

foreach (Vehicle item in VehicleList)
{
    item.ShowInfo();
}

MyVehicle.ShowInfo();
MySkates.ShowInfo();

MyVehicle.Travel(45);
MyVehicle.Travel(66);