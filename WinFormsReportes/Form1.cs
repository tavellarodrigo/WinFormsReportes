using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ScottPlot;
using System.Diagnostics;
using Colors = QuestPDF.Helpers.Colors;
using IContainer = QuestPDF.Infrastructure.IContainer;

namespace WinFormsReportes
{
    public partial class Form1 : Form
    {
        List<Persona> _listaPersonas = new List<Persona>();
        List<ReporteSalario> reporte = new List<ReporteSalario>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listaPersonas =
            [
                new Persona { id = 1, name = "Ana", age = 11, salary = 1000 },
                new Persona { id = 2, name = "Luis", age = 15, salary = 1200},
                new Persona { id = 3, name = "María", age = 19, salary = 1300},
                new Persona { id = 4, name = "Carlos", age = 21, salary = 1500},
                new Persona { id = 5, name = "Laura", age = 32 , salary = 1350},
                new Persona { id = 6, name = "Pedro", age = 33 , salary = 3100},
            ];

            bindingSource1.DataSource = _listaPersonas;
            btnGenerar_Click(null, null);

        }
        public static List<ReporteSalario> ObtenerReportePorFranjaSalario(List<Persona> personas)
        {
            var franjas = new List<(int id, int desde, int hasta)>
                {
                    (1,0, 1000),
                    (2,1001, 2000),
                    (3,2001, 3000),
                    (4,3001, 4000),
                    (5,4001, 9999),
                };

            var reporte = franjas.Select(f =>
                new ReporteSalario
                {
                    id = f.id,
                    franjaSalario = $"{f.desde}-{f.hasta}",
                    cantidad = personas.Count(p => p.salary >= f.desde && p.salary <= f.hasta)
                }
            ).ToList();

            return reporte;
        }
        private void btnImprimirPersonas_Click(object sender, EventArgs e)
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
            System.Drawing.Image im = WinFormsReportes.Properties.Resources.logo;
            var logo = StaticsFront.ImageToByteArray(im);

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
                    .Element(ComposeHeader(logo, "","Informe de personas"));

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
                                columns.RelativeColumn(90);
                                columns.ConstantColumn(90);
                                columns.ConstantColumn(90);

                            });

                            // Encabezados de la tabla
                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("Id").Bold();
                                header.Cell().Element(CellStyle).Text("Nombre").Bold();
                                header.Cell().Element(CellStyle).Text("Edad").Bold();
                                header.Cell().Element(CellStyle).Text("Salario").Bold();
                                header.Cell().Element(CellStyle).Text("Nacimiento").Bold();
                            });

                            // Rellenar datos de la tabla
                            foreach (var item in data)
                            {

                                table.Cell().Element(CellStyle).Text(item.id);
                                table.Cell().Element(CellStyle).Text(item.name);
                                table.Cell().Element(CellStyle).Text(item.age);
                                table.Cell().Element(CellStyle).Text(item.salary);
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

            if (MessageBox.Show("El reporte se genero en " + fileName + ". Desea abrirlo?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //obtengo la lista reporte a partir de la lista de personas
            int desde =Convert.ToInt16(txtEdad1.Text);
            int hasta = Convert.ToInt16(txtEdad2.Text);

            _listaPersonas = _listaPersonas.Where(c => c.age >= desde && c.age <= hasta).ToList<Persona>();

            reporte = ObtenerReportePorFranjaSalario(_listaPersonas);

            bindingSource2.DataSource = reporte;

        }      
        private void btnImprimirEdades_Click(object sender, EventArgs e)
        {
            btnGenerar_Click(null, null);

            reporte = ObtenerReportePorFranjaSalario(_listaPersonas);

            //Metodo muy importante, aca se genera la imagen (barras/torta) que se muestra en el reporte
            string pathImagenReporte = "";
            if (radioButton1.Checked)
                pathImagenReporte = CrearImagenBarras(reporte);
            else
                pathImagenReporte = CrearImagenTorta(reporte);

            string fileName = "c:\\Reportes\\" + StaticsFront.GenerarNombreArchivoUnico("ReporteIngresosFranjas", "PDF");
            string filtrosAplicados = "\nFiltros: ";  

            filtrosAplicados += "\nEdad Desde: " + (txtEdad1.Text);
            filtrosAplicados += "\nEdad Hasta: " + (txtEdad2.Text);

            //if (!String.IsNullOrWhiteSpace(ordenadoPor))
            //    filtrosAplicados += "\nOrdenado por: " + ordenadoPor;

            // Datos de ejemplo para la tabla
            var data = reporte;
            // Ruta de la imagen para el encabezado

            System.Drawing.Image im = WinFormsReportes.Properties.Resources.logo;
            var logo = StaticsFront.ImageToByteArray(im);

            // Crear el documento PDF
            Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(8))
                    ;

                    page.Header()
                    .Background(Colors.White) // Asegurar que el fondo del encabezado sea blanco
                    .Padding(5)
                    .Element(ComposeHeader(logo, filtrosAplicados,"Informe de salarios"));

                    page.Content()
                   .PaddingVertical(1, Unit.Centimetre)
                   .Column(column =>
                   {
                       // Agregar una imagen
                       column.Item().Image(pathImagenReporte); // Especifica la ruta de tu imagen aquí

                       // Otros elementos de contenido
                       // column.Item().Text("Este es un texto adicional después de la imagen.");
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

            var mes = MessageBox.Show("El reporte se genero en " + fileName + ". Desea abrirlo?", "", MessageBoxButtons.YesNo);

            if (mes == DialogResult.Yes)
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
        public string CrearImagenBarras(List<ReporteSalario> _datos)
        {
            var ejeX = _datos.Select(d => (double)d.id).ToArray(); // edad en X        
            var cantidades = _datos.Select(d => (double)d.cantidad).ToArray(); // Cantidades en Y
            
            var plt = new Plot();
            plt.AddBar(cantidades, ejeX);
            //plt.AddPie(cantidades);//, horas); otro tipo de grafico

            //plt.Title("Reporte de Ingresos por Hora");
            plt.XLabel("Franja Salarios");
            plt.YLabel("Cantidad");

            // Crear etiquetas para el eje X
            string[] etiquetas = ejeX.Select(h => $"{reporte.FirstOrDefault(c=>c.id == h).franjaSalario} USD").ToArray(); // Crear etiquetas 

            // Establecer etiquetas en el eje X usando Ticks
            plt.XTicks(ejeX, etiquetas); // Este método puede no estar disponible en tu versión
                                          //plt.XTicks(horas.Select(h => (double)h).ToArray(), etiquetas);
                                          //plt.XTicks(horas.Select(h => (double)h).ToArray(), etiquetas);

      
            // Ajustar el eje Y para mostrar solo enteros
            var maxCantidad = (int)cantidades.Max(); // Obtener el valor máximo para el eje Y

            int intervaloTicks = 1; // Cambia este valor según lo necesites

            switch (maxCantidad)
            {
                case < 10:
                    intervaloTicks = 1; // Cambia este valor según lo necesites
                    break;
                case < 50:
                    intervaloTicks = 2; // Cambia este valor según lo necesites
                    break;
                default:
                    intervaloTicks = 5; // Cambia este valor según lo necesites
                    break;
            }



            // Generar los valores de los ticks
            double[] yTicksValues = Enumerable.Range(0, maxCantidad / intervaloTicks + 1)
                                              .Select(i => (double)(i * intervaloTicks))
                                              .ToArray();

            // Crear las etiquetas correspondientes
            string[] yTicksLabels = yTicksValues.Select(v => v.ToString("0")).ToArray();

            // Establecer ticks en el eje Y
            plt.YTicks(yTicksValues, yTicksLabels); // Asignar ticks de Y

            var archivo = StaticsFront.GenerarNombreArchivoUnico("ReporteSalariosBarra", "jpeg");

            string imagePath = @"C:\Reportes\" + archivo;
            plt.SaveFig(imagePath, 800, 600);

            return imagePath;
        }
        public string CrearImagenTorta(List<ReporteSalario> _datos)
        {
            var ejeX = _datos.Select(d => (double)d.id).ToArray(); // edad en X        
            var cantidades = _datos.Select(d => (double)d.cantidad).ToArray(); // Cantidades en Y

            var plt = new Plot();


            string[] sliceLabels = _datos
            //.Select(d => $"{d.Mes}\n({(d.Total / _datos.Sum(x => x.Total) * 100):N1}%)")  // Nombre del mes y porcentaje
            .Select(d => $"{d.cantidad}")  // Nombre del mes y porcentaje
            .ToArray();

            // Crear etiquetas para el eje X
            string[] etiquetas = ejeX.Select(h => $"{reporte.FirstOrDefault(c => c.id == h).franjaSalario} USD").ToArray(); // Crear etiquetas 


            // Crear el gráfico de torta
            var pie = plt.AddPie(cantidades);
            pie.SliceLabels = sliceLabels;
            //pie.ShowValues = true;
            pie.ShowLabels = true;
            pie.ShowPercentages = true;
            pie.DonutSize = .3;  // Para hacer una dona

            // Configurar la leyenda en la parte inferior central
            //var legend = plt.Legend();
            //legend.ShadowOffsetX = -10;

            pie.LegendLabels = etiquetas;
            var legend = plt.Legend();
            legend.ShadowOffsetX = -10;

            var archivo = StaticsFront.GenerarNombreArchivoUnico("ReporteSalariosTorta", "jpeg");

            string imagePath = @"C:\Reportes\" + archivo;
            plt.SaveFig(imagePath, 800, 600);

            return imagePath;
        }
        static Action<IContainer> ComposeHeader(byte[] imagePath, string filtrosAplicados, string titulo)
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
                            .Text(titulo)
                            .SemiBold().FontSize(15).FontColor(Colors.Blue.Medium);

                        row.ConstantItem(100)
                           .AlignRight()
                           .Padding(0)
                           .Background(Colors.White)
                           .Text("Fecha: " + DateTime.Now.ToString() + filtrosAplicados)
                           .SemiBold().FontSize(8).FontColor(Colors.Grey.Medium);

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
           
    }
}
