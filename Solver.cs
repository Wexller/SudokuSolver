using System;

namespace SudokuSolver
{
    class Solver
    {
        /// <summary>
        /// Размерность матрицы
        /// </summary>
        private const int MATRIX_SIZE = 9;

        /// <summary>
        /// Матриа
        /// </summary>
        public int[,] matrix;

        /// <summary>
        /// Объект для генерации случайных чисел
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Конструктор класса Solver
        /// </summary>
        /// <param name="matrix">Матрица</param>
        public Solver(int[,] matrix)
        {
            this.matrix = matrix;
        }

        /// <summary>
        /// Метод, проверяющий числа на повторы в строке
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="positionX">Расположение элемента по Х</param>
        /// <param name="positionY">Расположение элемента по Y</param>
        /// <param name="currentMatrix">Проверяемая матрица</param>
        /// <returns>Возвращает true, если совпадения не найдены. Возвращает false - если найдены</returns>
        public bool CheckRow(int value, int positionX, int positionY, int[,] currentMatrix)
        {
            bool result = true;

            for (int i = 0; i < 9; i++)
            {
                if (i != positionY && currentMatrix[positionX, i] != 0)
                    if (currentMatrix[positionX, i] == value)
                    {
                        result = false;
                        break;
                    }
            }

            return result;
        }

        /// <summary>
        /// Метод, проверяющий числа на повторы в колноке
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="positionX">Расположение элемента по Х</param>
        /// <param name="positionY">Расположение элемента по Y</param>
        /// <param name="currentMatrix">Проверяемая матрица</param>
        /// <returns>Возвращает true, если совпадения не найдены. Возвращает false - если найдены</returns>
        public bool CheckColumn(int value, int positionX, int positionY, int[,] currentMatrix)
        {
            bool result = true;

            for (int i = 0; i < 9; i++)
            {
                if (i != positionX && currentMatrix[i, positionY] != 0)
                    if (currentMatrix[i, positionY] == value)
                    {
                        result = false;
                        break;
                    }
            }

            return result;
        }

        /// <summary>
        /// Метод, проверяющий числа на повторы в квадрате 3х3
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="positionX">Расположение элемента по Х</param>
        /// <param name="positionY">Расположение элемента по Y</param>
        /// <param name="currentMatrix">Проверяемая матрица</param>
        /// <returns>Возвращает true, если совпадения не найдены. Возвращает false - если найдены</returns>
        public bool CheckDistrict(int value, int positionX, int positionY, int[,] currentMatrix)
        {
            bool result = true;

            int row = positionX / 3 * 3;
            int column = positionY / 3 * 3;

            for (int i = row; i < row + 3; i++)
            {
                for (int j = column; j < column + 3; j++)
                {
                    if (i != positionX && j != positionY && currentMatrix[i, j] != 0)
                        if (currentMatrix[i, j] == value)
                        {
                            return false;
                        }
                }
            }

            return result;
        }

        /// <summary>
        /// Метод, вызывающий метод решения задачи
        /// </summary>
        /// <returns>Возвращает результирующую матрицу</returns>
        public int[,] Solve()
        {
            Solve(0, 0, matrix);

            return matrix;
        }

        /// <summary>
        /// Метод, вызывающий методы для проверки чисел на совпадение в строке/колонке/квадрате 3х3
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="positionX">Расположение элемента по Х</param>
        /// <param name="positionY">Расположение элемента по Y</param>
        /// <param name="currentMatrix">Проверяемая матрица</param>
        /// <returns>Возвращает true, если все методы вернули true. Возвращает false, если хоть один метод вернул false</returns>
        public bool CheckConditions(int value, int positionX, int positionY, int[,] array)
        {
            return CheckColumn(value, positionX, positionY, array)
                && CheckRow(value, positionX, positionY, array)
                && CheckDistrict(value, positionX, positionY, array);
        }

        /// <summary>
        /// Метод, решающий задачу по подбору чисел, удовлетворяющих требованиям игры
        /// </summary>
        /// <param name="positionX">Позиция элемента в матрице по оси Х</param>
        /// <param name="positionY">Позиция элемента в матрице по оси Y</param>
        /// <param name="currentMatrix">Текущая матрица для решения</param>
        /// <returns>Возвращает true, если решение найдено. Возвращает false, если решение не найдено</returns>
        private bool Solve(int positionX, int positionY, int[,] currentMatrix)
        {
            // Если текущая позиция элемента по оси Y равна макисмальной его позиции, то начинаем с начала
            if (positionY == MATRIX_SIZE)
            {
                positionY = 0;
                // Если следующая позиция по оси Х равна максимальной (конец решения), то возарщает true
                if (++positionX == MATRIX_SIZE)
                {
                    return true;
                }
            }

            // Если текущий элемент не равен 0, то вызываем метод Solve со сдвигом по оси Y на +1
            if (currentMatrix[positionX, positionY] != 0)
            {
                return Solve(positionX, positionY + 1, currentMatrix);
            }

            // Подстановка чисел от 0 до 9
            for (int value = 1; value <= MATRIX_SIZE; value++)
            {
                // Если подтавленное число удовлетворяет требованиям игры, то записваем его в матрицу
                if (CheckConditions(value, positionX, positionY, currentMatrix))
                {
                    currentMatrix[positionX, positionY] = value;
                    // Если следующая позиция вернёт true, то текущая тоже вернёт true
                    if (Solve(positionX, positionY + 1, currentMatrix))
                    {
                        return true;
                    }

                }
            }

            // Если все условия не выполнилось, то возвращаем на место 0 и возвращаем false           
            currentMatrix[positionX, positionY] = 0;

            return false;
        }

        /// <summary>
        /// Метод, проверяющий матрицу на соответствие правилам игры
        /// </summary>
        /// <param name="matrix">Проверяемая матрица</param>
        /// <returns>Возвращает true, если матрица соответствует правилам игры, иначе возвращает false</returns>
        public bool CheckOnRepetitions(int[,] matrix)
        {
            bool result = true;

            // Циклы, проходящие по всем элементам матрицы
            for (int i = 0; i < MATRIX_SIZE; i++)
            {
                for (int j = 0; j < MATRIX_SIZE; j++)
                {
                    // Если текущий элемент элемент не равен 0, то выполняем следующее условие
                    if (matrix[i, j] != 0)

                        // Если текущий элемент не соответствует правилам игры, то возвращаем false
                        if (!CheckConditions(matrix[i, j], i, j, matrix))
                        {
                            return false;
                        }
                }
            }

            return result;
        }
    }
}
