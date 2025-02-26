using Alterdata.TesteFullstackBackend.Core.Entities;

namespace Alterdata.TesteFullStackBackend.Data.Context
{
    public static class DatabaseSeeder
    {
        public static void Seed(DbMemoryContext context)
        {
            if (!context.Clients.Any())
            {
                context.Clients.AddRange(new List<Client>
                {
                    new Client("João Silva", "joao@email.com", "(11) 91234-5678", true),
                    new Client("Maria Souza", "maria@email.com", "(21) 97654-3210", false),
                    new Client("Carlos Pereira", "carlos@email.com", "(31) 98877-6655", true),
                    new Client("Ana Clara", "ana@email.com", "(41) 95555-1234", true),
                    new Client("Bruno Fernandes", "bruno@email.com", "(51) 94444-5678", false),
                    new Client("Fernanda Oliveira", "fernanda@email.com", "(61) 93333-9876", true),
                    new Client("Gabriel Lima", "gabriel@email.com", "(71) 92222-1111", false),
                    new Client("Juliana Costa", "juliana@email.com", "(81) 91111-2222", true),
                    new Client("Ricardo Mendes", "ricardo@email.com", "(91) 98888-3333", false),
                    new Client("Larissa Andrade", "larissa@email.com", "(11) 97777-4444", true),
                    new Client("Fábio Moreira", "fabio@email.com", "(21) 96666-5555", true),
                    new Client("Tatiane Rocha", "tatiane@email.com", "(31) 95555-6666", false),
                    new Client("Diego Nascimento", "diego@email.com", "(41) 94444-7777", true),
                    new Client("Aline Figueiredo", "aline@email.com", "(51) 93333-8888", false),
                    new Client("César Almeida", "cesar@email.com", "(61) 92222-9999", true),
                    new Client("Jéssica Souza", "jessica@email.com", "(71) 91111-1010", true),
                    new Client("Vinícius Ribeiro", "vinicius@email.com", "(81) 98888-1212", false),
                    new Client("Patrícia Fernandes", "patricia@email.com", "(91) 97777-1313", true),
                    new Client("Thiago Martins", "thiago@email.com", "(11) 96666-1414", false),
                    new Client("Beatriz Carvalho", "beatriz@email.com", "(21) 95555-1515", true),
                    new Client("Roberto Neves", "roberto@email.com", "(31) 94444-1616", false),
                    new Client("Camila Barros", "camila@email.com", "(41) 93333-1717", true),
                    new Client("Eduardo Lopes", "eduardo@email.com", "(51) 92222-1818", true),
                    new Client("Natália Duarte", "natalia@email.com", "(61) 91111-1919", false),
                    new Client("Felipe Teixeira", "felipe@email.com", "(71) 98888-2020", true),
                    new Client("Luana Cardoso", "luana@email.com", "(81) 97777-2121", false),
                    new Client("Gustavo Rocha", "gustavo@email.com", "(91) 96666-2222", true),
                    new Client("Renata Ferreira", "renata@email.com", "(11) 95555-2323", false),
                    new Client("Anderson Silva", "anderson@email.com", "(21) 94444-2424", true)
                });
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>
                {
                    new Product("Notebook Dell Inspiron", 4500.99m, 10),
                    new Product("Mouse Logitech MX Master", 350.75m, 20),
                    new Product("Teclado Mecânico Razer", 799.99m, 15),
                    new Product("Monitor 24' Samsung", 1200.50m, 8),
                    new Product("Cadeira Gamer Redragon", 950.99m, 5),
                    new Product("Headset HyperX Cloud II", 499.99m, 12),
                    new Product("Impressora HP DeskJet", 650.00m, 7),
                    new Product("Smartphone Samsung Galaxy S21", 3199.99m, 20),
                    new Product("Tablet Apple iPad", 4299.00m, 6),
                    new Product("Smartwatch Xiaomi Mi Band 7", 299.90m, 30),
                    new Product("Placa de Vídeo RTX 3070", 3599.99m, 4),
                    new Product("Processador AMD Ryzen 7", 2200.00m, 9),
                    new Product("Memória RAM 16GB DDR4", 499.99m, 25),
                    new Product("HD Externo 1TB", 399.99m, 18),
                    new Product("SSD NVMe 500GB", 649.99m, 15),
                    new Product("Fonte Corsair 750W", 849.90m, 10),
                    new Product("Gabinete Gamer RGB", 599.99m, 5),
                    new Product("Microfone Condensador Blue Yeti", 899.99m, 8),
                    new Product("Webcam Logitech C920", 549.99m, 12),
                    new Product("Roteador TP-Link Archer AX73", 799.99m, 10),
                    new Product("Teclado sem fio Logitech K380", 249.99m, 30),
                    new Product("Mousepad Gamer RGB", 149.99m, 20),
                    new Product("Fone de Ouvido JBL Tune 500", 199.99m, 25),
                    new Product("Controle Xbox Series X", 499.99m, 15),
                    new Product("Volante Logitech G29", 1799.99m, 6),
                    new Product("Monitor Ultrawide LG 34'", 2999.99m, 4),
                    new Product("Notebook Lenovo ThinkPad", 5200.00m, 10),
                    new Product("Pen Drive 128GB", 99.99m, 50),
                    new Product("Câmera de Segurança IP", 349.99m, 22),
                    new Product("HDMI 2.1 Cable 2m", 89.99m, 40)
                });
            }

            context.SaveChanges();
        }
    }
}
