# Задача
Железнодорожная сеть задана набором станций. Между некоторыми станциями проложены пути. Длина путей задается целыми числами. Пути двунаправленные одноколейные (поезда, идущие навстречу друг другу, сталкиваются). Станция - точка (поезда, оказавшиеся на станции в один момент времени, сталкиваются). Маршруты поездов заданы списком станций, через которые они проезжают. Скорости одинаковые (скажем, равны единице). Поезда начинают движение одновременно. После достижения конечной станции поезд исчезает. Поезд представляет собой точку.

Задача: По заданной конфигурации сети и поездов определить возникнет ли столкновение


# Допущения:

* Все данные считаются валидными
* Если два поезда прибыли на одну конечную станцию одновременно, они столкнутся. Аналогично, если один прибыл на станцию как на конечную, а другой как на промежуточную.

# Формат файлов
## Сеть
Первая строка - количество станций.
В каждой следующей строке указываем номера связанных станций и расстояние между ними через пробел. Нумерация с нуля.
Пример:
```
5
0 2 1
1 2 5
1 3 5
2 3 3
3 4 2
```
## Пути поездов
Первая строка - количество поездов.
В каждой следующей строке номера станций через пробел для i-го поезда.
Пример:
```
2
1 2 0
4 3 2 0
```

# Аргументы командной строки
Программа принимает в качестве аргумента путь к директории с файлами. Программа читает все файлы по маске: `stations*.txt` и аналогичные им `trains*.txt`.