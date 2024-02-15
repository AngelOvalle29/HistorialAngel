using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;

namespace Escritura_de_Archivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Guardar(string fileName, string texto)
        {
            //Abrir el archivo: Write sobreescribe el archivo, Append agrega los datos al final del archivo
            FileStream flujo= new FileStream(fileName, FileMode.Append, FileAccess.Write);
            //Crear un objeto para escribir el archivo
            StreamWriter writer = new StreamWriter(flujo);
            //Usar el objeto para escribir al archivo, WriteLine, escribe linea por linea
            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            writer.WriteLine(texto);
            //Cerrar el archivo para que no se quede abierto y entonces se pueda volver a abrir, de lo contario va a haber un error y no podra abrirse de nuevo
            writer.Close();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar(@"C:\Users\MSI\Desktop\archivo.txt", textBox1.Text);
            //Muestra un mensaje despues 
            MessageBox.Show("Archivo Guardado con Exito!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Directorio en donde se va a iniciar la busqueda
            openFileDialog1.InitialDirectory = @"c:\source\repos\Escritura_de_Archivos\bin\Debug";
            //Tipos de archivos que se van a buscar, en este caso archivos de texto con extensión .txt
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//Abre la ventana
            {
                string nombreArchivo = openFileDialog1.FileName;

                //Guardamos en una variable el nombre del archivo que abrimos
                string fileName = openFileDialog1.FileName;

                //Abrimos el archivo, en este caso lo abrimos para lectura
                FileStream flujo = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(flujo);

                //Un ciclo para leer el archivo hasta el final del archivo
                //Lo leído se va guardando en un control richTextBox
                while (reader.Peek() > -1)//Leer linea por linea y se manda a textbox
                //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
                //lo muestre en otro control por ejemplo un combobox
                {
                    string textoLeido = reader.ReadLine();
                    richTextBox1.AppendText(textoLeido);
                }
                //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
                reader.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {



            string nombreArchivo = @"C:\Users\MSI\source\repos\Escritura_de_Archivos\Escritura_de_Archivos\bin\Debug\archivo.txt";

           
            FileStream flujo = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(flujo);

            
            while (reader.Peek() > -1)
            { 
                string textoLeido = reader.ReadLine();
                richTextBox1.AppendText(textoLeido);
            }
           
            reader.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}