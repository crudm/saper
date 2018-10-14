using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6lab
{
    [TestFixture]
    class Test
    {
         
        [TestCase]
        public void calc()
        {
            play test = new play();

            test.field = new int[,]
            {
                {1, 1, 1, 2, 0 },
                {9, 1, 2, 9, 9 },
                {1, 1, 2, 9, 9 },
                {0, 0, 1, 2, 0 },
                {0, 0, 0, 0, 0 }
            };
              test.calc();
               Assert.AreEqual(0, test.field[0, 4]);
        }
        
     
        [TestCase]
        public void check()
         {
        
            play test = new play();

            test.field = new int[,] {
                {  9,  9,  0,  0,  0 },
                {  9,  9,  9,  9,  0 },
                {  0,  9,  9,  9,  0 },
                {  0,  9,  9,  9,  0 } };

            Assert.AreEqual(false, test.check(0, 0));
            Assert.AreEqual(true, test.check (1, 0));
            Assert.AreEqual(false, test.check(2, 2));

        }
        [TestCase]
        public void mines()
        {
            play test = new play();

            test.field = new int[5, 5];

            test.mines(10);

            int mines = 0;

            for (int i = 0; i < test.field.GetLength(0); i++)
                for (int j = 0; j < test.field.GetLength(1); j++)
                    if (test.field[i, j] == 9)
                        mines++;

            Assert.AreEqual(10, mines);

            bool isBroken = true;

            for (int i = 0; i < test.field.GetLength(0); i++)
                for (int j = 0; j < test.field.GetLength(1); j++)
                    if (test.check(i, j) == false)
                        isBroken = false;

            Assert.AreEqual(true, isBroken);


        }


        [TestCase]
        public void get()
        {
            play test = new play();

            test.field = new int[,] {
                {  9,  9,  0,  0,  0 },
                {  0,  9,  9,  9,  0 },
                {  0,  9,  0,  9,  0 },
                {  0,  9,  9,  9,  0 } };
            test.calc();
            Assert.AreEqual(test.get(1, 0), 4);
            Assert.AreEqual(test.get(0, 3), 2);
            Assert.AreEqual(test.get(2, 0), 3);

        }


        [TestCase]
        public void set()
        {
            play test = new play();

            //проверка выполняется успешно, если исключение не было сгенерировано
            Assert.AreEqual(false, test.set(-1));
            Assert.AreEqual(true, test.set(2));

            //Assert.DoesNotThrow(() => test.set(2));

        }

    }
}
