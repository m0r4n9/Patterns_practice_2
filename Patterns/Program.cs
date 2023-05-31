using System;

namespace Patterns
{
    abstract class Program
    {
        static void Main(string[] args)
        {
            // Создание иерархии задач
            Task projectTask = new DevelopmentTask("Разработка проекта");
            Task featureTask1 = new DevelopmentTask("Реализация функции 1");
            Task featureTask2 = new DevelopmentTask("Реализация функции 2");

            projectTask.AddTask(featureTask1);
            projectTask.AddTask(featureTask2);

            Task testingTask = new TestingTask("Тестирование проекта");
            projectTask.AddTask(testingTask);

            Task designTask = new DesignTask("Дизайн проекта");
            projectTask.AddTask(designTask);

            // Назначение и выполнение задач
            projectTask.Assign();
            featureTask1.Assign();
            featureTask2.Assign();
            testingTask.Assign();
            designTask.Assign();

            featureTask1.Complete();
            featureTask2.Complete();
            testingTask.Complete();
            designTask.Complete();
        }
    }

    // Компонент - задача
    abstract class Task
    {
        protected string name;

        public Task(string name)
        {
            this.name = name;
        }

        public abstract void AddTask(Task task);
        public abstract void RemoveTask(Task task);
        public abstract void Assign();
        public abstract void Complete();
    }

// Листовой компонент - задача на разработку
    class DevelopmentTask : Task
    {
        public DevelopmentTask(string name) : base(name)
        {
        }

        public override void AddTask(Task task)
        {
            Console.WriteLine("Невозможно добавить задачу в задачу на разработку");
        }

        public override void RemoveTask(Task task)
        {
            Console.WriteLine("Невозможно удалить задачу из задачи на разработку");
        }

        public override void Assign()
        {
            Console.WriteLine($"Задача на разработку '{name}' назначена разработчику");
        }

        public override void Complete()
        {
            Console.WriteLine($"Задача на разработку '{name}' завершена");
        }
    }

// Листовой компонент - задача на тестирование
    class TestingTask : Task
    {
        public TestingTask(string name) : base(name)
        {
        }

        public override void AddTask(Task task)
        {
            Console.WriteLine("Невозможно добавить задачу в задачу на тестирование");
        }

        public override void RemoveTask(Task task)
        {
            Console.WriteLine("Невозможно удалить задачу из задачи на тестирование");
        }

        public override void Assign()
        {
            Console.WriteLine($"Задача на тестирование '{name}' назначена тестировщику");
        }

        public override void Complete()
        {
            Console.WriteLine($"Задача на тестирование '{name}' завершена");
        }
    }

// Листовой компонент - задача на дизайн
    class DesignTask : Task
    {
        public DesignTask(string name) : base(name)
        {
        }

        public override void AddTask(Task task)
        {
            Console.WriteLine("Невозможно добавить задачу в задачу на дизайн");
        }

        public override void RemoveTask(Task task)
        {
            Console.WriteLine("Невозможно удалить задачу из задачи на дизайн");
        }

        public override void Assign()
        {
            Console.WriteLine($"Задача на дизайн '{name}' назначена дизайнеру");
        }

        public override void Complete()
        {
            Console.WriteLine($"Задача на дизайн '{name}' завершена");
        }
    }

// Интерфейс состояния задачи
    interface ITaskState
    {
        void ProcessTask();
    }

// Состояние - новая задача
    class NewState : ITaskState
    {
        public void ProcessTask()
        {
            Console.WriteLine("Задача находится в состоянии 'новая'");
        }
    }

// Состояние - задача в работе
    class InProgressState : ITaskState
    {
        public void ProcessTask()
        {
            Console.WriteLine("Задача находится в состоянии 'в работе'");
        }
    }

// Состояние - завершенная задача
    class CompletedState : ITaskState
    {
        public void ProcessTask()
        {
            Console.WriteLine("Задача находится в состоянии 'завершена'");
        }
    }
}
