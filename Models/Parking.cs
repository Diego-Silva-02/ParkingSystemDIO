namespace ParkingSystem.Models
{
    public class Parking
    {
        public float InitialPrice { get; set; }
        public float PricePerHour { get; set; }
        public List<string>? Vehicles { get; set; } = new List<string>();

        public Parking(float initialPrice, float pricePerHour)
        {
            InitialPrice = initialPrice;
            PricePerHour = pricePerHour;
        }

        public static void OpenParking()
        {
            Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");
            Console.WriteLine("Digite o preço inicial:");

            float initialPrice = float.Parse(Console.ReadLine()!);

            Console.WriteLine("Agora digite o preço por hora:");

            float pricePerHour = float.Parse(Console.ReadLine()!);

            Parking parking = new Parking(initialPrice, pricePerHour);

            parking.ShowOptions(parking);
        }

        public void ShowOptions(Parking parking)
        {
            Console.Clear();

            Console.WriteLine("Digite sua opção" +
            "\n1 - Cadastrar veículo" +
            "\n2 - Remover veículo" +
            "\n3 - Listar veículo" +
            "\n4 - Encerrar\n");

            int option = int.Parse(Console.ReadLine()!);

            Parking.Options(option, parking);
        }

        private static void Options(int option, Parking parking)
        {
            if (option != 4)
            {
                switch (option)
                {
                    case(1):
                        CreateVehicles(parking);
                        break;
                    case(2):
                        DeleteVehicles(parking);
                        break;
                    case(3):
                        ListVehicles(parking);
                        break;
                    default:
                        Console.WriteLine("Por favor, escolha uma opção válida!");
                        break;
                }

                parking.ShowOptions(parking);
            }
        }

        private static void CreateVehicles(Parking parking) 
        {
            Console.WriteLine("Digite a placa do veículo para estacionar");
            string licensePlate = Console.ReadLine()!;

            parking.Vehicles?.Add(licensePlate);

            parking.PressKeyToContinue();
        }

        private static void ListVehicles(Parking parking)
        {
            Console.WriteLine("Os veículos estacionados são:");

            foreach(string vehicle in parking.Vehicles!)
            {
                Console.WriteLine(vehicle);
            }

            parking.PressKeyToContinue();
        }

        private static void DeleteVehicles(Parking parking)
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string licensePlate = Console.ReadLine()!;

            parking.Vehicles?.Remove(licensePlate);

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            int amountHours = int.Parse(Console.ReadLine()!);

            float totalPrice = parking.InitialPrice + (parking.PricePerHour * amountHours);

            Console.WriteLine($"O veículo {licensePlate} foi removido e o preço total foi de: R$ {totalPrice}");

            parking.PressKeyToContinue();
        }

        private void PressKeyToContinue()
        {
            Console.WriteLine("Precione uma tecla para continuar");
            Console.ReadKey();
        }
    }
}