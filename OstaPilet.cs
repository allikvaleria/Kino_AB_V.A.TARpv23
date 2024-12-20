using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_AB_V.A.TARpv23
{
    public partial class OstaPilet : Form
    {
        string seanss_start;
        public string posterFile;  // Полный путь к постеру
        string filmiNimetus;  // Название фильма

        Random random = new Random();
        Button osta_pilet;

        // Класс, представляющий кинотеатр (зал)
        public class KinoSaal
        {
            public int RidadeArv { get; set; }
            public int KohtadeArv { get; set; }

            public KinoSaal(int ridadeArv, int kohtadeArv)
            {
                RidadeArv = ridadeArv;
                KohtadeArv = kohtadeArv;
            }
        }

        private List<Button> buttons; // Список кнопок для мест
        private KinoSaal kinosaal; // Один зал с фиксированными размерами
        private List<string> valitudKohad = new List<string>(); // Список выбранных мест

        public OstaPilet(string _filminimetus, string _posterFile, string _seanss_start)
        {
            filmiNimetus = _filminimetus;
            posterFile = _posterFile;
            seanss_start = _seanss_start;

            buttons = new List<Button>();

            Load += (s, e) =>
            {
                // Создаем один зал с фиксированными размерами
                kinosaal = new KinoSaal(10, 15); // 10 рядов, 15 мест в ряду

                this.Width = 1300;  // Увеличиваем размер формы, чтобы поместить больше мест
                this.Height = 1000;

                // Отображаем зал на форме
                SaaliKuvamine();

                // Создаем кнопку для покупки билета
                osta_pilet = new Button();
                osta_pilet.Size = new Size(150, 50);
                osta_pilet.Location = new Point(900, 850);
                osta_pilet.Text = "Osta pilet";
                osta_pilet.Font = new Font("Arial", 12, FontStyle.Bold);
                osta_pilet.BackColor = Color.Blue;
                osta_pilet.ForeColor = Color.White;
                osta_pilet.Click += Osta_pilet_Click;
                Controls.Add(osta_pilet);
            };
        }

        private void Osta_pilet_Click(object sender, EventArgs e)
        {
            if (valitudKohad.Count > 0)
            {
                // Передаем список выбранных мест в PDFForm
                PDFForm pdfForm = new PDFForm(filmiNimetus, posterFile, valitudKohad, seanss_start);
                pdfForm.Show();
            }
            else
            {
                MessageBox.Show("Palun valige oma koht enne pileti ostmist");
            }
        }

        // Метод для отображения одного зала на форме
        private void SaaliKuvamine()
        {
            int Y = 10;  // Смещение по вертикали для отображения мест
            int X = 10;  // Смещение по горизонтали для отображения мест

            // Создаем кнопки для мест в зале
            for (int i = 0; i < kinosaal.RidadeArv; i++)
            {
                for (int j = 0; j < kinosaal.KohtadeArv; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(60, 60);
                    btn.Location = new Point(X + j * 70, Y + i * 70); // 70 пикселей между местами
                    btn.Text = $"{i + 1}-{j + 1}";
                    btn.Font = new Font("Arial", 10, FontStyle.Bold);
                    btn.Name = $"Btn-{i + 1}-{j + 1}";
                    btn.BackColor = Color.Green;
                    btn.Tag = "available";
                    btn.Click += Btn_Click;
                    buttons.Add(btn);
                    Controls.Add(btn);
                }
            }

            // Генерация случайных забронированных мест для зала
            KohtadeBroneeringud();
        }

        // Обработчик клика по кнопке
        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // Если кнопка зеленая, она будет изменена на красную, и место будет выбрано
            if (clickedButton.BackColor == Color.Green)
            {
                clickedButton.BackColor = Color.Red;
                valitudKohad.Add(clickedButton.Text); // Добавляем выбранное место в список
            }
            else // Если кнопка уже красная, она возвращается в исходное состояние
            {
                clickedButton.BackColor = Color.Green;
                valitudKohad.Remove(clickedButton.Text); // Убираем место из списка
            }
        }

        // Генерация случайных забронированных мест
        private void KohtadeBroneeringud()
        {
            // Генерация случайных забронированных мест для зала
            List<Button> availableButtons = buttons.Where(b => b.Tag.ToString() == "available").ToList();
            for (int i = 0; i < 30; i++) // 30 случайных забронированных мест
            {
                Button bookedButton = availableButtons[random.Next(availableButtons.Count)];
                bookedButton.BackColor = Color.Gray;
                bookedButton.Tag = "booked";
            }
        }
    }
}
