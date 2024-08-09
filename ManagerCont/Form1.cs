﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManagerCont;

namespace ManagerCont
{
    public partial class Form1 : Form
    {

        private List<DataGridViewCell> searchResults = new List<DataGridViewCell>();
        private int currentSearchIndex = -1;
        private conexion _conexion;

        public Form1()
        {
            InitializeComponent();
            /*  _conexion = new conexion();
              ProbarConexion();*/

            comboBox1.Items.Add("Seleccione un archivo");
            comboBox1.Items.Add("CATAUX");
            comboBox1.Items.Add("CATMAY");
            comboBox1.Items.Add("DATOS");
            comboBox1.Items.Add("OPERACIONES");
            comboBox1.Enabled = false; // Deshabilitar comboBox1 inicialmente

            comboBox2.Items.Add("01");
            comboBox2.Items.Add("02");
            comboBox2.Items.Add("03");
            comboBox2.Items.Add("04");
            comboBox2.Items.Add("05");
            comboBox2.Items.Add("06");
            comboBox2.Items.Add("07");
            comboBox2.Items.Add("08");
            comboBox2.Items.Add("09");
            comboBox2.Items.Add("10");
            comboBox2.Items.Add("11");
            comboBox2.Items.Add("12");
            comboBox2.Enabled = false; // Deshabilitar comboBox2 inicialmente

            comboBox3.Items.Add("EPE");
            comboBox3.Items.Add("CON");
            comboBox3.Items.Add("ING");
            comboBox3.Items.Add("SUP");
            comboBox3.Items.Add("CONS");
            comboBox3.Items.Add("COR");
            comboBox3.Items.Add("SAC");
            comboBox3.Items.Add("GEO");

            comboBox3.SelectedIndexChanged += ComboBox3_SelectedIndexChanged; // Agregar manejador de evento
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged; // Agregar manejador de evento

            button7.Click += button7_Click; // Agregar manejador de evento para button7

            // Inicialmente ocultar todos los componentes que quieres controlar por menú
            dataGridView1.Visible = true;
            button1.Visible = false;
            button3.Visible = false;
            button8.Visible = false;
            button7.Visible = false;
            label1.Visible = false;
            label2.Visible = true;
            button2.Visible = false;
            comboBox3.Visible = false;
            comboBox2.Visible = false;
            comboBox1.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            textBox1.Visible = true;
            dataGridView2.Visible = true;
            button6.Visible = true;
            button9.Visible = false;
            label3.Visible = false;

            this.button6.Click += new System.EventHandler(this.button6_Click);
            dataGridView1.KeyDown += new KeyEventHandler(dataGridView1_KeyDown);


        }



        private void rANDOMToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            // Mostrar componentes para la opción "Random"
            dataGridView1.Visible = true;
            button8.Visible = false;
            button7.Visible = false;
            button6.Visible = true;
            label1.Visible = true;
            button1.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            textBox1.Visible = true;
            dataGridView2.Visible = true;



            // Ocultar otros componentes
            button3.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            comboBox3.Visible = false;
            comboBox2.Visible = false;
            comboBox1.Visible = false;
            label3.Visible = false;

        }

        private void cSVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear(); // Limpiar encabezados de columnas también


            // Mostrar componentes para la opción "CSV"
            label2.Visible = false;
            dataGridView1.Visible = true;
            button2.Visible = true;
            comboBox3.Visible = true;
            comboBox2.Visible = true;
            comboBox1.Visible = true;
            button6.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            textBox1.Visible = true;
            dataGridView2.Visible = true;
            label3.Visible = true;


