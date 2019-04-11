using System;

namespace SudokuSolver
{
    class Filler
    {
        /// <summary>
        /// Размерность матрицы
        /// </summary>
        private const int MATRIX_SIZE = 9;

        /// <summary>
        /// Исходная матрица
        /// </summary>
        public int[,] matrix = new int[MATRIX_SIZE, MATRIX_SIZE];

        /// <summary>
        /// Помощник для исходной матрицы для проверки элементов
        /// </summary>
        private int[,] matrixHelper = new int[MATRIX_SIZE, MATRIX_SIZE];

        /// <summary>
        /// Объект для генерации случаных чисел
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Сложность итоговой матрицы (количесвто пустых ячеек)
        /// </summary>
        private int difficulty;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="difficulty">Сложность матрицы</param>
        public Filler(int difficulty)
        {
            this.difficulty = difficulty;
        }

        /// <summary>
        /// Генерирует случаную матрицу и удаляет случаные ячейки 
        /// </summary>
        /// <returns>Возвращает результирующую матрицу</returns>
        public int[,] FillMatrix()
        {
            // Текущее значение для записи в матрицу
            int currentValue = 0;

            // Заполняет первую строку случаными номерами от 0 до 9
            for (int i = 0; i < MATRIX_SIZE; i++)
            {
                // Пока текущий элемент равен 0
                while (matrix[0, i] == 0)
                {
                    // Генерирует случайное число от 1 до 9
                    currentValue = random.Next(1, MATRIX_SIZE + 1);

                    // Если сгенерированное число не повторяется, то записываем его в матрицу
                    if (CheckLine(currentValue, i))
                    {
                        matrix[0, i] = currentValue;
                    }
                }
            }

            // Заполнение двух последующих строк со сдвигом влево на 3 столбца
            for (int i = 1; i < 3; i++)
            {
                for (int j = 0; j < MATRIX_SIZE; j++)
                {
                    int count = 0;

                    if (j < 6)
                    {
                        count = 3;
                    }
                    else
                    {
                        count = -6;
                    }

                    matrix[i, j] = matrix[i - 1, j + count];
                }
            }

            // Заполнение двух оставшихся районов со сдвигом на 1 стобец влево
            for (int i = 3; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int count = 0;

                    if (j < 8)
                    {
                        count = 1;
                    }
                    else
                    {
                        count = -8;
                    }

                    matrix[i, j] = matrix[i - 3, j + count];
                }
            }

            // Количество случаных перемешиваний
            int shuffleCount = random.Next(8, 15);

            // Вызов метода для перемешивания
            ShuffleMatrix(shuffleCount);

            // Отчистка случаных ячеек
            ClearRandomCells(GetDifficulty(difficulty));

            return matrix;

        }

        /// <summary>
        /// Проверка 1 строки на повторы
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="positionX">Позиция проверяемого элемента</param>
        /// <returns>Возвращает true, если повторов нет. Возвращает false, если есть повторы</returns>
        private bool CheckLine(int value, int positionX)
        {
            bool result = true;

            for (int i = 0; i < positionX; i++)
            {
                //Если текущее значение равно проверяемому, то возврат false
                if (matrix[0, i] == value)
                {
                    return false;
                }
            }

            return result;
        }

        /// <summary>
        /// Приравнивает все элементы помощника матрицы к нулю
        /// </summary>
        private void MakeDefaultMatrixHelper()
        {
            for (int i = 0; i < MATRIX_SIZE; i++)
                for (int j = 0; j < MATRIX_SIZE; j++)
                    matrixHelper[i, j] = 0;
        }

        /// <summary>
        /// Метод, отчищающий случаные ячейки
        /// </summary>
        /// <param name="value">Количество ячеек для отчищения</param>
        private void ClearRandomCells(int value)
        {
            // Расположение ячейки для отчищения
            int randomX = 0, randomY = 0;
            int count = value;

            MakeDefaultMatrixHelper();

            while (count > 1)
            {

                do
                {
                    randomX = random.Next(0, 9);
                    randomY = random.Next(0, 9);

                } while (matrixHelper[randomX, randomY] == 1 && matrix[randomX, randomY] == 0);


                matrixHelper[randomX, randomY] = 1;
                matrix[randomX, randomY] = 0;
                count--;

            }
        }

