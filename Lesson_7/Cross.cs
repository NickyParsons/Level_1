using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lesson_7
{
    class Cross
    {
        static int fieldSize = -1;
        static int needForWin;
        static char[,] field;

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static Random random = new Random();
        
        // Установка размера игрового поля
        private static void SetFieldSize()
        {
            do
            {
                Console.Write("Введите размерность игрового поля: ");
                try
                {
                    fieldSize = Convert.ToInt32(Console.ReadLine());
                    if (fieldSize < 3 && fieldSize > 0)
                    {
                        Console.WriteLine("БОТ: \"-Ну... это не интересно! Давай хотябы 3?\"");
                    }
                    else if (fieldSize < 1)
                    {
                        Console.WriteLine("БОТ: \"Как это?\"");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("БОТ: \"Прости, не понимаю тебя.\"");
                }
            } while (fieldSize < 3);
            field = new char[fieldSize, fieldSize];
            CalculateInRowCount();
        }
        // Вычисление условия победы
        private static void CalculateInRowCount()
        {
            if(fieldSize <= 4)
            {
                needForWin = fieldSize;
            }
            else
            {
                needForWin = 4;
            }
        }

        // Начальное заполнение пустыми символами
        private static void InitField()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }
        // Отрисовка поля
        private static void PrintField()
        {
            Console.WriteLine("-------");
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write("|");
                for (int j = 0; j < fieldSize; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------");
        }
        // Информация о правилах игры
        private static void PrintRules()
        {
            Console.Write($"Размер поля: {fieldSize}; ");
            Console.Write($"Для победы нужно символов в ряд: {needForWin}.\n");
        }
        // Установка символа в клетку
        private static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }
        // Проверка возможности установки символа
        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > fieldSize - 1 || y > fieldSize - 1)
            {
                return false;
            }

            return field[y, x] == EMPTY_DOT;
        }
        // Проверка заполненного поля
        private static bool IsFieldFull()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        // Шаг игрока
        private static void PlayerStep()
        {
            int x;
            int y;
            do
            {
                Console.WriteLine($"Введите координату X (1-{fieldSize}):");
                x = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine($"Введите координату Y (1-{fieldSize}):");
                y = Int32.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }
        // Рандомный шаг бота
        private static void RandomAiStep()
        {
            int x;
            int y;
            do
            {
                x = random.Next(0, fieldSize);
                y = random.Next(0, fieldSize);
            } while (!IsCellValid(y, x));
            SetSym(y, x, AI_DOT);
            Console.WriteLine("БОТ: \"А я вот так...\"");
        }
        // Умный шаг бота
        private static void SmartAiStep()
        {
            int x = 0;
            int y = 0;
            bool isAIWantBlock = false;
            char[] currentLine = new char[fieldSize];

            // Вычислаяем нужно ли блокировать по горизонтали
            for (int i = 0; i < fieldSize; i++)
            {
                currentLine[i] = EMPTY_DOT;
            }
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    currentLine[j] = field[i, j];
                }
                
                if (isBlockNeed(currentLine))
                {
                    x = GetNumberForBlock(currentLine);
                    y = i;
                    isAIWantBlock = true;
                    break;
                }
            }
            // Вычислаяем нужно ли блокировать по вертикали
            for (int i = 0; i < fieldSize; i++)
            {
                currentLine[i] = EMPTY_DOT;
            }
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    currentLine[j] = field[j, i];
                }

                if (isBlockNeed(currentLine))
                {
                    x = i;
                    y = GetNumberForBlock(currentLine);
                    isAIWantBlock = true;
                    break;
                }
            }
            // Вычислаяем нужно ли блокировать по диагонали 1
            for (int i = 0; i < fieldSize; i++)
            {
                currentLine[i] = EMPTY_DOT;
            }
            for (int i = 0; i < fieldSize; i++)
            {
                currentLine[i] = field[i, i];
            }
            if (isBlockNeed(currentLine))
            {
                x = GetNumberForBlock(currentLine);
                y = GetNumberForBlock(currentLine);
                isAIWantBlock = true;
            }
            // Вычислаяем нужно ли блокировать по диагонали 2
            for (int i = 0; i < fieldSize; i++)
            {
                currentLine[i] = EMPTY_DOT;
            }
            for (int i = 0, j = fieldSize - 1; (i < fieldSize) || (j >= 0); i++, j--)
            {
                currentLine[i] = field[j, i];
            }
            if (isBlockNeed(currentLine))
            {
                x = GetNumberForBlock(currentLine);
                for (int i = 0, j = fieldSize - 1; (i < fieldSize) || (j >= 0); i++, j--)
                {
                    if (x == j)
                    {
                        y = i;
                        break;
                    }
                }
                isAIWantBlock = true;
            }
            // Бот делает шаг
            if (isAIWantBlock)
            {
                SetSym(y, x, AI_DOT);
                Console.WriteLine("БОТ: \"Ах так?! Тогда я схожу вот так!\"");
            }
            else
            {
                RandomAiStep();
            }
        }
        // Возвращает необходимость блокировки в строке
        private static bool isBlockNeed(char[] line)
        {
            int playerDotCount;
            bool isEmptyDot;
            for (int i = 0; i <= fieldSize - needForWin; i++)
            {
                isEmptyDot = false;
                playerDotCount = 0;
                for (int j = i; j < i + needForWin; j++)
                {
                    if (line[j] == PLAYER_DOT) playerDotCount++;
                    if (line[j] == EMPTY_DOT) isEmptyDot = true;
                }
                if ((playerDotCount >= needForWin - 1) && (isEmptyDot))
                {
                    return true;
                }
            }
            return false;
        }
        // Возвращает номер символа в линии, где нужно установить блок
        private static int GetNumberForBlock(char[] line)
        {
            int playerDotCount;
            int emptyDotNum;
            bool isEmptySlot;
            for (int i = 0; i <= fieldSize - needForWin; i++)
            {
                isEmptySlot = false;
                playerDotCount = 0;
                emptyDotNum = -1;
                for (int j = i; j < i + needForWin; j++)
                {
                    if (line[j] == PLAYER_DOT) playerDotCount++;
                    if (line[j] == EMPTY_DOT)
                    {
                        isEmptySlot = true;
                        emptyDotNum = j;
                    }
                        
                }
                if ((playerDotCount >= needForWin - 1) && (isEmptySlot))
                {
                    return emptyDotNum;
                }
            }
            return -1;
        }
        // Проверка победы
        private static bool CheckWin(char sym)
        {
            int inRow;
            // Проверка горизонтали
            for (int i = 0; i < fieldSize; i++)
            {
                inRow = 0;
                for (int j = 0; j < fieldSize; j++)
                {
                    if (field[i, j] == sym)
                        inRow++;
                    else
                        inRow = 0;
                    if (inRow >= needForWin) return true;
                }
            }
            // Проверка вертикали
            for (int i = 0; i < fieldSize; i++)
            {
                inRow = 0;
                for (int j = 0; j < fieldSize; j++)
                {
                    if (field[j, i] == sym) 
                        inRow++;
                    else
                        inRow = 0;
                    if (inRow >= needForWin) return true;
                }
            }
            // Проверка первой диагонали
            inRow = 0;
            for (int i = 0; i < fieldSize; i++)
            {
                if (field[i, i] == sym) 
                    inRow++;
                else
                    inRow = 0;
                if (inRow >= needForWin) return true;
            }
            // Проверка второй диагонали
            inRow = 0;
            for (int i = 0, j = fieldSize-1; (i < fieldSize) || (j>=0); i++, j--)
            {
                if (field[j, i] == sym) 
                    inRow++;
                else
                    inRow = 0;
                if (inRow >= needForWin) return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string answer = "y";
            do
            {
                //
                Console.Clear();
                SetFieldSize();
                InitField();
                Console.Clear();
                PrintRules();
                Console.WriteLine("БОТ: \"Ну... Погнали!.\"");
                PrintField();
                Console.WriteLine("БОТ: \"Твой ход!\"");
                while (true)
                {
                    PlayerStep();
                    Console.Clear();
                    if (CheckWin(PLAYER_DOT))
                    {
                        Console.WriteLine("БОТ: \"Ты просто мастер! Поздравляю!\"");
                        PrintField();
                        break;
                    }
                    if (IsFieldFull())
                    {
                        Console.WriteLine("БОТ: \"Похоже, что ничья...\"");
                        PrintField();
                        break;
                    }
                    Console.WriteLine("БОТ: \"Подожди, я думаю...\"");
                    Thread.Sleep(1500);
                    Console.Clear();
                    SmartAiStep();
                    PrintField();
                    if (CheckWin(AI_DOT))
                    {
                        Console.Clear();
                        Console.WriteLine("БОТ: \"Ха-ха-ха! Я одолел тебя!\"");
                        PrintField();
                        break;
                    }
                    if (IsFieldFull())
                    {
                        Console.Clear();
                        Console.WriteLine("БОТ: \"Похоже, что ничья...\"");
                        PrintField();
                        break;
                    }
                }
                //
                Console.WriteLine("БОТ: \"Еще разок?\" (y/n)");
                answer = Console.ReadLine();
            } while (answer == "y");
        }
    }
}
