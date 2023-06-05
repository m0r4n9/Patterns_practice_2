using System;
using System.Collections.Generic;

namespace Patterns
{
    abstract class Program
    {
        static void Main(string[] args)
        {
            // Создание иерархии задач
            CompositeTask projectTask = new CompositeTask("Разработка проекта");
            Task featureTask1 = new DevelopmentTask("Реализация функции 1");
            Task featureTask2 = new DevelopmentTask("Реализация функции 2");

            projectTask.AddTask(featureTask1);
            projectTask.AddTask(featureTask2);

            CompositeTask testingTask = new CompositeTask("Тестирование проекта");
            testingTask.AddTask(new TestingTask("Тестирование функции 1"));
            testingTask.AddTask(new TestingTask("Тестирование функции 2"));
            projectTask.AddTask(testingTask);

            CompositeTask designTask = new CompositeTask("Дизайн проекта");
            designTask.AddTask(new DesignTask("Дизайн функции 1"));
            designTask.AddTask(new DesignTask("Дизайн функции 2"));
            projectTask.AddTask(designTask);

            // Назначение и выполнение задач
            projectTask.Assign();
            projectTask.Complete();
        }
    }

    // Компонент - задача
    abstract class Task
    {
        protected internal string name;
        protected internal ITaskState state;

        public Task(string name)
        {
            this.name = name;
            state = new NewState();
        }

        public abstract void Assign();
        public abstract void Complete();

        public void ChangeState(ITaskState newState)
        {
            state = newState;
        }
    }

    // Компонент-контейнер - составная задача
    class CompositeTask : Task
    {
        private List<Task> subtasks;
        private bool allSubtasksCompleted; // Добавлено поле для отслеживания статуса выполнения всех подзадач

        public CompositeTask(string name) : base(name)
        {
            subtasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            subtasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            subtasks.Remove(task);
        }

        public override void Assign()
        {
            state.ProcessTask();
            Console.WriteLine($"Задача '{name}' назначена");
            foreach (Task task in subtasks)
            {
                task.Assign();
            }
        }

        public override void Complete()
        {
            state.ProcessTask();
            Console.WriteLine($"Задача '{name}' завершена");
            foreach (Task task in subtasks)
            {
                task.Complete();
            }

            if (CheckAllSubtasksCompleted()) // Проверка статуса выполнения всех подзадач
            {
                ChangeState(new CompletedState());
            }
        }

        private bool CheckAllSubtasksCompleted()
        {
            foreach (Task task in subtasks)
            {
                if (!(task is CompositeTask) && !(task.state is CompletedState))
                {
                    Console.WriteLine($"Подзадача '{task.name}' не выполнена");
                    return false;
                }
            }
            return true;
        }
    }

    // Листовой компонент - задача на разработку
    class DevelopmentTask : Task
    {
        public DevelopmentTask(string name) : base(name)
        {
        }

        public override void Assign()
        {
            state.ProcessTask();
            Console.WriteLine($"Задача на разработку '{name}' назначена разработчику");
            ChangeState(new InProgressState());
        }

        public override void Complete()
        {
            state.ProcessTask();
            Console.WriteLine($"Задача на разработку '{name}' завершена");
            ChangeState(new CompletedState());
        }
    }

    // Листовой компонент - задача на тестирование
    class TestingTask : Task
    {
        public TestingTask(string name) : base(name)
        {
        }

        public override void Assign()
        {
            state.ProcessTask();
            Console.WriteLine($"Задача на тестирование '{name}' назначена тестировщику");
            ChangeState(new InProgressState());
        }

        public override void Complete()
        {
            state.ProcessTask();
            Console.WriteLine($"Задача на тестирование '{name}' завершена");
            ChangeState(new CompletedState());
        }
    }

    // Листовой компонент - задача на дизайн
    class DesignTask : Task
    {
        public DesignTask(string name) : base(name)
        {
        }

        public override void Assign()
        {
            state.ProcessTask();
            Console.WriteLine($"Задача на дизайн '{name}' назначена дизайнеру");
            ChangeState(new InProgressState());
        }

        public override void Complete()
        {
            state.ProcessTask();
            Console.WriteLine($"Задача на дизайн '{name}' завершена");
            ChangeState(new CompletedState());
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
    class InProgressState : ITaskState{
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
}}
