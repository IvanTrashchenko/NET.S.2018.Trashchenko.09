# Task 1
Реализовать метод "пузырьковой" сортировки непрямоугольного ("jagged" array) целочисленного массива (не использовать методы класса System.Array!) таким образом, чтобы была возможность, в частности, упорядочить строки матрицы:

* в порядке возрастания(убывания) сумм элементов строк матрицы;
* в порядке возрастания(убывания) максимальных элементов строк матрицы;
* в порядке возрастания(убывания) минимальных элементов строк матрицы. 

Разработать unit-тесты (NUnit фреймворк).
# Task 2
Разработать систему типов для описания работы с банковским счетом. Состояние счета определяется его номером, данными о владельце счета (имя, фамилия и т.д.), суммой на счете и некоторыми бонусными баллами, которые увеличиваются/уменьшаются каждый раз при пополнении счета/списании со счета на величины различные для пополнения и списания и рассчитываемые в зависимости от некоторых значений величин «стоимости» баланса и «стоимости» пополнения. Величины «стоимости» баланса и «стоимости» пополнения являются целочисленными значениями и зависят от градации счета, который может быть, например, Base, Silver, Gold, Platinum. Для работы со счетом реализовать следующие возможности:

* выполнить пополнение на счет;
* выполнить списание со счета;
* создать новый счет;
* закрыть счет.

Протестировать работу с системой типов в консольном приложении.
