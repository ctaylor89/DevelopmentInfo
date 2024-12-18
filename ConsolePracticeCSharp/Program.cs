using DevelopmentInfo.Entities;

var pod01 = new Pod();
Phases Mode = Phases.PowerOn;
int modeVal = (int)Mode;

pod01.PodMode = Phases.PowerOn;     // Assign an enum value to the enum class property
pod01.Id = 77009;

if (Mode == Phases.PowerOn)
{
    Console.WriteLine($"Mode = {Mode}  modeVal = {modeVal} mode Value = {(int)Mode}");
}

int result01 = pod01.Id == 77009 ? 100 : 30;
Console.WriteLine($"The pod name is {pod01.Name}.  {pod01.Description}  Pod level = {(pod01.Id == 77009 ? "100" : "30")}");

var cars = new String[] { "Camry", "Mustang" };
foreach (var car in cars)
{
    Console.WriteLine($"Make: {car}");
}

var r = 2.3;
Console.WriteLine($"The area of a circle with radius {r} is {Math.PI * r * r:F3}.");
Console.WriteLine($"Pod level = {(pod01.Id == 77009 ? "100" : "30")}");

var nameParts = new String[] { "Simon ", "Butter", "field" };
pod01.Name = String.Concat(nameParts);
pod01.PrintPodName();

return;

