# Практическая работа №2
## Паттерны:
Данная программа использует такие паттерны как: паттерн компоновщика и состояния. 

## Паттерн "Компоновщик":
Паттерн "Компоновщик" предоставляет способ структурирования объектов в иерархию
древовидной структуры и работу с ними единообразно. 
#Ключевые элементы:
  - Компонент (Component): Определяет интерфейс для всех компонентов в древовидной структуре. Может быть как листовым компонентом, так и составным компонентом.
  - Листовой компонент (Leaf): Представляет конечный элемент в древовидной структуре, который не имеет вложенных компонентов.
  - Составной компонент (Composite): Представляет компонент, который может содержать в себе другие компоненты (как листовые, так и составные) и определяет операции для работы с ними.

Данный паттерн полезен, когда нужно работать с ерархической структурой объектов, а также когда необходимо применять однородны еоперации как к отдельным объектам, так и к группам объектов. 


## Паттерн "Состояния":
Паттерн "Состояния" позволяет объекту изменять свое поведение в зависимости от своего внутреннего состояния. Это позволяет достичь гибкости в поведении объекта без необходимости изменения его класса.
#Ключевые элементы:
- Контекст (Context): Хранит ссылку на текущий объект состояния и делегирует ему вызовы операций.
- Состояние (State): Определяет интерфейс для конкретных состояний и реализует поведение, связанное с этим состоянием.
- Конкретные состояния (Concrete States): Представляют различные состояния, в которых может находиться объект. Реализуют операции, связанные с соответствующим состоянием.

Паттерн состояние полезен, когда объект может находиться в различных состояниях, и его поведение должно изменяться в зависимости от текущего состояния. Он позволяет избежать длинных цепочек условных операторов и делает код более гибким и легким в поддержке.

Оба этих паттерна помогают достичь гибкости и расширяемости код

## UML программы:
![image](https://github.com/m0r4n9/Patterns_practice_2/assets/112942681/c3d0f02f-836f-45bf-a206-da54edcc4251)

