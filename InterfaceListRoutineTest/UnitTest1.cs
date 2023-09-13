using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace InterfaceListRoutineTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Queue<IAnimal> animals = new Queue<IAnimal>();

            List<IAnimal> animals_list = new List<IAnimal>();
            for (int i = 0; i < 5; i++)
            {
                animals.Enqueue(new Cat() { ID = i, Child = new Cat() { ID = i } });
            }            

            for (int i = 0; i < 10; i++)
            {
                Cat cat = (Cat)animals.Dequeue();
                Cat copycat = (Cat)cat.Clone();
                copycat.ID = i;
                copycat.Child.ID = i;
                animals_list.Add(copycat);
                animals.Enqueue(copycat);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            Queue<IAnimal> animals = new Queue<IAnimal>();

            List<IAnimal> animals_list = new List<IAnimal>();
            for (int i = 0; i < 5; i++)
            {
                animals.Enqueue(new Cat() { ID = i, Child = new Cat() { ID = i } });
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cat, Cat>();
            });
            var mapper = config.CreateMapper();

            for (int i = 0; i < 10; i++)
            {
                Cat cat = (Cat)animals.Dequeue();
                Cat copycat = new Cat();
                mapper.Map(cat, copycat);
                copycat.ID = i;
                copycat.Child.ID = i;
                animals_list.Add(copycat);
                animals.Enqueue(copycat);
            }
        }
    }

    public interface IAnimal
    {
        int ID { get; set; }
    }
}