        /// <summary>
        /// Метод, переставляющий местами двух случаных строк в пределах одного района
        /// </summary>
        private void SwapSmallRows()
        {
            int temp;

            int district = random.Next(0, 3);
            int line1 = random.Next(0, 3);

            int line2;
            do
            {
                line2 = random.Next(0, 3);
            } while (line1 == line2);

            int finalLine1 = district * 3 + line1;
            int finalLine2 = district * 3 + line2;

            for (int i = 0; i < 9; i++)
            {
                temp = matrix[finalLine1, i];
                matrix[finalLine1, i] = matrix[finalLine2, i];
                matrix[finalLine2, i] = temp;
            }

        }

        /// <summary>
        /// Метод, переставляющий местами два случаных столбцов в пределах одного района
        /// </summary>
        private void SwapSmallColumns()
        {
            int temp;

            int district = random.Next(0, 3);
            int column1 = random.Next(0, 3);

            int colummn2;
            do
            {
                colummn2 = random.Next(0, 3);
            } while (column1 == colummn2);

            int finalColumn1 = district * 3 + column1;
            int finalColumn2 = district * 3 + colummn2;

            for (int i = 0; i < 9; i++)
            {
                temp = matrix[i, finalColumn1];
                matrix[i, finalColumn1] = matrix[i, finalColumn2];
                matrix[i, finalColumn2] = temp;
            }

        }

        /// <summary>
        /// Метод, переставляющий местами двух случаных районов по вертикали
        /// </summary>
        private void SwapDistricktsColums()
        {
            int temp1, temp2, temp3;

            int district1 = random.Next(0, 3);
            int district2;

            do
            {
                district2 = random.Next(0, 3);
            } while (district2 == district1);

            district1 *= 3;
            district2 *= 3;

            for (int i = 0; i < 9; i++)
            {
                temp1 = matrix[i, district1];
                temp2 = matrix[i, district1 + 1];
                temp3 = matrix[i, district1 + 2];

                matrix[i, district1] = matrix[i, district2];
                matrix[i, district1 + 1] = matrix[i, district2 + 1];
                matrix[i, district1 + 2] = matrix[i, district2 + 2];

                matrix[i, district2] = temp1;
                matrix[i, district2 + 1] = temp2;
                matrix[i, district2 + 2] = temp3;
            }
        }

        /// <summary>
        /// Метод, переставляющий местами двух случаных районов по горизонтали
        /// </summary>
        private void SwapDistricktsRows()
        {
            int temp1, temp2, temp3;

            int district1 = random.Next(0, 3);
            int district2;

            do
            {
                district2 = random.Next(0, 3);
            } while (district2 == district1);

            district1 *= 3;
            district2 *= 3;

            for (int i = 0; i < 9; i++)
            {
                temp1 = matrix[district1, i];
                temp2 = matrix[district1 + 1, i];
                temp3 = matrix[district1 + 2, i];

                matrix[district1, i] = matrix[district2, i];
                matrix[district1 + 1, i] = matrix[district2 + 1, i];
                matrix[district1 + 2, i] = matrix[district2 + 2, i];

                matrix[district2, i] = temp1;
                matrix[district2 + 1, i] = temp2;
                matrix[district2 + 2, i] = temp3;
            }
        }

        /// <summary>
        /// Метод, перемешивающий матрицу, вызывая случаные методы
        /// </summary>
        /// <param name="count">Количество перемешиваний</param>
        private void ShuffleMatrix(int count)
        {

            int option;

            for (int i = 0; i < count; i++)
            {
                option = random.Next(1, 5);
                switch (option)
                {
                    case 1:
                        SwapDistricktsColums();
                        break;
                    case 2:
                        SwapDistricktsRows();
                        break;
                    case 3:
                        SwapSmallColumns();
                        break;
                    case 4:
                        SwapSmallRows();
                        break;
                }
            }
        }

        /// <summary>
        /// Метод, для возврата сложности результрующей матрицы
        /// </summary>
        /// <param name="index">Индекс сложности. 1 - легко, 2 - нормально, 3 - тяжело</param>
        /// <returns>Возвращает количество ячеек, которые необходимо убрать</returns>
        private int GetDifficulty(int index)
        {
            int result;

            switch (index)
            {
                case 1:
                    result = random.Next(46, 51);
                    break;

                case 2:
                    result = random.Next(51, 56);
                    break;

                case 3:
                    result = random.Next(56, 61);
                    break;

                default:
                    result = 50;
                    break;
            }

            return result;
        }

    }
}