            // Ocultar otros componentes
            button1.Visible = false;
            button8.Visible = false;
            button7.Visible = false;
            label1.Visible = true;
        }


        /*     private void ProbarConexion()
             {
                 try
                 {
                     _conexion.TestConnection();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                 }
             }*/

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilitar comboBox2 si se selecciona un elemento en comboBox3, de lo contrario, deshabilitarlo
            comboBox2.Enabled = comboBox3.SelectedIndex != -1;
            // Llamar a método para actualizar el estado de comboBox1
            ActualizarEstadoComboBox1();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llamar a método para actualizar el estado de comboBox1
            ActualizarEstadoComboBox1();
        }

        private void ActualizarEstadoComboBox1()
        {
            // Habilitar comboBox1 si ambos comboBox2 y comboBox3 tienen una selección, de lo contrario, deshabilitarlo
            comboBox1.Enabled = comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string archivosPath = label3.Text; // Ruta literal al directorio donde están los archivos
                string selectedFilePath = string.Empty;

                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Seleccione un archivo":
                        label1.Text = string.Empty; // Limpiar el texto del label si no se selecciona un archivo válido
                        break;
                    case "CATAUX":

                        selectedFilePath = Path.Combine(archivosPath, "CATAUX.csv");
                        CargarArchivoCSV(selectedFilePath);
                        label1.Text = "CATAUX"; // Asignar la ruta completa al label
                        break;
                    case "CATMAY":
                        selectedFilePath = Path.Combine(archivosPath, "CATMAY.csv");
                        CargarArchivoCSV(selectedFilePath);
                        label1.Text = "CATMAY"; // Asignar la ruta completa al label
                        break;
                    case "DATOS":
                        selectedFilePath = Path.Combine(archivosPath, "DATOS.csv");
                        CargarArchivoCSV(selectedFilePath);
                        label1.Text = "DATOS"; // Asignar la ruta completa al label
                        break;
                    case "OPERACIONES":
                        if (comboBox2.SelectedIndex == -1 || comboBox2.SelectedItem.ToString() == "Valor Predeterminado")
                        {
                            MessageBox.Show("Debes elegir un mes primero para esta operación");
                            comboBox1.SelectedIndex = 0;
                        }
                        else
                        {
                            selectedFilePath = Path.Combine(archivosPath, comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString() + ".csv");
                            CargarArchivoCSV(selectedFilePath);
                            label1.Text = comboBox3.SelectedItem.ToString() + comboBox2.SelectedItem.ToString(); // Asignar la ruta completa al label
                        }
                        break;
                    default:
                        MessageBox.Show("Selección no válida");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error: " + ex.Message);
            }
        }


        private void CargarArchivoCSV(string archivoPath)
        {
            try
            {
                if (!File.Exists(archivoPath))
                {
                    MessageBox.Show("El archivo no existe en la ruta especificada.");
                    return;
                }

                // Leer todas las líneas del archivo CSV
                string[] lines = File.ReadAllLines(archivoPath);

                // Crear un DataTable para almacenar los datos del archivo CSV
                DataTable dt = new DataTable();

                // Si hay líneas, asumimos que la primera línea contiene los nombres de las columnas
                if (lines.Length > 0)
                {
                    // Dividir la primera línea por ';' para obtener los nombres de las columnas
                    string[] headers = lines[0].Split(';');

                    // Agregar las columnas al DataTable
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }

                    // Leer las filas restantes y agregarlas al DataTable
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] data = lines[i].Split(';');
                        dt.Rows.Add(data);
                    }
                }

                // Asignar el DataTable como origen de datos del DataGridView
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Verifica que se hizo clic en una celda válida
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string archivosPath = @"C:\Users\david.albino\Desktop\CSVs\"; // Ruta literal al directorio donde están los archivos
                string archivoPath = Path.Combine(archivosPath, comboBox1.SelectedItem.ToString() + ".csv"); // Obtener ruta completa del archivo

                // Obtener los datos actuales del DataGridView
                DataTable dt = (DataTable)dataGridView1.DataSource;

                // Verificar que el DataGridView tenga datos y que el archivo exista
                if (dt != null && File.Exists(archivoPath))
                {
                    // Crear una lista de líneas para escribir en el archivo CSV
                    List<string> lines = new List<string>();

                    // Agregar encabezados como primera línea
                    string headers = string.Join(";", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                    lines.Add(headers);

                    // Agregar cada fila del DataTable como una línea en el archivo CSV
                    foreach (DataRow row in dt.Rows)
                    {
                        string line = string.Join(";", row.ItemArray);
                        lines.Add(line);
                    }

                    // Escribir todas las líneas al archivo CSV
                    File.WriteAllLines(archivoPath, lines);

                    MessageBox.Show("Archivo actualizado correctamente.");
                }
                else
                {
                    MessageBox.Show("No hay datos para guardar o el archivo no existe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el archivo: " + ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InterpretarYMostrarOperaciones(string linea)
        {
            try
            {
                // Limpiar DataGridView antes de cargar nuevos datos
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                // Configurar columnas del DataGridView
                DataGridViewColumn ctaColumn = new DataGridViewTextBoxColumn { Name = "CTA", HeaderText = "CTA" };
                DataGridViewColumn descrColumn = new DataGridViewTextBoxColumn { Name = "descr", HeaderText = "descr" };
                DataGridViewColumn feColumn = new DataGridViewTextBoxColumn { Name = "fe", HeaderText = "fe" };
                DataGridViewColumn impteColumn = new DataGridViewTextBoxColumn { Name = "impte", HeaderText = "impte" };
                DataGridViewColumn indentiColumn = new DataGridViewTextBoxColumn { Name = "indenti", HeaderText = "indenti" };
                DataGridViewColumn realColumn = new DataGridViewTextBoxColumn { Name = "real", HeaderText = "real" };

                // Configurar todas las columnas para que no sean ordenables
                ctaColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                descrColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                feColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                impteColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                indentiColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                realColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Agregar columnas al DataGridView
                dataGridView2.Columns.Add(ctaColumn);
                dataGridView2.Columns.Add(descrColumn);
                dataGridView2.Columns.Add(feColumn);
                dataGridView2.Columns.Add(impteColumn);
                dataGridView2.Columns.Add(indentiColumn);
                dataGridView2.Columns.Add(realColumn);

                Font newFont = new Font("Arial", 7, FontStyle.Bold); // Cambia "Arial" y otros parámetros según tus preferencias
                dataGridView2.DefaultCellStyle.Font = newFont;

                int index = 0;
                int expectedNumber = 1; // Número ascendente esperado
                while (index + 64 <= linea.Length)
                {
                    // Interpretar cada campo según los índices especificados
                    string CTA = linea.Substring(index, 6).Trim().PadRight(6);
                    string descr = linea.Substring(index + 6, 30).Trim().PadRight(30);
                    string fe = linea.Substring(index + 36, 2).Trim().PadRight(2);
                    string impte = linea.Substring(index + 38, 16).Trim().PadRight(16);
                    string indenti = linea.Substring(index + 54, 1).Trim().PadRight(1);
                    string real = linea.Substring(index + 55, 9).Trim().PadRight(9);

                    // Agregar fila al DataGridView
                    int rowIndex = dataGridView2.Rows.Add(CTA, descr, fe, impte, indenti, real);

                    // Comprobar si el valor en CTA es el número ascendente esperado
                    if (int.TryParse(CTA.Trim(), out int ctaNumber) && ctaNumber == expectedNumber)
                    {
                        dataGridView2.Rows[rowIndex].Cells["CTA"].Style.BackColor = Color.Yellow;
                        expectedNumber++; // Incrementar el número esperado
                    }

                    // Avanzar al siguiente conjunto de datos
                    index += 64;
                }

                // Ajustar automáticamente el tamaño de las columnas
                dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // Asignar números crecientes al encabezado de filas
                for (int u = 0; u < dataGridView2.Rows.Count; u++)
                {
                    dataGridView2.Rows[u].HeaderCell.Value = (u + 1).ToString();
                }

                // Ajustar el ancho del encabezado de fila para que se muestre correctamente
                dataGridView2.RowHeadersWidth = 65;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al interpretar y mostrar los datos: " + ex.Message);
            }
        }

        private void InterpretarYMostrarCatmay(string linea)
        {
            try
            {
                // Limpiar DataGridView antes de cargar nuevos datos
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                // Configurar columnas del DataGridView
                DataGridViewColumn cuentaColumn = new DataGridViewTextBoxColumn { Name = "Cuenta", HeaderText = "Cuenta" };
                DataGridViewColumn nombreColumn = new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre" };
                DataGridViewColumn saldoColumn = new DataGridViewTextBoxColumn { Name = "Saldo", HeaderText = "Saldo" };
                DataGridViewColumn rangoInfColumn = new DataGridViewTextBoxColumn { Name = "Rango_Inf", HeaderText = "Rango_Inf" };
                DataGridViewColumn rangoSupColumn = new DataGridViewTextBoxColumn { Name = "Rango_Sup", HeaderText = "Rango_Sup" };

                // Configurar todas las columnas para que no sean ordenables
                cuentaColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                nombreColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                saldoColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                rangoInfColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                rangoSupColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Agregar columnas al DataGridView
                dataGridView2.Columns.Add(cuentaColumn);
                dataGridView2.Columns.Add(nombreColumn);
                dataGridView2.Columns.Add(saldoColumn);
                dataGridView2.Columns.Add(rangoInfColumn);
                dataGridView2.Columns.Add(rangoSupColumn);

                Font newFont = new Font("Arial", 7, FontStyle.Bold); // Cambia "Arial" y otros parámetros según tus preferencias
                dataGridView2.DefaultCellStyle.Font = newFont;

                int index = 0;
                while (index + 64 <= linea.Length)
                {
                    // Interpretar cada campo según los índices especificados
                    string Cuenta = linea.Substring(index, 6).Trim().PadRight(6);
                    string Nombre = linea.Substring(index + 6, 32).Trim().PadRight(32);
                    string Saldo = linea.Substring(index + 38, 16).Trim().PadRight(16);
                    string Rango_Inf = linea.Substring(index + 54, 5).Trim().PadRight(5);
                    string Rango_Sup = linea.Substring(index + 59, 5).Trim().PadRight(5);

                    // Agregar fila al DataGridView
                    dataGridView2.Rows.Add(Cuenta, Nombre, Saldo, Rango_Inf, Rango_Sup);

                    // Avanzar al siguiente conjunto de datos
                    index += 64;
                }

                // Ajustar automáticamente el tamaño de las columnas
                dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // Asignar números crecientes al encabezado de filas
                for (int u = 0; u < dataGridView2.Rows.Count; u++)
                {
                    dataGridView2.Rows[u].HeaderCell.Value = (u + 1).ToString();
                }

                // Ajustar el ancho del encabezado de fila para que se muestre correctamente
                dataGridView2.RowHeadersWidth = 65;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al interpretar y mostrar los datos: " + ex.Message);
            }
        }


        private void InterpretarYMostrarDatos(string linea)
        {
            try
            {
                // Limpiar DataGridView antes de cargar nuevos datos
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                // Configurar columnas del DataGridView
                DataGridViewColumn d1Column = new DataGridViewTextBoxColumn { Name = "D1", HeaderText = "D1" };
                DataGridViewColumn d2Column = new DataGridViewTextBoxColumn { Name = "D2", HeaderText = "D2" };
                DataGridViewColumn d3Column = new DataGridViewTextBoxColumn { Name = "D3", HeaderText = "D3" };
                DataGridViewColumn noArchColumn = new DataGridViewTextBoxColumn { Name = "No_arch", HeaderText = "No_arch" };
                DataGridViewColumn aoColumn = new DataGridViewTextBoxColumn { Name = "a_o", HeaderText = "a_o" };
                DataGridViewColumn others1Column = new DataGridViewTextBoxColumn { Name = "others1", HeaderText = "others1" };
                DataGridViewColumn ultimaPol1Column = new DataGridViewTextBoxColumn { Name = "ultimaPol1", HeaderText = "ultimaPol1" };
                DataGridViewColumn ultimaOperacionRegColumn = new DataGridViewTextBoxColumn { Name = "ultimaOperacionReg", HeaderText = "ultimaOperacionReg" };
                DataGridViewColumn othersColumn = new DataGridViewTextBoxColumn { Name = "others", HeaderText = "others" };

                // Configurar todas las columnas para que no sean ordenables
                d1Column.SortMode = DataGridViewColumnSortMode.NotSortable;
                d2Column.SortMode = DataGridViewColumnSortMode.NotSortable;
                d3Column.SortMode = DataGridViewColumnSortMode.NotSortable;
                noArchColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                aoColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                others1Column.SortMode = DataGridViewColumnSortMode.NotSortable;
                ultimaPol1Column.SortMode = DataGridViewColumnSortMode.NotSortable;
                ultimaOperacionRegColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                othersColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Agregar columnas al DataGridView
                dataGridView2.Columns.Add(d1Column);
                dataGridView2.Columns.Add(d2Column);
                dataGridView2.Columns.Add(d3Column);
                dataGridView2.Columns.Add(noArchColumn);
                dataGridView2.Columns.Add(aoColumn);
                dataGridView2.Columns.Add(others1Column);
                dataGridView2.Columns.Add(ultimaPol1Column);
                dataGridView2.Columns.Add(ultimaOperacionRegColumn);
                dataGridView2.Columns.Add(othersColumn);

                Font newFont = new Font("Arial", 7, FontStyle.Bold); // Cambia "Arial" y otros parámetros según tus preferencias
                dataGridView2.DefaultCellStyle.Font = newFont;

                int index = 0;
                while (index + 236 <= linea.Length)
                {
                    // Interpretar cada campo según los índices especificados
                    string D1 = linea.Substring(index, 64).Trim().PadRight(64);
                    string D2 = linea.Substring(index + 64, 60).Trim().PadRight(60);
                    string D3 = linea.Substring(index + 124, 45).Trim().PadRight(45);
                    string No_arch = linea.Substring(index + 169, 15).Trim().PadRight(15);
                    string a_o = linea.Substring(index + 184, 5).Trim().PadRight(5);
                    string Others1 = linea.Substring(index + 189, 25).Trim().PadRight(25);
                    string ultimaPol1 = linea.Substring(index + 214, 5).Trim().PadRight(5);
                    string ultimaOperacionReg = linea.Substring(index + 219, 6).Trim().PadRight(6);
                    string others = linea.Substring(index + 225, 11).Trim().PadRight(11);

                    // Agregar fila al DataGridView
                    dataGridView2.Rows.Add(D1, D2, D3, No_arch, a_o, Others1, ultimaPol1, ultimaOperacionReg, others);

                    // Avanzar al siguiente conjunto de datos
                    index += 236;
                }

                dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                for (int u = 0; u < dataGridView1.Rows.Count; u++)
                {
                    dataGridView1.Rows[u].HeaderCell.Value = (u + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al interpretar y mostrar los datos: " + ex.Message);
            }
        }
        private void InterpretarYMostrarCataux(string linea)
        {
            try
            {
                // Limpiar DataGridView antes de cargar nuevos datos
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                // Configurar columnas del DataGridView
                DataGridViewColumn cuentaColumn = new DataGridViewTextBoxColumn { Name = "Cuenta", HeaderText = "Cuenta" };
                DataGridViewColumn nombreColumn = new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre" };
                DataGridViewColumn saldoColumn = new DataGridViewTextBoxColumn { Name = "Saldo", HeaderText = "Saldo" };
                DataGridViewColumn rangoInfColumn = new DataGridViewTextBoxColumn { Name = "Rango_Inf", HeaderText = "Rango_Inf" };
                DataGridViewColumn rangoSupColumn = new DataGridViewTextBoxColumn { Name = "Rango_Sup", HeaderText = "Rango_Sup" };

                // Configurar todas las columnas para que no sean ordenables
                cuentaColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                nombreColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                saldoColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                rangoInfColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                rangoSupColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Agregar columnas al DataGridView
                dataGridView2.Columns.Add(cuentaColumn);
                dataGridView2.Columns.Add(nombreColumn);
                dataGridView2.Columns.Add(saldoColumn);
                dataGridView2.Columns.Add(rangoInfColumn);
                dataGridView2.Columns.Add(rangoSupColumn);

                Font newFont = new Font("Arial", 7, FontStyle.Bold); // Cambia "Arial" y otros parámetros según tus preferencias
                dataGridView2.DefaultCellStyle.Font = newFont;

                int index = 0;
                while (index + 64 <= linea.Length)
                {
                    // Interpretar cada campo según los índices especificados
                    string Cuenta = linea.Substring(index, 6).Trim().PadRight(6);
                    string Nombre = linea.Substring(index + 6, 32).Trim().PadRight(32);
                    string Saldo = linea.Substring(index + 38, 16).Trim().PadRight(16);
                    string Rango_Inf = linea.Substring(index + 54, 5).Trim().PadRight(5);
                    string Rango_Sup = linea.Substring(index + 59, 5).Trim().PadRight(5);

                    // Agregar fila al DataGridView
                    dataGridView2.Rows.Add(Cuenta, Nombre, Saldo, Rango_Inf, Rango_Sup);

                    // Avanzar al siguiente conjunto de datos
                    index += 64;
                }

                // Ajustar automáticamente el tamaño de las columnas
                dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // Asignar números crecientes al encabezado de filas
                for (int u = 0; u < dataGridView2.Rows.Count; u++)
                {
                    dataGridView2.Rows[u].HeaderCell.Value = (u + 1).ToString();
                }

                // Ajustar el ancho del encabezado de fila para que se muestre correctamente
                dataGridView2.RowHeadersWidth = 65;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al interpretar y mostrar los datos: " + ex.Message);
            }
        }


        // Evento para manejar el botón que carga y muestra los datos en el DataGridView
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Archivos de Texto|*"; // Filtro para archivos de texto

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog1.FileName;

                    // Extraer el nombre del archivo sin la extensión
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                    // Asignar el nombre al texto del label (label1)
                    label1.Text = fileNameWithoutExtension;

                    // Leer la línea completa del archivo
                    string lineaCompleta = File.ReadAllText(filePath);

                    // Aquí debe de llevar una instrucción dependiendo el label
                    if (fileNameWithoutExtension.StartsWith("CATMAY", StringComparison.OrdinalIgnoreCase))
                    {
                        InterpretarYMostrarCatmay(lineaCompleta);
                    }
                    else if (fileNameWithoutExtension.StartsWith("CATAUX", StringComparison.OrdinalIgnoreCase))
                    {
                        InterpretarYMostrarCataux(lineaCompleta);
                    }
                    else if (fileNameWithoutExtension.Equals("DATOS", StringComparison.OrdinalIgnoreCase))
                    {
                        InterpretarYMostrarDatos(lineaCompleta);
                    }
                    else if (fileNameWithoutExtension.StartsWith("SAC", StringComparison.OrdinalIgnoreCase) ||

                             fileNameWithoutExtension.StartsWith("COR", StringComparison.OrdinalIgnoreCase) ||
                             fileNameWithoutExtension.StartsWith("EPE", StringComparison.OrdinalIgnoreCase) ||
                             fileNameWithoutExtension.StartsWith("ING", StringComparison.OrdinalIgnoreCase) ||
                             fileNameWithoutExtension.StartsWith("CON", StringComparison.OrdinalIgnoreCase) ||
                             fileNameWithoutExtension.StartsWith("GEO", StringComparison.OrdinalIgnoreCase) ||
                             fileNameWithoutExtension.StartsWith("SUP", StringComparison.OrdinalIgnoreCase))
                    {
                        InterpretarYMostrarOperaciones(lineaCompleta);
                    }
                    else
                    {
                        MessageBox.Show("Archivo no reconocido.");
                    }
                    button1_Click(sender, e);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el archivo: " + ex.Message);
            }
        }


        // Funciónes para guardar los datos con la estructura especificada
        private void GuardarOpers(int CTA_Length, int descr_Length, int fe_Length, int impte_Length, int indenti_Length, int real_Length)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Archivo de Texto|*"; // Filtro para archivos de texto con extensión .txt
                saveFileDialog1.Title = "Guardar datoS";
                saveFileDialog1.FileName = "OPER"; // Nombre base del archivo

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;

                    // Crear un StringBuilder para construir el contenido del archivo
                    StringBuilder sb = new StringBuilder();

                    // Construir el contenido del archivo a partir de los datos del DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // Verificar si la fila no está vacía
                        if (!row.IsNewRow)
                        {
                            // Obtener y formatear los valores de las celdas
                            string CTA = Convert.ToString(row.Cells["CTA"].Value).PadRight(CTA_Length).Substring(0, CTA_Length);
                            string descr = Convert.ToString(row.Cells["descr"].Value).PadRight(descr_Length).Substring(0, descr_Length);
                            string fe = Convert.ToString(row.Cells["fe"].Value).PadRight(fe_Length).Substring(0, fe_Length);
                            string impte = Convert.ToString(row.Cells["impte"].Value).PadRight(impte_Length).Substring(0, impte_Length);
                            string indenti = Convert.ToString(row.Cells["indenti"].Value).PadRight(indenti_Length).Substring(0, indenti_Length);
                            string real = Convert.ToString(row.Cells["real"].Value).PadRight(real_Length).Substring(0, real_Length);

                            // Combinar los campos en una línea y agregar al StringBuilder
                            string line = $"{CTA}{descr}{fe}{impte}{indenti}{real}";
                            sb.Append(line); // Usar Append en lugar de AppendLine para evitar saltos de línea adicionales
                        }
                    }
                    Font newFont = new Font("Arial", 7, FontStyle.Bold); // Cambia "Arial" y otros parámetros según tus preferencias
                    dataGridView1.DefaultCellStyle.Font = newFont;
                    // Escribir el contenido del StringBuilder en el archivo de texto
                    File.WriteAllText(filePath, sb.ToString());

                    MessageBox.Show("Datos guardados correctamente en: " + filePath, "Guardar datos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarCats(int Cuenta_Length, int Nombre_Length, int Saldo_Length, int Rango_Inf_Length, int Rango_Sup_Length)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Archivo de Texto|*"; // Filtro para archivos de texto con extensión .txt
                saveFileDialog1.Title = "Guardar datos CATMAY en archivo de texto";
                saveFileDialog1.FileName = "datos_catmay"; // Nombre base del archivo

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;

                    // Crear un StringBuilder para construir el contenido del archivo
                    StringBuilder sb = new StringBuilder();

                    // Construir el contenido del archivo a partir de los datos del DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // Verificar si la fila no está vacía
                        if (!row.IsNewRow)
                        {
                            // Obtener y formatear los valores de las celdas según los parámetros proporcionados
                            string Cuenta = Convert.ToString(row.Cells["Cuenta"].Value).PadRight(Cuenta_Length).Substring(0, Cuenta_Length);
                            string Nombre = Convert.ToString(row.Cells["Nombre"].Value).PadRight(Nombre_Length).Substring(0, Nombre_Length);

                            // Obtener el valor de Saldo y quitar puntos si es necesario
                            string SaldoValue = Convert.ToString(row.Cells["Saldo"].Value);
                            SaldoValue = SaldoValue.Replace(".", ""); // Quitar puntos

                            string Saldo = SaldoValue.PadRight(Saldo_Length).Substring(0, Saldo_Length);
                            string Rango_Inf = Convert.ToString(row.Cells["Rango_Inf"].Value).PadRight(Rango_Inf_Length).Substring(0, Rango_Inf_Length);
                            string Rango_Sup = Convert.ToString(row.Cells["Rango_Sup"].Value).PadRight(Rango_Sup_Length).Substring(0, Rango_Sup_Length);

                            // Combinar los campos en una línea y agregar al StringBuilder
                            string line = $"{Cuenta}{Nombre}{Saldo}{Rango_Inf}{Rango_Sup}";
                            sb.Append(line); // Usar Append en lugar de AppendLine para evitar saltos de línea adicionales
                        }
                    }

                    // Escribir el contenido del StringBuilder en el archivo de texto
                    File.WriteAllText(filePath, sb.ToString());

                    MessageBox.Show("Datos CATMAY guardados correctamente en: " + filePath, "Guardar datos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos CATMAY: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GuardarDatos(int D1_Length, int D2_Length, int D3_Length, int No_arch_Length, int a_o_Length, int Others1_Length, int ultimaPol1_Length, int ultimoReg_Length, int others_Length)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Archivo de Texto|*"; // Filtro para archivos de texto con extensión .txt
                saveFileDialog1.Title = "Guardar datos en archivo de texto";
                saveFileDialog1.FileName = "datos_guardados"; // Nombre base del archivo

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;

                    // Crear un StringBuilder para construir el contenido del archivo
                    StringBuilder sb = new StringBuilder();

                    // Construir el contenido del archivo a partir de los datos del DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // Verificar si la fila no está vacía
                        if (!row.IsNewRow)
                        {
                            // Obtener y formatear los valores de las celdas según los parámetros proporcionados
                            string D1 = Convert.ToString(row.Cells["D1"].Value).PadRight(D1_Length).Substring(0, D1_Length);
                            string D2 = Convert.ToString(row.Cells["D2"].Value).PadRight(D2_Length).Substring(0, D2_Length);
                            string D3 = Convert.ToString(row.Cells["D3"].Value).PadRight(D3_Length).Substring(0, D3_Length);
                            string No_arch = Convert.ToString(row.Cells["No_arch"].Value).PadRight(No_arch_Length).Substring(0, No_arch_Length);
                            string a_o = Convert.ToString(row.Cells["a_o"].Value).PadRight(a_o_Length).Substring(0, a_o_Length);
                            string Others1 = Convert.ToString(row.Cells["others1"].Value).PadRight(Others1_Length).Substring(0, Others1_Length);
                            string ultimaPol1 = Convert.ToString(row.Cells["ultimaPol1"].Value).PadRight(ultimaPol1_Length).Substring(0, ultimaPol1_Length);
                            string ultimoReg = Convert.ToString(row.Cells["ultimaOperacionReg"].Value).PadRight(ultimoReg_Length).Substring(0, ultimoReg_Length);
                            string others = Convert.ToString(row.Cells["others"].Value).PadRight(others_Length).Substring(0, others_Length);

                            // Combinar los campos en una línea y agregar al StringBuilder
                            string line = $"{D1}{D2}{D3}{No_arch}{a_o}{Others1}{ultimaPol1}{ultimoReg}{others}";
                            sb.Append(line); // Usar Append en lugar de AppendLine para evitar saltos de línea adicionales
                        }
                    }

                    // Escribir el contenido del StringBuilder en el archivo de texto
                    File.WriteAllText(filePath, sb.ToString());

                    MessageBox.Show("Datos guardados correctamente en: " + filePath, "Guardar datos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RANDOMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Limpiar DataGridView antes de mostrar nuevos datos
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear(); // Limpiar encabezados de columnas también

            // Mostrar componentes para la opción "Random"
            dataGridView1.Visible = true;
            button8.Visible = false;
            button7.Visible = false;
            label1.Visible = true;
            button1.Visible = false;


            // Ocultar otros componentes
            label2.Visible = false;
            button2.Visible = false;
            comboBox3.Visible = false;
            comboBox2.Visible = false;
            comboBox1.Visible = false;

            // Identificar y aplicar formato a las columnas con solo números
        }

        private void CSVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Limpiar DataGridView antes de mostrar nuevos datos
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear(); // Limpiar encabezados de columnas también

            // Mostrar componentes para la opción "CSV"
            dataGridView1.Visible = true;
            button2.Visible = true;
            comboBox3.Visible = true;
            comboBox2.Visible = true;
            comboBox1.Visible = true;
            label1.Visible = true;


            // Ocultar otros componentes
            button8.Visible = false;
            button7.Visible = false;
            label2.Visible = false;


            // Identificar y aplicar formato a las columnas con solo números
        }


        private bool IsNumericColumn(DataGridView dgv, int columnIndex)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[columnIndex].Value != null &&
                    !double.TryParse(row.Cells[columnIndex].Value.ToString(), out _))
                {
                    return false;
                }
            }
            return true;
        }

        private void FormatearColumna(DataGridView grid, int columnaIndex, string formato)
        {
            if (columnaIndex >= 0 && columnaIndex < grid.Columns.Count)
            {
                grid.Columns[columnaIndex].DefaultCellStyle.Format = formato;
                grid.Columns[columnaIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                MessageBox.Show($"El índice de columna {columnaIndex} está fuera de los límites del DataGridView.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string label1Content = label1.Text.ToUpper(); // Obtener el contenido del label 1 y convertirlo a mayúsculas

                if (label1Content.Contains("DATOS"))
                {
                    // Llamar a la función GuardarDatos con las longitudes específicas
                    GuardarDatos(64, 60, 45, 15, 5, 25, 5, 6, 11);
                }
                else if (label1Content.Contains("CATAUX") || label1Content.Contains("CATMAY"))
                {
                    // Llamar a la función GuardarCats con las longitudes específicas
                    GuardarCats(6, 32, 16, 5, 5);
                    // Formatear y alinear la columna en el índice 2
                }
                else if (label1Content.StartsWith("SAC") || label1Content.StartsWith("COR") || label1Content.StartsWith("SUP"))
                {
                    // Determinar qué función llamar basado en el nombre del archivo sin extensión
                    if (label1Content.StartsWith("SAC"))
                    {
                        // Llamar a la función GuardarOpers con las longitudes específicas para SAC
                        GuardarOpers(6, 30, 2, 16, 1, 9);
                    }
                    else if (label1Content.StartsWith("COR"))
                    {
                        // Llamar a la función GuardarOpers con las longitudes específicas para COR
                        GuardarOpers(6, 30, 2, 16, 1, 9);
                    }
                    else if (label1Content.StartsWith("SUP"))
                    {
                        // Llamar a la función GuardarOpers con las longitudes específicas para SUP
                        GuardarOpers(6, 30, 2, 16, 1, 9);
                    }
                    else
                    {
                        MessageBox.Show("Nombre de archivo no reconocido para guardar datos.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de archivo no reconocido para guardar datos.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el valor del label1
                string label1Value = label1.Text;

                // Determinar la columna a utilizar según el valor de label1
                int columnIndex;
                if (label1Value == "CATAUX" || label1Value == "CATMAY")
                {
                    // Usar la columna "Saldo"
                    if (!dataGridView2.Columns.Contains("Saldo"))
                    {
                        MessageBox.Show("La columna 'Saldo' no existe en el DataGridView.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    columnIndex = dataGridView2.Columns["Saldo"].Index;
                }
                else if (label1Value.StartsWith("SAC") || label1Value.StartsWith("COR") || label1Value.StartsWith("EPE"))
                {
                    // Usar la columna "impte"
                    if (!dataGridView2.Columns.Contains("impte"))
                    {
                        MessageBox.Show("La columna 'impte' no existe en el DataGridView.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    columnIndex = dataGridView2.Columns["impte"].Index;
                }
                else if (label1Value.StartsWith("DAT"))
                {
                    // Usar la columna "impte"
                    if (!dataGridView2.Columns.Contains("others"))
                    {
                        MessageBox.Show("Datos");
                        return;
                    }
                    columnIndex = dataGridView2.Columns["others"].Index;
                }
                else
                {
                    MessageBox.Show("No se puede determinar la columna adecuada para el valor de label1: " + label1Value, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Convertir los valores de la columna a tipo double y formatear
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[columnIndex].Value != null)
                    {
                        string cellValue = row.Cells[columnIndex].Value.ToString().Trim();

                        // Reemplazar solo las comas que no sean parte de números decimales
                        if (cellValue.Contains(","))
                        {
                            // Comprobar si la coma es un separador decimal y no un separador de miles
                            if (cellValue.Count(c => c == ',') == 1 && cellValue.IndexOf(',') == cellValue.Length - 3)
                            {
                                // Es un número decimal con coma, reemplazar comas por puntos
                                cellValue = cellValue.Replace(",", ".");
                            }
                            else
                            {
                                // Es un número con separador de miles, eliminar comas
                                cellValue = cellValue.Replace(",", "");
                            }
                        }

                        if (double.TryParse(cellValue, NumberStyles.Number, CultureInfo.InvariantCulture, out double value))
                        {
                            row.Cells[columnIndex].Value = value;
                        }
                    }
                }

                // Aplicar el formato y alineación
                dataGridView2.Columns[columnIndex].DefaultCellStyle.Format = "#,##0.00";
                dataGridView2.Columns[columnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al formatear la columna según el valor de label1: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el valor seleccionado del ComboBox
                string selectedValue = comboBox1.SelectedItem?.ToString();

                // Determinar la columna a utilizar según el valor seleccionado del ComboBox
                int columnIndex;
                if (selectedValue == "CATAUX" || selectedValue == "CATMAY")
                {
                    // Usar la columna "B3"
                    if (!dataGridView1.Columns.Contains("B3"))
                    {
                        MessageBox.Show("La columna 'B3' no existe en el DataGridView.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    columnIndex = dataGridView1.Columns["B3"].Index;
                }
                else if (selectedValue != null && (selectedValue.StartsWith("SAC") || selectedValue.StartsWith("COR") || selectedValue.StartsWith("EPE")))
                {
                    // Usar la columna "impte"
                    if (!dataGridView1.Columns.Contains("impte"))
                    {
                        MessageBox.Show("La columna 'impte' no existe en el DataGridView.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    columnIndex = dataGridView1.Columns["impte"].Index;
                }
                else
                {
                    MessageBox.Show("No se puede determinar la columna adecuada para el valor seleccionado del ComboBox.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Convertir los valores de la columna a tipo double y formatear
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[columnIndex].Value != null)
                    {
                        string cellValue = row.Cells[columnIndex].Value.ToString().Trim();

                        // Reemplazar solo las comas que no sean parte de números decimales
                        if (cellValue.Contains(","))
                        {
                            // Comprobar si la coma es un separador decimal y no un separador de miles
                            if (cellValue.Count(c => c == ',') == 1 && cellValue.IndexOf(',') == cellValue.Length - 3)
                            {
                                // Es un número decimal con coma, reemplazar comas por puntos
                                cellValue = cellValue.Replace(",", ".");
                            }
                            else
                            {
                                // Es un número con separador de miles, eliminar comas
                                cellValue = cellValue.Replace(",", "");
                            }
                        }

                        if (double.TryParse(cellValue, NumberStyles.Number, CultureInfo.InvariantCulture, out double value))
                        {
                            row.Cells[columnIndex].Value = value;
                        }
                    }
                }

                // Aplicar el formato y alineación
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "#,##0.00";
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al formatear la columna según el valor seleccionado del ComboBox: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formato(string fileNameWithoutExtension)
        {
            try
            {
                // Obtener el valor seleccionado del ComboBox
                string selectedValue = comboBox1.SelectedItem?.ToString();

                // Determinar la columna a utilizar según el valor seleccionado del ComboBox
                int columnIndex;
                if (selectedValue == "CATAUX" || selectedValue == "CATMAY")
                {
                    // Usar la columna "B3"
                    if (!dataGridView1.Columns.Contains("B3"))
                    {
                        MessageBox.Show("La columna 'B3' no existe en el DataGridView.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    columnIndex = dataGridView1.Columns["B3"].Index;
                }
                else if (selectedValue != null && (selectedValue.StartsWith("SAC") || selectedValue.StartsWith("COR") || selectedValue.StartsWith("EPE")))
                {
                    // Usar la columna "impte"
                    if (!dataGridView1.Columns.Contains("impte"))
                    {
                        MessageBox.Show("La columna 'impte' no existe en el DataGridView.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    columnIndex = dataGridView1.Columns["impte"].Index;
                }
                else
                {
                    MessageBox.Show("No se puede determinar la columna adecuada para el valor seleccionado del ComboBox.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Convertir los valores de la columna a tipo double y formatear
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[columnIndex].Value != null)
                    {
                        string cellValue = row.Cells[columnIndex].Value.ToString().Trim();

                        // Reemplazar solo las comas que no sean parte de números decimales
                        if (cellValue.Contains(","))
                        {
                            // Comprobar si la coma es un separador decimal y no un separador de miles
                            if (cellValue.Count(c => c == ',') == 1 && cellValue.IndexOf(',') == cellValue.Length - 3)
                            {
                                // Es un número decimal con coma, reemplazar comas por puntos
                                cellValue = cellValue.Replace(",", ".");
                            }
                            else
                            {
                                // Es un número con separador de miles, eliminar comas
                                cellValue = cellValue.Replace(",", "");
                            }
                        }

                        if (double.TryParse(cellValue, NumberStyles.Number, CultureInfo.InvariantCulture, out double value))
                        {
                            row.Cells[columnIndex].Value = value;
                        }
                    }
                }

                // Aplicar el formato y alineación
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Format = "#,##0.00";
                dataGridView1.Columns[columnIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al formatear la columna según el valor seleccionado del ComboBox: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gUARDARRANDOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string label1Content = label1.Text.ToUpper(); // Obtener el contenido del label 1 y convertirlo a mayúsculas

                if (label1Content.Contains("DATOS"))
                {
                    // Llamar a la función GuardarDatos con las longitudes específicas
                    GuardarDatos(64, 60, 45, 15, 5, 25, 5, 6, 11);
                }
                else if (label1Content.Contains("CATAUX") || label1Content.Contains("CATMAY"))
                {
                    // Llamar a la función GuardarCats con las longitudes específicas
                    GuardarCats(6, 32, 16, 5, 5);
                    // Formatear y alinear la columna en el índice 2
                }
                else if (label1Content.StartsWith("SAC") || label1Content.StartsWith("COR") || label1Content.StartsWith("SUP"))
                {
                    // Determinar qué función llamar basado en el nombre del archivo sin extensión
                    if (label1Content.StartsWith("SAC"))
                    {
                        // Llamar a la función GuardarOpers con las longitudes específicas para SAC
                        GuardarOpers(6, 30, 2, 16, 1, 9);
                    }
                    else if (label1Content.StartsWith("COR"))
                    {
                        // Llamar a la función GuardarOpers con las longitudes específicas para COR
                        GuardarOpers(6, 30, 2, 16, 1, 9);
                    }
                    else if (label1Content.StartsWith("SUP"))
                    {
                        // Llamar a la función GuardarOpers con las longitudes específicas para SUP
                        GuardarOpers(6, 30, 2, 16, 1, 9);
                    }
                    else
                    {
                        MessageBox.Show("Nombre de archivo no reconocido para guardar datos.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de archivo no reconocido para guardar datos.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gUARDARCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save as CSV file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvContent = new StringBuilder();

                // Adding the column headers
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    csvContent.Append(dataGridView1.Columns[i].HeaderText);
                    if (i < dataGridView1.Columns.Count - 1)
                        csvContent.Append(";");
                }
                csvContent.AppendLine();

                // Adding the rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        csvContent.Append(row.Cells[i].Value?.ToString());
                        if (i < dataGridView1.Columns.Count - 1)
                            csvContent.Append(";");
                    }
                    csvContent.AppendLine();
                }

                // Writing to the file
                File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                MessageBox.Show("CSV file saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Por favor, ingresa el texto a buscar.");
                return;
            }

            searchResults.Clear();
            currentSearchIndex = -1;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().IndexOf(searchText, StringComparison.Ordinal) >= 0)
                    {
                        searchResults.Add(cell);
                    }
                }
            }

            if (searchResults.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias.");
            }
            else
            {
                currentSearchIndex = 0;
                HighlightCurrentSearchResult();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (searchResults.Count == 0)
            {
                MessageBox.Show("No hay coincidencias para navegar.");
                return;
            }

            currentSearchIndex++;
            if (currentSearchIndex >= searchResults.Count)
            {
                currentSearchIndex = 0; // Volver al primer resultado
            }

            HighlightCurrentSearchResult();
        }

        private void HighlightCurrentSearchResult()
        {
            DataGridViewCell cell = searchResults[currentSearchIndex];
            dataGridView1.ClearSelection();
            cell.Selected = true;
            dataGridView1.CurrentCell = cell;
            dataGridView1.FirstDisplayedScrollingRowIndex = cell.RowIndex;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Limpiar dataGridView1 antes de copiar las filas de dataGridView2
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Copiar las columnas de dataGridView2 a dataGridView1
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                // Clonar la columna y ajustar el ancho
                DataGridViewColumn newColumn = (DataGridViewColumn)column.Clone();
                newColumn.Width = column.Width; // Copiar el ancho de la columna
                dataGridView1.Columns.Add(newColumn);
            }

            // Copiar las filas de dataGridView2 a dataGridView1
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                // Verificar que la fila no sea una fila nueva vacía
                if (!row.IsNewRow)
                {
                    // Crear una nueva fila para dataGridView1
                    DataGridViewRow newRow = (DataGridViewRow)row.Clone();
                    newRow.Height = row.Height; // Copiar la altura de la fila

                    // Copiar los valores de las celdas de la fila original a la nueva fila
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        newRow.Cells[i].Value = row.Cells[i].Value;
                        newRow.Cells[i].Style = row.Cells[i].Style; // Copiar el estilo de la celda
                    }

                    // Agregar la nueva fila a dataGridView1
                    dataGridView1.Rows.Add(newRow);
                }
            }

            // Asignar la numeración en los encabezados de fila (RowHeaders)
            int rowIndex = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.HeaderCell.Value = rowIndex.ToString();
                    rowIndex++;
                }
            }

            // Configurar el estilo de la fuente para dataGridView1
            Font newFont = new Font("Arial", 7, FontStyle.Bold); // Cambia "Arial" y otros parámetros según tus preferencias
            dataGridView1.DefaultCellStyle.Font = newFont;

            // Deshabilitar la ordenación de las columnas
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Ajustar el ancho del encabezado de fila para mostrar el número completo
            dataGridView1.RowHeadersWidth = 65; // Ajusta el ancho según sea necesario
        }



        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopyToClipboard();
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteFromClipboard();
            }
        }

        private void CopyToClipboard()
        {
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
            }
        }

        // Método para pegar datos desde el portapapeles a las celdas seleccionadas
        private void PasteFromClipboard()
        {
            string s = Clipboard.GetText();
            string[] lines = s.Split('\n');

            int row = dataGridView1.CurrentCell.RowIndex;
            int col = dataGridView1.CurrentCell.ColumnIndex;

            foreach (string line in lines)
            {
                if (row < dataGridView1.RowCount && line.Length > 0)
                {
                    string[] cells = line.Split('\t');
                    for (int i = 0; i < cells.Length; ++i)
                    {
                        if (col + i < dataGridView1.ColumnCount)
                        {
                            dataGridView1[col + i, row].Value = Convert.ChangeType(cells[i], dataGridView1[col + i, row].ValueType);
                        }
                        else
                        {
                            break;
                        }
                    }
                    row++;
                }
                else
                {
                    break;
                }
            }
        }

        /*    private void button9_Click(object sender, EventArgs e)
            {
                ProcesarDatos();
            }*/

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cAMBIARRUTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configura el OpenFileDialog para seleccionar carpetas
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.FileName = "Seleccione una carpeta";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtiene la ruta seleccionada y la asigna al texto de label3
                    string folderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                    label3.Text = folderPath;
                }
            }
        }
        private void borrarSaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica si la columna "Saldo" existe en el DataGridView
            if (!dataGridView1.Columns.Contains("Saldo"))
            {
                MessageBox.Show("La columna 'Saldo' no existe en el DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Sale del método si la columna no existe
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    // Intenta establecer el valor en $0 en la celda correspondiente
                    row.Cells["Saldo"].Value = "$0";
                }
                catch
                {
                    // Si ocurre una excepción en una fila específica, muestra un MessageBox
                    MessageBox.Show("Error al intentar actualizar una fila. Asegúrate de que todas las celdas 'Saldo' son válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Sale del método si ocurre un error
                }
            }
        }

        private void modificarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Form3
            Form3 form3 = new Form3();

            // Mostrar el Formulario 3
            form3.Show(); // Usa form3.ShowDialog(); si quieres abrirlo como un formulario modal
        }

        private void subirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Archivos de Texto|*"; // Filtro para archivos de texto

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog1.FileName;

                    // Extraer el nombre del archivo sin la extensión
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                    // Asignar el nombre al texto del label (label1)
                    label1.Text = fileNameWithoutExtension;

                    // Leer la línea completa del archivo
                    string lineaCompleta = File.ReadAllText(filePath);

                    // Aquí debe de llevar una instrucción dependiendo el label
                    if (fileNameWithoutExtension.StartsWith("CATMAY", StringComparison.OrdinalIgnoreCase))
                    {
                        InterpretarYMostrarCatmay(lineaCompleta);
                    }
                    else if (fileNameWithoutExtension.StartsWith("CATAUX", StringComparison.OrdinalIgnoreCase))
                    {
                        InterpretarYMostrarCataux(lineaCompleta);
                    }
                    else if (fileNameWithoutExtension.Equals("DATOS", StringComparison.OrdinalIgnoreCase))
                    {
                        InterpretarYMostrarDatos(lineaCompleta);
                    }
                    else if (fileNameWithoutExtension.StartsWith("SAC", StringComparison.OrdinalIgnoreCase) ||

                             fileNameWithoutExtension.StartsWith("COR", StringComparison.OrdinalIgnoreCase) ||
                             fileNameWithoutExtension.StartsWith("EPE", StringComparison.OrdinalIgnoreCase) ||
                             fileNameWithoutExtension.StartsWith("ING", StringComparison.OrdinalIgnoreCase) ||
                             fileNameWithoutExtension.StartsWith("CON", StringComparison.OrdinalIgnoreCase) ||
                             fileNameWithoutExtension.StartsWith("GEO", StringComparison.OrdinalIgnoreCase) ||
                             fileNameWithoutExtension.StartsWith("SUP", StringComparison.OrdinalIgnoreCase))
                    {
                        InterpretarYMostrarOperaciones(lineaCompleta);
                    }
                    else
                    {
                        MessageBox.Show("Archivo no reconocido.");
                    }
                    button1_Click(sender, e);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el archivo: " + ex.Message);
            }
        }

        private void originalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas borrar todos los datos?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Si el usuario selecciona "Sí", proceder a borrar los datos
                if (result == DialogResult.Yes)
                {
                    dataGridView2.Rows.Clear();
                    // Si también quieres borrar las columnas, descomenta la siguiente línea:
                    dataGridView2.Columns.Clear();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void copiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de que deseas borrar todos los datos?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Si el usuario selecciona "Sí", proceder a borrar los datos
                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.Clear();
                    // Si también quieres borrar las columnas, descomenta la siguiente línea:
                    dataGridView1.Columns.Clear();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
