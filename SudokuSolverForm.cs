using System;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class SudokuSolverForm : Form
    {
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public SudokuSolverForm()
        {
            InitializeComponent();
            easy.Checked = true; // Значение ComboBox по умолчанию
        }

        /// <summary>
        /// Метод, обрабатывающий событие нажатия на кнопку "Сгенерировать". Вызывает метод, генерирующий матрицу и метод, заполняющий ячейки
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void Genirate_Click(object sender, EventArgs e)
        {
            Filler cells = new Filler(CheckRadioButtons());
            int[,] matrix = cells.FillMatrix();

            FillCells(matrix);
        }

        /// <summary>
        /// Метод, проверяющий элемент матрицы на 0
        /// </summary>
        /// <param name="matrix">Проверяемая матрица</param>
        /// <param name="x">Расположение элемента по оси Х</param>
        /// <param name="y">Расположение элемента по оси Y</param>
        /// <returns>Если ноль, возвращает пробел, иначе цифру, преобразованную в строку</returns>
        private string CheckNumber(int[,] matrix, int x, int y)
        {
            if (matrix[x, y] == 0)
            {
                return " ";
            }
            else
            {
                return matrix[x, y].ToString();
            }
        }

        /// <summary>
        /// Метод, проверяющий значение на пробел или пустоту
        /// </summary>
        /// <param name="value">Проверяемая матрица</param>
        /// <returns>Если пробел/пустота, возвращает 0, иначе строку, преобразованную в цифру</returns>
        private int GetNumber(string value)
        {
            if (value == " " || value == "")
            {
                return 0;
            }
            else
            {
                return int.Parse(value);
            }
        }

        /// <summary>
        /// Метод, заполняющий ячейки из матрицы
        /// </summary>
        /// <param name="matrix">Матрица с элементами</param>
        private void FillCells(int[,] matrix)
        {
            box1_1.Text = CheckNumber(matrix, 0, 0);
            box1_2.Text = CheckNumber(matrix, 0, 1);
            box1_3.Text = CheckNumber(matrix, 0, 2);
            box1_4.Text = CheckNumber(matrix, 0, 3);
            box1_5.Text = CheckNumber(matrix, 0, 4);
            box1_6.Text = CheckNumber(matrix, 0, 5);
            box1_7.Text = CheckNumber(matrix, 0, 6);
            box1_8.Text = CheckNumber(matrix, 0, 7);
            box1_9.Text = CheckNumber(matrix, 0, 8);

            box2_1.Text = CheckNumber(matrix, 1, 0);
            box2_2.Text = CheckNumber(matrix, 1, 1);
            box2_3.Text = CheckNumber(matrix, 1, 2);
            box2_4.Text = CheckNumber(matrix, 1, 3);
            box2_5.Text = CheckNumber(matrix, 1, 4);
            box2_6.Text = CheckNumber(matrix, 1, 5);
            box2_7.Text = CheckNumber(matrix, 1, 6);
            box2_8.Text = CheckNumber(matrix, 1, 7);
            box2_9.Text = CheckNumber(matrix, 1, 8);

            box3_1.Text = CheckNumber(matrix, 2, 0);
            box3_2.Text = CheckNumber(matrix, 2, 1);
            box3_3.Text = CheckNumber(matrix, 2, 2);
            box3_4.Text = CheckNumber(matrix, 2, 3);
            box3_5.Text = CheckNumber(matrix, 2, 4);
            box3_6.Text = CheckNumber(matrix, 2, 5);
            box3_7.Text = CheckNumber(matrix, 2, 6);
            box3_8.Text = CheckNumber(matrix, 2, 7);
            box3_9.Text = CheckNumber(matrix, 2, 8);

            box4_1.Text = CheckNumber(matrix, 3, 0);
            box4_2.Text = CheckNumber(matrix, 3, 1);
            box4_3.Text = CheckNumber(matrix, 3, 2);
            box4_4.Text = CheckNumber(matrix, 3, 3);
            box4_5.Text = CheckNumber(matrix, 3, 4);
            box4_6.Text = CheckNumber(matrix, 3, 5);
            box4_7.Text = CheckNumber(matrix, 3, 6);
            box4_8.Text = CheckNumber(matrix, 3, 7);
            box4_9.Text = CheckNumber(matrix, 3, 8);

            box5_1.Text = CheckNumber(matrix, 4, 0);
            box5_2.Text = CheckNumber(matrix, 4, 1);
            box5_3.Text = CheckNumber(matrix, 4, 2);
            box5_4.Text = CheckNumber(matrix, 4, 3);
            box5_5.Text = CheckNumber(matrix, 4, 4);
            box5_6.Text = CheckNumber(matrix, 4, 5);
            box5_7.Text = CheckNumber(matrix, 4, 6);
            box5_8.Text = CheckNumber(matrix, 4, 7);
            box5_9.Text = CheckNumber(matrix, 4, 8);

            box6_1.Text = CheckNumber(matrix, 5, 0);
            box6_2.Text = CheckNumber(matrix, 5, 1);
            box6_3.Text = CheckNumber(matrix, 5, 2);
            box6_4.Text = CheckNumber(matrix, 5, 3);
            box6_5.Text = CheckNumber(matrix, 5, 4);
            box6_6.Text = CheckNumber(matrix, 5, 5);
            box6_7.Text = CheckNumber(matrix, 5, 6);
            box6_8.Text = CheckNumber(matrix, 5, 7);
            box6_9.Text = CheckNumber(matrix, 5, 8);

            box7_1.Text = CheckNumber(matrix, 6, 0);
            box7_2.Text = CheckNumber(matrix, 6, 1);
            box7_3.Text = CheckNumber(matrix, 6, 2);
            box7_4.Text = CheckNumber(matrix, 6, 3);
            box7_5.Text = CheckNumber(matrix, 6, 4);
            box7_6.Text = CheckNumber(matrix, 6, 5);
            box7_7.Text = CheckNumber(matrix, 6, 6);
            box7_8.Text = CheckNumber(matrix, 6, 7);
            box7_9.Text = CheckNumber(matrix, 6, 8);

            box8_1.Text = CheckNumber(matrix, 7, 0);
            box8_2.Text = CheckNumber(matrix, 7, 1);
            box8_3.Text = CheckNumber(matrix, 7, 2);
            box8_4.Text = CheckNumber(matrix, 7, 3);
            box8_5.Text = CheckNumber(matrix, 7, 4);
            box8_6.Text = CheckNumber(matrix, 7, 5);
            box8_7.Text = CheckNumber(matrix, 7, 6);
            box8_8.Text = CheckNumber(matrix, 7, 7);
            box8_9.Text = CheckNumber(matrix, 7, 8);

            box9_1.Text = CheckNumber(matrix, 8, 0);
            box9_2.Text = CheckNumber(matrix, 8, 1);
            box9_3.Text = CheckNumber(matrix, 8, 2);
            box9_4.Text = CheckNumber(matrix, 8, 3);
            box9_5.Text = CheckNumber(matrix, 8, 4);
            box9_6.Text = CheckNumber(matrix, 8, 5);
            box9_7.Text = CheckNumber(matrix, 8, 6);
            box9_8.Text = CheckNumber(matrix, 8, 7);
            box9_9.Text = CheckNumber(matrix, 8, 8);
        }

        /// <summary>
        /// Метод, обрабатывающий событие нажатия на кнопку "Отчистить". Отчищает все ячейки 
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void Clear_button_Click(object sender, EventArgs e)
        {
            box1_1.Clear();
            box1_2.Clear();
            box1_3.Clear();
            box1_4.Clear();
            box1_5.Clear();
            box1_6.Clear();
            box1_7.Clear();
            box1_8.Clear();
            box1_9.Clear();

            box2_1.Clear();
            box2_2.Clear();
            box2_3.Clear();
            box2_4.Clear();
            box2_5.Clear();
            box2_6.Clear();
            box2_7.Clear();
            box2_8.Clear();
            box2_9.Clear();

            box3_1.Clear();
            box3_2.Clear();
            box3_3.Clear();
            box3_4.Clear();
            box3_5.Clear();
            box3_6.Clear();
            box3_7.Clear();
            box3_8.Clear();
            box3_9.Clear();

            box4_1.Clear();
            box4_2.Clear();
            box4_3.Clear();
            box4_4.Clear();
            box4_5.Clear();
            box4_6.Clear();
            box4_7.Clear();
            box4_8.Clear();
            box4_9.Clear();

            box5_1.Clear();
            box5_2.Clear();
            box5_3.Clear();
            box5_4.Clear();
            box5_5.Clear();
            box5_6.Clear();
            box5_7.Clear();
            box5_8.Clear();
            box5_9.Clear();

            box6_1.Clear();
            box6_2.Clear();
            box6_3.Clear();
            box6_4.Clear();
            box6_5.Clear();
            box6_6.Clear();
            box6_7.Clear();
            box6_8.Clear();
            box6_9.Clear();

            box7_1.Clear();
            box7_2.Clear();
            box7_3.Clear();
            box7_4.Clear();
            box7_5.Clear();
            box7_6.Clear();
            box7_7.Clear();
            box7_8.Clear();
            box7_9.Clear();

            box8_1.Clear();
            box8_2.Clear();
            box8_3.Clear();
            box8_4.Clear();
            box8_5.Clear();
            box8_6.Clear();
            box8_7.Clear();
            box8_8.Clear();
            box8_9.Clear();

            box9_1.Clear();
            box9_2.Clear();
            box9_3.Clear();
            box9_4.Clear();
            box9_5.Clear();
            box9_6.Clear();
            box9_7.Clear();
            box9_8.Clear();
            box9_9.Clear();
        }

        /// <summary>
        /// Метод, присваивающий значения из ячеек в двумерую матрицу
        /// </summary>
        /// <returns>Возвращает двумерную матрицу</returns>
        private int[,] GetMatrix()
        {
            int[,] matrix = new int[9, 9];

            int i = 0, j = 0;

            matrix[i, j++] = GetNumber(box1_1.Text);
            matrix[i, j++] = GetNumber(box1_2.Text);
            matrix[i, j++] = GetNumber(box1_3.Text);
            matrix[i, j++] = GetNumber(box1_4.Text);
            matrix[i, j++] = GetNumber(box1_5.Text);
            matrix[i, j++] = GetNumber(box1_6.Text);
            matrix[i, j++] = GetNumber(box1_7.Text);
            matrix[i, j++] = GetNumber(box1_8.Text);
            matrix[i++, j] = GetNumber(box1_9.Text);

            j = 0;

            matrix[i, j++] = GetNumber(box2_1.Text);
            matrix[i, j++] = GetNumber(box2_2.Text);
            matrix[i, j++] = GetNumber(box2_3.Text);
            matrix[i, j++] = GetNumber(box2_4.Text);
            matrix[i, j++] = GetNumber(box2_5.Text);
            matrix[i, j++] = GetNumber(box2_6.Text);
            matrix[i, j++] = GetNumber(box2_7.Text);
            matrix[i, j++] = GetNumber(box2_8.Text);
            matrix[i++, j] = GetNumber(box2_9.Text);

            j = 0;

            matrix[i, j++] = GetNumber(box3_1.Text);
            matrix[i, j++] = GetNumber(box3_2.Text);
            matrix[i, j++] = GetNumber(box3_3.Text);
            matrix[i, j++] = GetNumber(box3_4.Text);
            matrix[i, j++] = GetNumber(box3_5.Text);
            matrix[i, j++] = GetNumber(box3_6.Text);
            matrix[i, j++] = GetNumber(box3_7.Text);
            matrix[i, j++] = GetNumber(box3_8.Text);
            matrix[i++, j] = GetNumber(box3_9.Text);

            j = 0;

            matrix[i, j++] = GetNumber(box4_1.Text);
            matrix[i, j++] = GetNumber(box4_2.Text);
            matrix[i, j++] = GetNumber(box4_3.Text);
            matrix[i, j++] = GetNumber(box4_4.Text);
            matrix[i, j++] = GetNumber(box4_5.Text);
            matrix[i, j++] = GetNumber(box4_6.Text);
            matrix[i, j++] = GetNumber(box4_7.Text);
            matrix[i, j++] = GetNumber(box4_8.Text);
            matrix[i++, j] = GetNumber(box4_9.Text);

            j = 0;

            matrix[i, j++] = GetNumber(box5_1.Text);
            matrix[i, j++] = GetNumber(box5_2.Text);
            matrix[i, j++] = GetNumber(box5_3.Text);
            matrix[i, j++] = GetNumber(box5_4.Text);
            matrix[i, j++] = GetNumber(box5_5.Text);
            matrix[i, j++] = GetNumber(box5_6.Text);
            matrix[i, j++] = GetNumber(box5_7.Text);
            matrix[i, j++] = GetNumber(box5_8.Text);
            matrix[i++, j] = GetNumber(box5_9.Text);

            j = 0;

            matrix[i, j++] = GetNumber(box6_1.Text);
            matrix[i, j++] = GetNumber(box6_2.Text);
            matrix[i, j++] = GetNumber(box6_3.Text);
            matrix[i, j++] = GetNumber(box6_4.Text);
            matrix[i, j++] = GetNumber(box6_5.Text);
            matrix[i, j++] = GetNumber(box6_6.Text);
            matrix[i, j++] = GetNumber(box6_7.Text);
            matrix[i, j++] = GetNumber(box6_8.Text);
            matrix[i++, j] = GetNumber(box6_9.Text);

            j = 0;

            matrix[i, j++] = GetNumber(box7_1.Text);
            matrix[i, j++] = GetNumber(box7_2.Text);
            matrix[i, j++] = GetNumber(box7_3.Text);
            matrix[i, j++] = GetNumber(box7_4.Text);
            matrix[i, j++] = GetNumber(box7_5.Text);
            matrix[i, j++] = GetNumber(box7_6.Text);
            matrix[i, j++] = GetNumber(box7_7.Text);
            matrix[i, j++] = GetNumber(box7_8.Text);
            matrix[i++, j] = GetNumber(box7_9.Text);

            j = 0;

            matrix[i, j++] = GetNumber(box8_1.Text);
            matrix[i, j++] = GetNumber(box8_2.Text);
            matrix[i, j++] = GetNumber(box8_3.Text);
            matrix[i, j++] = GetNumber(box8_4.Text);
            matrix[i, j++] = GetNumber(box8_5.Text);
            matrix[i, j++] = GetNumber(box8_6.Text);
            matrix[i, j++] = GetNumber(box8_7.Text);
            matrix[i, j++] = GetNumber(box8_8.Text);
            matrix[i++, j] = GetNumber(box8_9.Text);

            j = 0;

            matrix[i, j++] = GetNumber(box9_1.Text);
            matrix[i, j++] = GetNumber(box9_2.Text);
            matrix[i, j++] = GetNumber(box9_3.Text);
            matrix[i, j++] = GetNumber(box9_4.Text);
            matrix[i, j++] = GetNumber(box9_5.Text);
            matrix[i, j++] = GetNumber(box9_6.Text);
            matrix[i, j++] = GetNumber(box9_7.Text);
            matrix[i, j++] = GetNumber(box9_8.Text);
            matrix[i, j] = GetNumber(box9_9.Text);

            j = 0;

            return matrix;
        }

        /// <summary>
        /// Метод, обрабатывающий событие нажатия на кнопку "Решить". Вызывает метод решения матрицы и метод заполнения ячеек результрующей мтрицей 
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void Solve_button_Click(object sender, EventArgs e)
        {
            Solver solv = new Solver(GetMatrix());

            // Вызов метода проверки на правила игры. Если есть совпадения чисел по горизонтали/вертикали/в квадрате 3х3 - вывод сообщения об ошибке
            if (solv.CheckOnRepetitions(GetMatrix()))
            {
                int[,] matrix = solv.Solve();

                FillCells(matrix);
            }
            else
            {
                MessageBox.Show("Проверьте правильность ввода!", "Повторы чисел");
            }
        }

        /// <summary>
        /// Метод, обрабатывающий событие пропуска нажатой клавиши клавиатуры
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void Box1_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если вводимый символ не цифра и не Backspace, то запретить ввод
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Метод, для проверки выбора сложности создаваемого поля
        /// </summary>
        /// <returns>Возвращает 1 - если лёгкая, 2 - если нормальная, 3 - если тяжёлая</returns>
        private int CheckRadioButtons()
        {
            int result = 1;

            if (easy.Checked)
            {
                result = 1;
            }

            if (normal.Checked)
            {
                result = 2;
            }

            if (hard.Checked)
            {
                result = 3;
            }

            return result;
        }

        /// <summary>
        /// Метод, обрабатывающий событие нажатия на кнопку "Выход". Вызывает метод выхода из программы
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
