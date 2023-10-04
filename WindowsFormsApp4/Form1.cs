using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        



        private void button1_Click(object sender, EventArgs e)
        {
            Point point = new Point();
            point = this.Location;
            point.X += 8;
            point.Y += 32;
            contextMenuStrip1.Show(point);
            
        }

        private void CreateDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                string directoryName = "МойКаталог"; // Установите желаемое имя каталога

                try
                {
                    string fullDirectoryPath = Path.Combine(folderPath, directoryName);

                    // Проверяем, существует ли каталог
                    if (!Directory.Exists(fullDirectoryPath))
                    {
                        // Создаем каталог
                        Directory.CreateDirectory(fullDirectoryPath);
                        MessageBox.Show($"Каталог успешно создан: {fullDirectoryPath}");
                    }
                    else
                    {
                        MessageBox.Show("Каталог уже существует.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при создании каталога: {ex.Message}");
                }
            }
        }

        private void создатьКаталогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;

                try
                {
                    // Проверяем, существует ли каталог
                    if (!Directory.Exists(folderPath))
                    {
                        // Создаем каталог
                        Directory.CreateDirectory(folderPath);
                        MessageBox.Show($"Каталог успешно создан: {folderPath}");
                    }
                    else
                    {
                        MessageBox.Show("Каталог уже существует.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при создании каталога: {ex.Message}");
                }
            }
        }

        private void удалитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Установите фильтр файлов, если нужно
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Проверяем, существует ли файл
                    if (File.Exists(filePath))
                    {
                        // Удаляем файл
                        File.Delete(filePath);
                        MessageBox.Show($"Файл успешно удален: {filePath}");
                    }
                    else
                    {
                        MessageBox.Show("Файл не существует.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при удалении файла: {ex.Message}");
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Установите фильтр файлов, если нужно
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Открываем выбранный файл и отображаем его содержимое в текстовом поле
                    textBox1.Text = File.ReadAllText(filePath);
                    MessageBox.Show($"Файл успешно открыт: {filePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при открытии файла: {ex.Message}");
                }
            }
        }

        private void CreateFileMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Установите фильтр файлов, если нужно
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Создаем новый файл (если он не существует) и открываем его для редактирования
                    File.Create(filePath).Close();

                    // Открываем созданный файл в текстовом поле
                    textBox1.Text = File.ReadAllText(filePath);
                    MessageBox.Show($"Создан новый файл: {filePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при создании файла: {ex.Message}");
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Установите фильтр файлов, если нужно
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string textToSave = textBox1.Text;

                try
                {
                    // Сохраняем текст в выбранный файл
                    File.WriteAllText(filePath, textToSave);
                    
                    MessageBox.Show("Текст успешно сохранен.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при сохранении: {ex.Message}");
                }
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
