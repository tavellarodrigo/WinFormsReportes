using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Diagnostics;
using IContainer = QuestPDF.Infrastructure.IContainer;

namespace WinFormsReportes
{
    public partial class Form1 : Form
    {
        List<Persona> _listaPersonas;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            // Obtener la fecha y hora actual
            DateTime now = DateTime.Now;

            // Formatear la fecha y hora
            string dateTime = now.ToString("yyyyMMdd_HHmmss");


            string baseName = "Reportepersonas";
            string extension = "pdf";
            // Crear el nombre de archivo único
            string fileName = $"{baseName}_{dateTime}.{extension}";


            // code in your main method
            // Datos de ejemplo para la tabla
            var data = _listaPersonas;
            // Ruta de la imagen para el encabezado
            string imagePath = "logo.png"; // Actualiza esta ruta con la ubicación de tu imagen


            // Crear el documento PDF
            Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12))
                    ;

                    page.Header()
                    .Background(Colors.White) // Asegurar que el fondo del encabezado sea blanco
                    .Padding(10)
                    .Element(ComposeHeader(imagePath));

                    /*page.Header()                    
                        .Text("Informe de Socios")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium)
                        ;
                    */
                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Table(table =>
                        {
                            // Definir columnas de la tabla
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(90);
                                columns.ConstantColumn(90);
                                //columns.RelativeColumn();
                                columns.ConstantColumn(90);
                                columns.ConstantColumn(90);
                               
                            });

                            // Encabezados de la tabla
                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("Id").Bold();
                                header.Cell().Element(CellStyle).Text("Nombre").Bold();
                                header.Cell().Element(CellStyle).Text("Edad").Bold();
                                header.Cell().Element(CellStyle).Text("Nacimiento").Bold();                                
                            });

                            // Rellenar datos de la tabla
                            foreach (var item in data)
                            {
                                
                                table.Cell().Element(CellStyle).Text(item.id);
                                table.Cell().Element(CellStyle).Text(item.name);
                                table.Cell().Element(CellStyle).Text(item.age);                                
                                table.Cell().Element(CellStyle).Text(item.birthday.ToString("dd/MM/yyyy"));
                                //table.Cell().Element(CellStyle).Text(item.Price.ToString("C"));
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                });
            })
            .GeneratePdf(fileName);


            
            
            if (MessageBox.Show("El reporte se genero en " + fileName+ ". Desea abrirlo?","",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se pudo abrir el archivo PDF: " + ex.Message);
                }
            }
        }

        static Action<IContainer> ComposeHeader(string imagePath)
        {
            return container =>
            {
                container.Column(column =>
                {
                    column.Item().Row(row =>
                    {
                        /*row.ConstantItem(100)
                            .Height(50)
                            .Background(Colors.White)
                            .Image(imagePath);*/

                        row.ConstantItem(100)
                            .AlignLeft()
                            //.Height(150)
                            .Background(Colors.White)
                            .Image(imagePath);


                        row.RelativeItem()
                            .AlignMiddle()
                            .AlignTop()
                            .Padding(15)
                            .Background(Colors.White)
                            .Text("       Informe de Personas")
                            .SemiBold().FontSize(15).FontColor(Colors.Blue.Medium);                    

                    });

                    //column.Item().AlignRight().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                    //    .FontSize(12)
                    //    .FontColor(Colors.Grey.Medium);
                });
            };
        }
        static IContainer CellStyle(IContainer container)
        {
            return container
                .Border(1)
                .BorderColor(Colors.Grey.Lighten2)
                .Padding(5)
                .AlignMiddle()
                .AlignCenter();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listaPersonas =
            [
                new Persona { age = 20,birthday = DateTime.Now,id = 1,name = "Lionel" },
                new Persona { age = 25, birthday = DateTime.Now, id = 2, name = "Dibu" },
                new Persona { age = 30, birthday = DateTime.Now, id = 3, name = "Julian" },
            ];

        }
    }
}
