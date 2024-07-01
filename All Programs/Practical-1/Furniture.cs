namespace All_Programs.Practical_1;

public class Furniture
{
    public string material;
    public double price;
    internal class Table : Furniture
    {
        public double height, surface_area;
        public Table(string material, double price, double height, double surface_area)
        {
            this.material = material;
            this.price = price;
            this.height = height;
            this.surface_area = surface_area;
            Console.WriteLine("The dimesions of the new Table are:" +
                              "\nheight: {0}\nsurface area: {1}\nmaterial:{2}\nprice:{3}",
                this.height, this.surface_area, this.material, this.price);
        }
    }

}